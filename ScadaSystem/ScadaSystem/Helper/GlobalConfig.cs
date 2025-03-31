using HslCommunication;
using HslCommunication.Profinet.Siemens;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MiniExcelLibs;
using ScadaSystem.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper {
    public class GlobalConfig : IDisposable {
        public SiemensS7Net Plc { get; set; }
        /// <summary>
        /// 读取字典 同步字典，不会产生数据访问问题   <En,Value>
        /// </summary>
        public ConcurrentDictionary<string, object> ReadDataDic { get; set; } = new();
        public List<ReadEntity> ReadEntites { get; set; } = new();
        public List<WriteEntity> WriteEntities { get; set; } = new();
        public bool PlcConnected = false;

        private readonly RootParam options;
        private readonly ILogger<GlobalConfig> logger;
        CancellationTokenSource cts = new();

        public GlobalConfig(IOptionsSnapshot<RootParam> optionsSnapshot, ILogger<GlobalConfig> logger) {
            this.options = optionsSnapshot.Value;
            InitPlc();
            InitExcelAddress();
            this.logger = logger;
        }

        /// <summary>
        /// 首先初始化ReadEntites 和WriteEntities ，得到表中的全部属性Module	Cn	En	Address	Save，不包括值
        /// </summary>
        private void InitExcelAddress() {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory + "Configs\\";
            var readPath = rootPath + "TulingRead.xlsx";
            var writePath = rootPath + "TulingWrite.xlsx";
            if (!File.Exists(readPath) || !File.Exists(writePath)) {
                logger.LogError("当前读写Excel文件不存在");
                return;
            }
            try {
                ReadEntites = MiniExcel.Query<ReadEntity>(readPath)
                    .Where(x => !string.IsNullOrEmpty(x.Address))//所读取的地址不能为空
                    .ToList();
                WriteEntities = MiniExcel.Query<WriteEntity>(writePath)
                    .Where(x => !string.IsNullOrEmpty(x.Address))//所读取的地址不能为空
                    .ToList();
            } catch (Exception e) {
                logger.LogError($"读取文件异常：{e.Message}");
                throw;
            }
        }
        /// <summary>
        /// 开始采集
        /// </summary>
        /// <param name="externalToken"></param>
        /// <returns></returns>
        public Task StartCollectionAsync(CancellationToken? externalToken = null) {
            //StopCollection();
            //令牌创建
            cts = CancellationTokenSource.CreateLinkedTokenSource(externalToken ?? CancellationToken.None);

            return Task.Run(async () => {
                while (!cts.IsCancellationRequested) {
                    try {
                        await Task.Delay(options.PlcParam.PlcCycleInterval, cts.Token);

                        //批量读取
                        await UpdateControlData();
                        await UpdataMonitorData();
                        await UpdateProcessData();

                    } catch (Exception e) {
                        logger.LogError($"{e.Message}");
                    }
                }
            });

        }

        /// <summary>
        /// 根据传进来的模块名称和地址类型进行对plc的读取，并把读取的结果存放到readDic中，异步读取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="module"></param>
        /// <param name="addressType"></param>
        /// <returns></returns>
        private async Task UpdatePlcToReadDic<T>(string module, string addressType) {
            //筛选这要读取的模块，和地址类型，地址类型有DBX 和DBD，就是bool和float之分
            var addresses = ReadEntites.Where(x => x.Module == module && x.Address.Contains(addressType)).ToList();
            if (addresses.Count < 1) {
                return;
            }
            try {
                //存放读取的结果 
                OperateResult<T[]> result;
                //批量读取
                if (typeof(T) == typeof(bool)) {
                    //从Address中读取Count个数据，返回给result
                    result = await Plc.ReadBoolAsync(addresses.First().Address, (ushort)addresses.Count) as OperateResult<T[]>;
                } else if (typeof(T) == typeof(float)) {
                    result = await Plc.ReadFloatAsync(addresses.First().Address, (ushort)addresses.Count) as OperateResult<T[]>;
                } else {
                    throw new Exception("不支持传入的类型");
                }

                if (!result.IsSuccess) {
                    return;
                    //throw new Exception("数据读取失败");
                }

                //将Result放入 字典中
                for (int i = 0; i < addresses.Count; i++) {
                    //开始真正的将数据放到ReadDic中，如果该数据在ReadDic不存在就新建(第一次)，如果存在就更新
                    if (ReadDataDic.ContainsKey(addresses[i].En)) {
                        ReadDataDic[addresses[i].En] = result.Content[i];
                    } else {
                        //尝试添加
                        ReadDataDic.TryAdd(addresses[i].En, result.Content[i]);
                    }
                }
            } catch (Exception e) {
                logger.LogError(e.Message);
            }


        }
        private async Task UpdateProcessData() {
            await UpdatePlcToReadDic<float>("Data", "DBD");
        }

        private async Task UpdataMonitorData() {
            await UpdatePlcToReadDic<bool>("Monitor", "DBX");
        }

        private async Task UpdateControlData() {
            await UpdatePlcToReadDic<bool>("Control", "DBX");
        }

        public void StopCollection() {
            try {
                if (cts != null) {
                    cts.Cancel();
                    cts.Dispose();
                }
            } catch (Exception e) {
                logger.LogError(e.Message);
                throw;
            }
        }

        public async void InitPlcServer() {
            try {

                var operateResult = await Plc.ConnectServerAsync();
                if (!operateResult.IsSuccess) {
                    logger.LogError($"连接失败：{options.PlcParam.PlcIp}:{options.PlcParam.PlcPort}");
                }
                PlcConnected = true;


            } catch (Exception e) {
                PlcConnected = false;
                logger.LogError($"Plc异常信息：{e.Message}");
                throw;
            }
        }

        public void InitPlc() {
            Plc = new SiemensS7Net(SiemensPLCS.S1200, options.PlcParam.PlcIp);
            Plc.Port = options.PlcParam.PlcPort;
            Plc.Slot = options.PlcParam.PlcSlot;
            Plc.Rack = options.PlcParam.PlcRack;
            Plc.ConnectTimeOut = options.PlcParam.PlcConnectTimeOut;
        }


        //获取实时数值
        public T GetValue<T>(string key) {
            if (ReadDataDic.TryGetValue(key, out var data)) {
                return (T)data;
            }
            return default(T);
        }

        public void Dispose() {
        }

    }
}
