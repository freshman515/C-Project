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

namespace SprayProcessSCADASystemOnWinform {
    public partial class PageEquipmentMonitor : UIPage {
        private List<Control> controls;
        public PageEquipmentMonitor() {
            InitializeComponent();
            controls = Globals.GetAllControls(this);
            this.timer1.Interval = 500; //间隔500ms
            this.timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object? sender, EventArgs e) {
            if (!Globals.SiemensClient.Connected) {
                return;
            }

            //遍历所有子控件
            foreach (var control in controls) {
                if (control is UserDeviceState userDeviceState) {
                    userDeviceState.State = Globals.DataDic[userDeviceState.VariableName].ToString() == "1";
                } else if (control is UserAlarmState userAlarmState) {
                    userAlarmState.State = Globals.DataDic[userAlarmState.VariableName].ToString() == "1";
                } else if (control is UserVarCurrentValue userVarCurrentValue) {
                    userVarCurrentValue.VarValue = Globals.DataDic[userVarCurrentValue.VariableName].ToString().ToFloat();
                }

            }


        }
    }
}
