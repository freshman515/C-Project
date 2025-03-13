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
    public partial class UserDeviceUnitControl : UIUserControl {
        public UserDeviceUnitControl() {
            InitializeComponent();
        }

        private string equipmentUnitName = "设备单元";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设备单元的名称")]
        public string EquipmentUnitName {
            get { return equipmentUnitName; }
            set {
                equipmentUnitName = value;
                this.lbl_DeviceName.Text = equipmentUnitName;
            }
        }

        private bool state = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设备状态")]
        public bool State {
            get {
                state = this.sw_Device.Active;
                return state;
            }
            set {
                state = value;
                this.sw_Device.Active = state;
            }
        }


        /// <summary>
        /// 西门子plc点表中 一个设备是由两个值来表示是否为打开还是关闭 所以要绑定两个值,对外暴露出去
        /// </summary>
        private string openVariableName = "";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取变量名词")]
        public string OpenVariableName {
            get { return openVariableName; }
            set { openVariableName = value; }
        }
     

        private void sw_Device_Click(object sender, EventArgs e) {
            ClickEvent?.Invoke(this, e);
        }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("点击事件")]
        public event EventHandler? ClickEvent;


        private string closeVariableName = "";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取变量名词")]
        public string CloseVariableName {
            get { return closeVariableName; }
            set { closeVariableName = value; }
        }



    }
}
