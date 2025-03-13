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

        }

        private void btn_Save_Click(object sender, EventArgs e) {
            //写入配置
            var result = Globals.IniFile.Write("PLC参数", "变量地址表", this.txt_PLCVarAddressPath.Text);
            if (!result) {
                UIMessageTip.Show("保存失败");
            } else {
                UIMessageTip.Show("保存成功");
            }
            
            
        }
    }
}
