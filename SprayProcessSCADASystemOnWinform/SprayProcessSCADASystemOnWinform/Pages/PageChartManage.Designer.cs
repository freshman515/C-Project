namespace SprayProcessSCADASystemOnWinform {
    partial class PageChartManage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dtp_End = new Sunny.UI.UIDatetimePicker();
            dtp_Start = new Sunny.UI.UIDatetimePicker();
            uiSymbolLabel2 = new Sunny.UI.UISymbolLabel();
            uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            btn_QueryData = new Sunny.UI.UISymbolButton();
            lc_Chart = new Sunny.UI.UILineChart();
            SuspendLayout();
            // 
            // dtp_End
            // 
            dtp_End.FillColor = Color.White;
            dtp_End.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtp_End.Location = new Point(792, 54);
            dtp_End.Margin = new Padding(4, 5, 4, 5);
            dtp_End.MaxLength = 19;
            dtp_End.MinimumSize = new Size(63, 0);
            dtp_End.Name = "dtp_End";
            dtp_End.Padding = new Padding(0, 0, 30, 2);
            dtp_End.Size = new Size(300, 54);
            dtp_End.SymbolDropDown = 61555;
            dtp_End.SymbolNormal = 61555;
            dtp_End.SymbolSize = 24;
            dtp_End.TabIndex = 5;
            dtp_End.Text = "2025-03-10 20:29:42";
            dtp_End.TextAlignment = ContentAlignment.MiddleLeft;
            dtp_End.Value = new DateTime(2025, 3, 10, 20, 29, 42, 162);
            dtp_End.Watermark = "";
            // 
            // dtp_Start
            // 
            dtp_Start.FillColor = Color.White;
            dtp_Start.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtp_Start.Location = new Point(257, 54);
            dtp_Start.Margin = new Padding(4, 5, 4, 5);
            dtp_Start.MaxLength = 19;
            dtp_Start.MinimumSize = new Size(63, 0);
            dtp_Start.Name = "dtp_Start";
            dtp_Start.Padding = new Padding(0, 0, 30, 2);
            dtp_Start.Size = new Size(283, 54);
            dtp_Start.SymbolDropDown = 61555;
            dtp_Start.SymbolNormal = 61555;
            dtp_Start.SymbolSize = 24;
            dtp_Start.TabIndex = 6;
            dtp_Start.Text = "2025-03-10 20:29:42";
            dtp_Start.TextAlignment = ContentAlignment.MiddleLeft;
            dtp_Start.Value = new DateTime(2025, 3, 10, 20, 29, 42, 162);
            dtp_Start.Watermark = "";
            // 
            // uiSymbolLabel2
            // 
            uiSymbolLabel2.Font = new Font("宋体", 10F);
            uiSymbolLabel2.Location = new Point(571, 49);
            uiSymbolLabel2.MinimumSize = new Size(1, 1);
            uiSymbolLabel2.Name = "uiSymbolLabel2";
            uiSymbolLabel2.Size = new Size(190, 65);
            uiSymbolLabel2.Symbol = 62067;
            uiSymbolLabel2.SymbolSize = 40;
            uiSymbolLabel2.TabIndex = 3;
            uiSymbolLabel2.Text = "结束时间";
            // 
            // uiSymbolLabel1
            // 
            uiSymbolLabel1.Font = new Font("宋体", 10F);
            uiSymbolLabel1.Location = new Point(9, 49);
            uiSymbolLabel1.MinimumSize = new Size(1, 1);
            uiSymbolLabel1.Name = "uiSymbolLabel1";
            uiSymbolLabel1.Size = new Size(217, 65);
            uiSymbolLabel1.Symbol = 62067;
            uiSymbolLabel1.SymbolSize = 40;
            uiSymbolLabel1.TabIndex = 4;
            uiSymbolLabel1.Text = "开始时间";
            // 
            // btn_QueryData
            // 
            btn_QueryData.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_QueryData.Location = new Point(1123, 54);
            btn_QueryData.MinimumSize = new Size(1, 1);
            btn_QueryData.Name = "btn_QueryData";
            btn_QueryData.Size = new Size(205, 57);
            btn_QueryData.Symbol = 559520;
            btn_QueryData.SymbolSize = 40;
            btn_QueryData.TabIndex = 3;
            btn_QueryData.Text = "查询数据";
            btn_QueryData.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_QueryData.Click += btn_QueryData_Click;
            // 
            // lc_Chart
            // 
            lc_Chart.Font = new Font("宋体", 9F);
            lc_Chart.LegendFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lc_Chart.Location = new Point(25, 148);
            lc_Chart.MinimumSize = new Size(1, 1);
            lc_Chart.MouseDownType = Sunny.UI.UILineChartMouseDownType.Zoom;
            lc_Chart.Name = "lc_Chart";
            lc_Chart.Size = new Size(1458, 671);
            lc_Chart.SubFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lc_Chart.TabIndex = 7;
            // 
            // PageChartManage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(lc_Chart);
            Controls.Add(btn_QueryData);
            Controls.Add(dtp_End);
            Controls.Add(dtp_Start);
            Controls.Add(uiSymbolLabel2);
            Controls.Add(uiSymbolLabel1);
            Name = "PageChartManage";
            Symbol = 61950;
            Text = "图标管理";
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIDatetimePicker dtp_End;
        private Sunny.UI.UIDatetimePicker dtp_Start;
        private Sunny.UI.UISymbolLabel uiSymbolLabel2;
        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
        private Sunny.UI.UISymbolButton btn_QueryData;
        private Sunny.UI.UILineChart lc_Chart;
    }
}