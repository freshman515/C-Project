using IoTClient.Clients.PLC;
using IoTClient.Common.Enums;
using IoTClient.Enums;
using Microsoft.Extensions.DependencyInjection;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayProcessSCADASystemOnWinform {
    public static class Globals {
        public static ServiceProvider ServiceProvider;
        public static IniFile IniFile = new IniFile(Application.StartupPath + "\\config.ini");
        public static string PlcVarConfigPath;
        public static string DelFilePath;
        public static string SaveDay;
        public static string SoftwareVersion;
        public static string SoftTime;
        //plc配置
        public static SiemensClient SiemensClient;
        //CPU类型
        public static SiemensVersion CpuType;
        //IP地址
        public static string IPAddress;
        //端口号
        public static int Port;
        //插槽号
        public static byte Slot;
        //机架号
        public static byte Rack;
        //连接超时时间
        public static int ConnectTimeOut;
        //读取间隔时间
        public static int ReadTimeInterval;
        //PLC重连时间间隔
        public static int ReConnectTimeInterval;

        //PLC变量 地址 字典  IotClient的批量读取规则  <地址-类型>
        public static Dictionary<string, DataTypeEnum> ReadDic = new Dictionary<string, DataTypeEnum>();
        //PLC变量 读取值 字典  <名称-值>
        public static Dictionary<string, object> DataDic = new Dictionary<string, object>();
        //PLC变量 写入 字典  <名称-地址>  目的都是为了不直接操作地址
        public static Dictionary<string, string> WriteDic = new Dictionary<string, string>();
        //PLC变量 需要保存的集和
        public static List<string> SelfList = new List<string>();

        public static bool PlcWrite(string varName, object value, DataTypeEnum dataTypeEnum=DataTypeEnum.Bool) {
            if (SiemensClient != null && SiemensClient.Connected) {
                var address = WriteDic[varName];
                var result = SiemensClient.Write(address, value,dataTypeEnum);
                if (result.IsSucceed) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;

        }
        #region 获取所有控件
        public static List<Control> GetAllControls(UIPage page) {
            List<Control> allControls = new List<Control>();
            CollectControls(page.Controls, allControls);
            return allControls;
        }

        private static void CollectControls(Control.ControlCollection controls, List<Control> allControls) {
            foreach (Control control in controls) {
                allControls.Add(control);
                if (control.HasChildren) {
                    CollectControls(control.Controls, allControls);
                }
            }
        }

        #endregion
    }
}
