using BLL;
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
    public partial class PageChartManage : UIPage {
        private readonly DataManager dataManager;

        public PageChartManage(DataManager dataManager) {
            InitializeComponent();
            this.dataManager = dataManager;
            this.dtp_Start.Value = DateTime.Now.AddHours(-1);
            this.dtp_End.Value = DateTime.Now;
            UILineOption option = new UILineOption() {
                ToolTip = { Visible = true },
                Title = new UITitle { Text = "" },
                Legend = new UILegend {
                    Orient = UIOrient.Horizontal,
                    Top = UITopAlignment.Top,
                    Left = UILeftAlignment.Left
                },
                XAxisType = UIAxisType.DateTime,
                XAxis = { Name = "日期", AxisLabel = { DateTimeFormat = "HH:mm:ss" } },
                YAxis = { Name = "数值", AxisLabel = { DecimalPlaces = 1 } }
            };
            string[] legendData = {
                "脱脂喷淋泵压力值",
                "脱脂pH值",
                "陶化pH值",
                "粗洗喷淋泵压力值",
                "陶化喷淋泵压力值",
                "精洗喷淋泵压力值",
                "水分炉测量温度",
                "固化炉测量温度"
            };
            foreach (var data in legendData) {
                option.Legend.AddData(data);
                AddSeries(option, data);
            }
            lc_Chart.SetOption(option);
        }
        private void AddSeries(UILineOption option, string seriesName) {
            var series = option.AddSeries(new UILineSeries(seriesName));
            series.Symbol = UILinePointSymbol.Circle;
            series.SymbolSize = 4;
            series.Width = 2;
            //series.YAxisDecimalPlaces = 1;
            series.Smooth = true;
        }

        private async void btn_QueryData_Click(object sender, EventArgs e) {
            var t1 = this.dtp_Start.Value;
            var t2 = this.dtp_End.Value;
            if (t1 > t2) {
                UIMessageTip.ShowWarning("开始时间不能大于结束时间");
                return;
            }
            QueryDataDto queryDataDto = new QueryDataDto() { StartTime = t1, EndTime = t2 };
            var res = await dataManager.GetDataListByTimeAsync(queryDataDto);
            if (res.Status == Helper.SystemEnums.Result.Fail) {
                UIMessageTip.ShowWarning("查询失败:" + res.Message);
                LogExtension.ShowMessage?.Invoke(res.Message, Microsoft.Extensions.Logging.LogLevel.Error);
                return;
            }
            for (int i = 0; i < res.Data.Count; i++) {
                if (i > 30) {
                    break;
                }
                var dt = res.Data[i].InsertTime;
                var dataRes = res.Data[i];
                lc_Chart.Option.AddData("脱脂喷淋泵压力值", dt, double.Parse(dataRes.脱脂喷淋泵压力值));
                lc_Chart.Option.AddData("脱脂pH值", dt, double.Parse(dataRes.脱脂pH值));
                lc_Chart.Option.AddData("陶化pH值", dt, double.Parse(dataRes.陶化pH值));
                lc_Chart.Option.AddData("粗洗喷淋泵压力值", dt, double.Parse(dataRes.粗洗喷淋泵压力值));
                lc_Chart.Option.AddData("陶化喷淋泵压力值", dt, double.Parse(dataRes.陶化喷淋泵压力值));
                lc_Chart.Option.AddData("精洗喷淋泵压力值", dt, double.Parse(dataRes.精洗喷淋泵压力值));
                lc_Chart.Option.AddData("水分炉测量温度", dt, double.Parse(dataRes.水分炉测量温度));
                lc_Chart.Option.AddData("固化炉测量温度", dt, double.Parse(dataRes.固化炉测量温度));
            }

            lc_Chart.Refresh();
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
