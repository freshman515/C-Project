using BLL;
using Helper;
using MiniExcelLibs;
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
    public partial class PageReportManage : UIPage {
        private readonly DataManager dataManager;
        BaseResult<QueryDataResultDto> res;
        public PageReportManage(DataManager dataManager) {
            InitializeComponent();
            this.dataManager = dataManager;
            this.dtp_Start.Value = DateTime.Now.AddDays(-1); //昨天
            this.dtp_End.Value = DateTime.Now;//当前时间
            this.dgv_Data.AutoGenerateColumns = false;
        }

        private async void btn_QueryData_Click(object sender, EventArgs e) {
            DateTime t1 = this.dtp_Start.Value;
            DateTime t2 = this.dtp_End.Value;
            if (t1 > t2) {
                UIMessageTip.ShowWarning("开始的时间不能大于结束时间");
                return;
            }
            var queryDataDto = new QueryDataDto() {
                StartTime = t1,
                EndTime = t2
            };
            res = await dataManager.GetDataListByTimeAsync(queryDataDto);
            if (res.Status == Helper.SystemEnums.Result.Fail) {
                UIMessageTip.ShowWarning(res.Message);
                return;
            }
            //设置分页总数
            this.pgn_Data.TotalCount = res.Data.Count;
            //设置每页的数量
            this.pgn_Data.PageSize = 15;
            //设置当前页
            pgn_Data.ActivePage = 1;




        }

        private void pgn_Data_PageChanged(object sender, object pagingSource, int pageIndex, int count) {
            var data = res.Data.Skip(pageIndex * count).Take(count).ToList();
            this.dgv_Data.DataSource = null;
            this.dgv_Data.DataSource = data;
        }

        private async void btn_ExportData_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var fileName = saveFileDialog.FileName;
                    var rows = this.dgv_Data.DataSource as List<QueryDataResultDto>;
                    await MiniExcel.SaveAsAsync(fileName, rows);
                } catch (Exception ex) {

                    UIMessageTip.ShowError(ex.Message);
                    LogExtension.ShowMessage?.Invoke(ex.Message, Microsoft.Extensions.Logging.LogLevel.Error);
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
