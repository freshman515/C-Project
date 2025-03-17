using MiniExcelLibs;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprayProcessSCADASystemOnWinform {
    public partial class PageLogManage : UIPage {
        public PageLogManage() {
            InitializeComponent();
            InitCbData();
        }
        private void InitCbData() {
            string logPath = Path.Combine(Application.StartupPath, "Logs");
            if (!Directory.Exists(logPath)) {
                Directory.CreateDirectory(logPath);
            }
            var dirNames = Directory.GetDirectories(logPath); //得到文件夹下所有文件夹的名字
            dirNames.ForEach(x => this.cb_Date.Items.Add(Path.GetFileName(x))); //Path.GetFileName(x)获取 x 路径中的文件名或文件夹名。



        }

        private void cb_Date_SelectedIndexChanged(object sender, EventArgs e) {
            var path = Path.Combine(Application.StartupPath, "Logs", cb_Date.SelectedItem.ToString()); //拼接轮径
            var dirNames = Directory.GetDirectories(path);//获取所有文件夹的名称
            this.cb_LogLev.Items.Clear(); //清空等级框
            dirNames.ForEach(x => this.cb_LogLev.Items.Add(Path.GetFileName(x)));
        }

        private void cb_LogLev_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.cb_Date.SelectedItem == null) {
                UIMessageTip.ShowError("请先选择日期");
                return;
            }
            if (this.cb_LogLev.SelectedItem == null) {
                UIMessageTip.ShowError("请先选择日志级别");
                return;
            }
            //三步：1、得到当前文件夹 2、从当前文件夹提取所有文件 3、把所有文件添加到ListBox中
            var logpath = Path.Combine(Application.StartupPath, "Logs", cb_Date.SelectedItem.ToString(), this.cb_LogLev.SelectedItem.ToString()); //拼接轮径
            this.lb_Files.Items.Clear();
            var fileNames = Directory.GetFiles(logpath, "*.log");//获取所有文件，然后用.log的格式返回
            fileNames.OrderBy(i => i).ToList().ForEach(x => {  //先排序，排完序再把所有文件添加到ListBox中
                this.lb_Files.Items.Add(Path.GetFileName(x));
            });
        }

        private async void lb_Files_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.cb_Date.SelectedItem == null) {
                UIMessageTip.ShowError("请先选择日期");
                return;
            }
            if (this.cb_LogLev.SelectedItem == null) {
                UIMessageTip.ShowError("请先选择日志级别");
                return;
            }
            if (this.lb_Files.SelectedItem == null) {
                UIMessageTip.ShowError("请选择日志文件");
                return;
            }
            var logPath = Path.Combine(Application.StartupPath, "Logs", this.cb_Date.SelectedItem.ToString(), this.cb_LogLev.SelectedItem.ToString(), this.lb_Files.SelectedItem.ToString());
            string content = string.Empty;
            this.txt_ShowLog.Clear();
            try {
                using (StreamReader sr = new StreamReader(logPath)) {
                    content = await sr.ReadToEndAsync();
                }

            } catch (Exception ex) {
                LogExtension.ShowMessage?.Invoke(ex.Message, Microsoft.Extensions.Logging.LogLevel.Error);
            }
            this.txt_ShowLog.Text = content;



        }

        private void btn_OpenDire_Click(object sender, EventArgs e) {

            var logDirPath = Path.Combine(Application.StartupPath, "Logs");
            ProcessStartInfo psi = new ProcessStartInfo() {
                FileName = logDirPath,
                UseShellExecute = true
            };

            Process process = new Process() {
                StartInfo = psi
            };
            process.Start();

        }

        private void btn_ShowToDgv_Click(object sender, EventArgs e) {
            if (this.txt_ShowLog.Text.Length == 0) {
                UIMessageTip.ShowWarning("请选择日志文件");
                return;
            }

            //分割为string[] 类型
            var lines = txt_ShowLog.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("时间");
            dataTable.Columns.Add("日志等级");
            dataTable.Columns.Add("日志来源");
            dataTable.Columns.Add("日志内容");

            lines.ToList().ForEach(line => {

                var items = line.Split(new string[] { "|" }, StringSplitOptions.None);

                if (items.Length == 4) { //判断每行是不是有四个内容
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["时间"] = items[0];
                    dataRow["日志等级"] = items[1];
                    dataRow["日志来源"] = items[2];
                    dataRow["日志内容"] = items[3];
                    dataTable.Rows.Add(dataRow); //把每一行添加到表中；
                }
            });
            this.dgv_ShowLog.DataSource = dataTable;

        }



        private void btn_ShowToTXT_Click(object sender, EventArgs e) {
            if (this.txt_ShowLog.Text == string.Empty) {
                UIMessageTip.ShowWarning("请选择日志文件");
                return;
            }
            //初始化对话框
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "文本文件|*.txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    //写入文件
                    using (StreamWriter sr = new StreamWriter(saveFileDialog.FileName)) {
                        sr.Write(txt_ShowLog.Text);
                    }
                    LogExtension.ShowMessage?.Invoke("日志导出成功", Microsoft.Extensions.Logging.LogLevel.Information);

                    //跳转到文件
                    ProcessStartInfo psi = new ProcessStartInfo() {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true,
                    };
                    Process process = new Process() {
                        StartInfo = psi,
                    };
                    process.Start();
                } catch (Exception ex) {
                    UIMessageTip.ShowError(ex.Message);
                    LogExtension.ShowMessage?.Invoke(ex.Message, Microsoft.Extensions.Logging.LogLevel.Error);
                }

            }

        }
        private async void btn_ExportExcel_Click(object sender, EventArgs e) {
            if (this.txt_ShowLog.Text == string.Empty) {
                UIMessageTip.ShowWarning("请选择日志文件");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files *.xlsx|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    DataTable dt = this.dgv_ShowLog.DataSource as DataTable;// 转换为一个表
                    await MiniExcel.SaveAsAsync(saveFileDialog.FileName, dt);
                    LogExtension.ShowMessage?.Invoke("日志导出成功", Microsoft.Extensions.Logging.LogLevel.Information);

                    ProcessStartInfo psi = new ProcessStartInfo {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true,
                    };
                    Process process = new Process {
                        StartInfo = psi,
                    };
                    process.Start();
                } catch (Exception ex) {
                    LogExtension.ShowMessage?.Invoke(ex.Message, Microsoft.Extensions.Logging.LogLevel.Error);
                    throw;
                }


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
