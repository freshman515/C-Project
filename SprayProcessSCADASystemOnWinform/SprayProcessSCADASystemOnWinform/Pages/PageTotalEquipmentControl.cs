using Microsoft.Extensions.Logging;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
namespace SprayProcessSCADASystemOnWinform {
    public partial class PageTotalEquipmentControl : UIPage {
        private readonly ILogger<PageTotalEquipmentControl> logger;

        public PageTotalEquipmentControl(ILogger<PageTotalEquipmentControl> logger) {
            InitializeComponent();
            this.logger = logger;
            //绑定扩展委托，让其它地方也能使用这个方法
            LogExtension.ShowMessage = ShowLog;
        }

        private void btn_Control_Comman_Click(object sender, EventArgs e) {
            if (!Globals.SiemensClient.Connected) {
                UIMessageTip.Show("请先连接PLC");
                return;
            }
            UISymbolButton btn = sender as UISymbolButton;
            if (Globals.PlcWrite(btn.TagString, true)) {
                UIMessageTip.Show("写入成功");
                ShowLog($"写入{btn.TagString}成功",LogLevel.Information);
            } else {
                UIMessageTip.Show($"写入{btn.TagString}失败");
            }

        }

        private void btn_DryRun_ClickedEvent(object sender, EventArgs e) {
            if (!Globals.SiemensClient.Connected) {
                UIMessageTip.Show("请先连接PLC");
                return;
            }
            if (Globals.PlcWrite(this.btn_DryRun.VariableName, !this.btn_DryRun.CounterButtonState)) {
                this.btn_DryRun.CounterButtonState = !btn_DryRun.CounterButtonState;
                UIMessageTip.Show("写入成功");
                ShowLog($"写入空运行成功", LogLevel.Information);

            } else {
                UIMessageTip.Show($"写入失败");
            }
        }

        private void device_Common_ClickEvent(object sender, EventArgs e) {
            UserDeviceUnitControl userDeviceUnit = sender as UserDeviceUnitControl;

            if (!Globals.SiemensClient.Connected) {
                userDeviceUnit.State = false;
                UIMessageTip.Show("请先连接PLC");
                return;
            }

            if (userDeviceUnit.State) {
                if (Globals.PlcWrite(userDeviceUnit.OpenVariableName, true)) {
                    UIMessageTip.Show("发送成功");
                    Globals.PlcWrite(userDeviceUnit.CloseVariableName, false);
                    ShowLog($"写入{userDeviceUnit.EquipmentUnitName}开成功", LogLevel.Information);
                }
            } else {
                if (Globals.PlcWrite(userDeviceUnit.CloseVariableName, true)) {
                    UIMessageTip.Show("发送成功");
                    Globals.PlcWrite(userDeviceUnit.OpenVariableName, false);
                    ShowLog($"写入{userDeviceUnit.EquipmentUnitName}关成功", LogLevel.Information);
                }

            }
        }
        public void ShowLog(string log, LogLevel level = LogLevel.Information) {
            this.txt_Log.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "=>" + log + Environment.NewLine);
            switch (level) {
                case LogLevel.Information:
                    logger.LogInformation(log);
                    break;
                case LogLevel.Warning:
                    logger.LogWarning(log);
                    break;
                case LogLevel.Error:
                    logger.LogError(log);
                    break;
            }

        }
        protected override CreateParams CreateParams {
            get {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
    }
}
