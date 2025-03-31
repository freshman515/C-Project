using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HslCommunication;
using Microsoft.Extensions.Logging;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using ScadaSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.ViewModels {
    public partial class DeviceViewModel : ObservableObject, IInjectable {
        private readonly GlobalConfig global;
        private readonly UserSession userSession;
        private readonly ILogger<DeviceViewModel> logger;
        [ObservableProperty]
        private ScadaReadDataEntity scadaReadData = new ScadaReadDataEntity();
        [ObservableProperty]
        private string logContent = string.Empty;

        public DeviceViewModel(GlobalConfig global, UserSession userSession, ILogger<DeviceViewModel> logger) {
            this.global = global;
            this.userSession = userSession;
            this.logger = logger;
            appendLog("程序启动");
        }
        private void appendLog(string content) {
            LogContent += ("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + content + Environment.NewLine);
        }
        [RelayCommand]
        void ClearLog() {
            LogContent = string.Empty;
        }
        [RelayCommand]
        void WriteDeviceControl(string name) {
            if (!global.PlcConnected) {
                userSession.ShowMessage("没有连接到PLC或连接异常");
                return;
            }
            var address = global.ReadEntites.FirstOrDefault(i => i.Module == "Control" && i.En == name)?.Address;
            if (string.IsNullOrEmpty(address)) {
                return;
            }
            //得到值，取反发送
            global.ReadDataDic.TryGetValue(name, out var value);
            value = !(bool)value;
            var result = global.Plc.Write(address, (bool)value);
            if (result.IsSuccess) {
                logger.LogInformation($"{name}写入成功");
                appendLog($"{name}写入值{value}成功");
            } else {
                logger.LogWarning($"{name}写入值{value}成功");
                appendLog($"{name}写入值{value}成功");
            }

        }
        [RelayCommand]
        void ToggleCollection(string openName) {
            if (!global.PlcConnected) {
                userSession.ShowMessage("没有连接到PLC或连接异常");
                return;
            }
            OperateResult openResult, closeResult;
            bool openOrClose = openName.EndsWith("Open") ? true : false;
            string closeName;
            if (openName.EndsWith("Open")) {
                closeName = openName.Substring(0, openName.Length - "Open".Length) + "Close";
            } else if (openName.EndsWith("Close")) {
                closeName = openName.Substring(0, openName.Length - "Close".Length) + "Open";
                //然后交换
                (openName, closeName) = (closeName, openName);
            } else {
                return;
            }


            //得到地址
            var openAddress = global.ReadEntites.FirstOrDefault(i => i.Module == "Control" && i.En == openName)?.Address;
            if (string.IsNullOrEmpty(openAddress)) {
                return;
            }
            var closeAddress = global.ReadEntites.FirstOrDefault(i => i.Module == "Control" && i.En == closeName)?.Address;
            if (string.IsNullOrEmpty(closeAddress)) {
                return;
            }


            //得到值，取反发送
            global.ReadDataDic.TryGetValue(openName, out var openValue);
            global.ReadDataDic.TryGetValue(closeName, out var closeValue);
            if ((openOrClose && !(bool)openValue) || (!openOrClose && (bool)openValue)) {
                openResult = global.Plc.Write(openAddress, openOrClose);
                closeResult = global.Plc.Write(closeAddress, !openOrClose);
            } else {
                return;
            }
            //if (openOrClose && (bool)openValue == false) {//想要打开  
            //    openResult = global.Plc.Write(openAddress, true);
            //    closeResult = global.Plc.Write(closeAddress, false);
            //} else if (!openOrClose && (bool)openValue == true) {//想要关闭
            //    openResult = global.Plc.Write(openAddress, false);
            //    closeResult = global.Plc.Write(closeAddress, true);
            //} else if (openOrClose && (bool)openValue == true) {//想要打开，但是本身为true
            //    openResult = global.Plc.Write(openAddress, true);
            //    closeResult = global.Plc.Write(closeAddress, false);
            //} else if (!openOrClose && (bool)openValue == false) {
            //    openResult = global.Plc.Write(openAddress, false);
            //    closeResult = global.Plc.Write(closeAddress, true);
            //} else {
            //    return;
            //}



            if (openResult.IsSuccess) {
                logger.LogInformation($"{openName}写入成功");
                appendLog($"{openName}写入{openOrClose}成功");
            } else {
                logger.LogWarning($"{openName}写入值{openValue}失败");
                appendLog($"{openName}写入{openOrClose}失败");
            }
            if (closeResult.IsSuccess) {
                logger.LogInformation($"{closeName}写入成功");
                appendLog($"{closeName}写入{!openOrClose}成功");
            } else {
                logger.LogWarning($"{closeName}写入值{closeValue}失败");
                appendLog($"{closeName}写入{!openOrClose}失败");
            }

        }
    }
}
