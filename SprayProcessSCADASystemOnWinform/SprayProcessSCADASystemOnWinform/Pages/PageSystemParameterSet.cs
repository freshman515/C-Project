using IoTClient.Common.Enums;
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
    public partial class PageSystemParameterSet : UIPage {
        public PageSystemParameterSet() {
            InitializeComponent();
            Load += PageSystemParameterSet_Load;
        }

        private void PageSystemParameterSet_Load(object? sender, EventArgs e) {
            //初始化参数要保证在formMain窗口初始化之后，所以初始化代码要放到Load事件中
            //要保证在点击界面时才加载
            InitSystemParameter();
        }

        private void InitSystemParameter() {
            //读取参数
            this.txt_PLCVarAddressPath.Text = Globals.PlcVarConfigPath;
            this.txt_IPAddress.Text = Globals.IPAddress;
            this.txt_Port.Text = Globals.Port.ToString() ;
            this.cb_CPUType.Items.AddRange(Enum.GetNames(typeof(SiemensVersion)));
            this.cb_CPUType.Text = Globals.CpuType.ToString();
            this.txt_Slot.Text = Globals.Slot.ToString();
            this.txt_Rack.Text = Globals.Rack.ToString();
            this.txt_ConnectTimeOut.Text = Globals.ConnectTimeOut.ToString();
            this.txt_ReadTimeInterval.Text = Globals.ReConnectTimeInterval.ToString();
            this.txt_ReConnectTimeInterval.Text = Globals.ReConnectTimeInterval.ToString();
            this.txt_DirePath.Text = Globals.DelFilePath;
            switch (Globals.SaveDay) {
                case "不清理": this.rbg_Save.SelectedIndex = 0; break;
                case "3天": this.rbg_Save.SelectedIndex = 1; break;
                case "7天": this.rbg_Save.SelectedIndex = 2; break;
                case "15天": this.rbg_Save.SelectedIndex = 3; break;
                case "30天": this.rbg_Save.SelectedIndex = 4; break;
                case "60天": this.rbg_Save.SelectedIndex = 5; break;
            }
            this.txt_SoftTime.Text = Globals.SoftTime;
            this.txt_SoftwareVersion.Text = Globals.SoftwareVersion;


        }
     

        private void btn_Save_Click(object sender, EventArgs e) {
            Dictionary<string, string> parameters = new Dictionary<string, string>() {
                {"地址",this.txt_IPAddress.Text},
                {"端口",this.txt_Port.Text},
                {"CPU类型",this.cb_CPUType.Text},
                {"机架号",this.txt_Rack.Text },
                {"插槽号",this.txt_Slot.Text },
                {"超时时间" ,this.txt_ConnectTimeOut.Text},
                {"读取时间间隔",this.txt_ReadTimeInterval.Text },
                {"重连时间间隔",this.txt_ReConnectTimeInterval.Text},
                {"变量表地址",this.txt_PLCVarAddressPath.Text},
            };
            foreach (var item in parameters) {
                if (!Globals.IniFile.Write("PLC参数", item.Key, item.Value)) {
                    UIMessageTip.ShowWarning($"保存参数{item.Key}失败");
                    return;
                }
            }
            string delPath = this.txt_DirePath.Text;
            string saveDay = this.rbg_Save.Items[this.rbg_Save.SelectedIndex].ToString();
            if (Directory.Exists(delPath)) { 
                if(!Globals.IniFile.Write("系统参数", "删除文件夹路径", delPath)) {
                    UIMessageTip.ShowWarning("保存参数删除文件夹路径失败");
                    return;
                }
            } else {
                UIMessageTip.ShowWarning("删除文件夹不存在");
                return;
            }
            if (!Globals.IniFile.Write("系统参数", "保存文件夹天数", saveDay)) {
                UIMessageTip.ShowWarning("保存文件夹天数无效");
                return;
            }
            if (!Globals.IniFile.Write("软件参数", "软件版本", this.txt_SoftwareVersion.Text)) {
                UIMessageTip.ShowWarning("软件版本无效");
                return;
            }
            if (!Globals.IniFile.Write("软件参数", "试用时间", this.txt_SoftTime.Text)) {
                UIMessageTip.ShowWarning("试用时间无效");
                return;
            }

            UIMessageTip.ShowOk("保存成功");



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
