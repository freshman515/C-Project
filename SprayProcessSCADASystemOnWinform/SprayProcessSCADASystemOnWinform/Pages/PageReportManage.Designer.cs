namespace SprayProcessSCADASystemOnWinform {
    partial class PageReportManage {
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            dtp_Start = new Sunny.UI.UIDatetimePicker();
            uiSymbolLabel2 = new Sunny.UI.UISymbolLabel();
            dtp_End = new Sunny.UI.UIDatetimePicker();
            btn_QueryData = new Sunny.UI.UISymbolButton();
            btn_ExportData = new Sunny.UI.UISymbolButton();
            dgv_Data = new Sunny.UI.UIDataGridView();
            脱脂喷淋泵压力值 = new DataGridViewTextBoxColumn();
            脱脂pH值 = new DataGridViewTextBoxColumn();
            陶化喷淋泵压力值 = new DataGridViewTextBoxColumn();
            陶化PH值 = new DataGridViewTextBoxColumn();
            精洗喷淋泵压力值 = new DataGridViewTextBoxColumn();
            粗洗喷淋泵压力值 = new DataGridViewTextBoxColumn();
            水分炉测量温度 = new DataGridViewTextBoxColumn();
            固化炉测量温度 = new DataGridViewTextBoxColumn();
            厂内温度 = new DataGridViewTextBoxColumn();
            厂内湿度 = new DataGridViewTextBoxColumn();
            uiPagination1 = new Sunny.UI.UIPagination();
            ((System.ComponentModel.ISupportInitialize)dgv_Data).BeginInit();
            SuspendLayout();
            // 
            // uiSymbolLabel1
            // 
            uiSymbolLabel1.Font = new Font("宋体", 10F);
            uiSymbolLabel1.Location = new Point(12, 36);
            uiSymbolLabel1.MinimumSize = new Size(1, 1);
            uiSymbolLabel1.Name = "uiSymbolLabel1";
            uiSymbolLabel1.Size = new Size(217, 65);
            uiSymbolLabel1.Symbol = 62067;
            uiSymbolLabel1.SymbolSize = 40;
            uiSymbolLabel1.TabIndex = 0;
            uiSymbolLabel1.Text = "开始时间";
            // 
            // dtp_Start
            // 
            dtp_Start.FillColor = Color.White;
            dtp_Start.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtp_Start.Location = new Point(213, 41);
            dtp_Start.Margin = new Padding(4, 5, 4, 5);
            dtp_Start.MaxLength = 19;
            dtp_Start.MinimumSize = new Size(63, 0);
            dtp_Start.Name = "dtp_Start";
            dtp_Start.Padding = new Padding(0, 0, 30, 2);
            dtp_Start.Size = new Size(283, 54);
            dtp_Start.SymbolDropDown = 61555;
            dtp_Start.SymbolNormal = 61555;
            dtp_Start.SymbolSize = 24;
            dtp_Start.TabIndex = 1;
            dtp_Start.TextAlignment = ContentAlignment.MiddleLeft;
            dtp_Start.Value = new DateTime(2025, 3, 10, 20, 29, 42, 162);
            dtp_Start.Watermark = "";
            // 
            // uiSymbolLabel2
            // 
            uiSymbolLabel2.Font = new Font("宋体", 10F);
            uiSymbolLabel2.Location = new Point(522, 36);
            uiSymbolLabel2.MinimumSize = new Size(1, 1);
            uiSymbolLabel2.Name = "uiSymbolLabel2";
            uiSymbolLabel2.Size = new Size(190, 65);
            uiSymbolLabel2.Symbol = 62067;
            uiSymbolLabel2.SymbolSize = 40;
            uiSymbolLabel2.TabIndex = 0;
            uiSymbolLabel2.Text = "结束时间";
            // 
            // dtp_End
            // 
            dtp_End.FillColor = Color.White;
            dtp_End.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dtp_End.Location = new Point(719, 41);
            dtp_End.Margin = new Padding(4, 5, 4, 5);
            dtp_End.MaxLength = 19;
            dtp_End.MinimumSize = new Size(63, 0);
            dtp_End.Name = "dtp_End";
            dtp_End.Padding = new Padding(0, 0, 30, 2);
            dtp_End.Size = new Size(300, 54);
            dtp_End.SymbolDropDown = 61555;
            dtp_End.SymbolNormal = 61555;
            dtp_End.SymbolSize = 24;
            dtp_End.TabIndex = 1;
            dtp_End.TextAlignment = ContentAlignment.MiddleLeft;
            dtp_End.Value = new DateTime(2025, 3, 10, 20, 29, 42, 162);
            dtp_End.Watermark = "";
            // 
            // btn_QueryData
            // 
            btn_QueryData.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_QueryData.Location = new Point(1050, 40);
            btn_QueryData.MinimumSize = new Size(1, 1);
            btn_QueryData.Name = "btn_QueryData";
            btn_QueryData.Size = new Size(205, 57);
            btn_QueryData.Symbol = 559520;
            btn_QueryData.SymbolSize = 40;
            btn_QueryData.TabIndex = 2;
            btn_QueryData.Text = "查询数据";
            btn_QueryData.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btn_ExportData
            // 
            btn_ExportData.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_ExportData.Location = new Point(1276, 40);
            btn_ExportData.MinimumSize = new Size(1, 1);
            btn_ExportData.Name = "btn_ExportData";
            btn_ExportData.Size = new Size(205, 57);
            btn_ExportData.Symbol = 362830;
            btn_ExportData.SymbolSize = 40;
            btn_ExportData.TabIndex = 2;
            btn_ExportData.Text = "导出数据";
            btn_ExportData.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // dgv_Data
            // 
            dgv_Data.AllowUserToAddRows = false;
            dgv_Data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgv_Data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Data.BackgroundColor = Color.White;
            dgv_Data.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Data.ColumnHeadersHeight = 60;
            dgv_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Data.Columns.AddRange(new DataGridViewColumn[] { 脱脂喷淋泵压力值, 脱脂pH值, 陶化喷淋泵压力值, 陶化PH值, 精洗喷淋泵压力值, 粗洗喷淋泵压力值, 水分炉测量温度, 固化炉测量温度, 厂内温度, 厂内湿度 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_Data.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_Data.EnableHeadersVisualStyles = false;
            dgv_Data.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_Data.GridColor = Color.FromArgb(80, 160, 255);
            dgv_Data.Location = new Point(12, 136);
            dgv_Data.Name = "dgv_Data";
            dgv_Data.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_Data.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_Data.RowHeadersWidth = 20;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_Data.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv_Data.SelectedIndex = -1;
            dgv_Data.Size = new Size(1484, 631);
            dgv_Data.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_Data.TabIndex = 3;
            // 
            // 脱脂喷淋泵压力值
            // 
            脱脂喷淋泵压力值.DataPropertyName = "脱脂喷淋泵压力值";
            脱脂喷淋泵压力值.HeaderText = "脱脂喷淋泵压力值";
            脱脂喷淋泵压力值.MinimumWidth = 10;
            脱脂喷淋泵压力值.Name = "脱脂喷淋泵压力值";
            脱脂喷淋泵压力值.ReadOnly = true;
            脱脂喷淋泵压力值.Width = 148;
            // 
            // 脱脂pH值
            // 
            脱脂pH值.DataPropertyName = "脱脂pH值";
            脱脂pH值.HeaderText = "脱脂pH值";
            脱脂pH值.MinimumWidth = 10;
            脱脂pH值.Name = "脱脂pH值";
            脱脂pH值.ReadOnly = true;
            脱脂pH值.Width = 148;
            // 
            // 陶化喷淋泵压力值
            // 
            陶化喷淋泵压力值.DataPropertyName = "陶化喷淋泵压力值";
            陶化喷淋泵压力值.HeaderText = "陶化喷淋泵压力值";
            陶化喷淋泵压力值.MinimumWidth = 10;
            陶化喷淋泵压力值.Name = "陶化喷淋泵压力值";
            陶化喷淋泵压力值.ReadOnly = true;
            陶化喷淋泵压力值.Width = 148;
            // 
            // 陶化PH值
            // 
            陶化PH值.DataPropertyName = "陶化PH值";
            陶化PH值.HeaderText = "陶化PH值";
            陶化PH值.MinimumWidth = 10;
            陶化PH值.Name = "陶化PH值";
            陶化PH值.ReadOnly = true;
            陶化PH值.Width = 148;
            // 
            // 精洗喷淋泵压力值
            // 
            精洗喷淋泵压力值.DataPropertyName = "精洗喷淋泵压力值";
            精洗喷淋泵压力值.HeaderText = "精洗喷淋泵压力值";
            精洗喷淋泵压力值.MinimumWidth = 10;
            精洗喷淋泵压力值.Name = "精洗喷淋泵压力值";
            精洗喷淋泵压力值.ReadOnly = true;
            精洗喷淋泵压力值.Width = 148;
            // 
            // 粗洗喷淋泵压力值
            // 
            粗洗喷淋泵压力值.DataPropertyName = "粗洗喷淋泵压力值";
            粗洗喷淋泵压力值.HeaderText = "粗洗喷淋泵压力值";
            粗洗喷淋泵压力值.MinimumWidth = 10;
            粗洗喷淋泵压力值.Name = "粗洗喷淋泵压力值";
            粗洗喷淋泵压力值.ReadOnly = true;
            粗洗喷淋泵压力值.Width = 148;
            // 
            // 水分炉测量温度
            // 
            水分炉测量温度.DataPropertyName = "水分炉测量温度";
            水分炉测量温度.HeaderText = "水分炉测量温度";
            水分炉测量温度.MinimumWidth = 10;
            水分炉测量温度.Name = "水分炉测量温度";
            水分炉测量温度.ReadOnly = true;
            水分炉测量温度.Width = 148;
            // 
            // 固化炉测量温度
            // 
            固化炉测量温度.DataPropertyName = "固化炉测量温度";
            固化炉测量温度.HeaderText = "固化炉测量温度";
            固化炉测量温度.MinimumWidth = 10;
            固化炉测量温度.Name = "固化炉测量温度";
            固化炉测量温度.ReadOnly = true;
            固化炉测量温度.Width = 148;
            // 
            // 厂内温度
            // 
            厂内温度.DataPropertyName = "厂内温度";
            厂内温度.HeaderText = "厂内温度";
            厂内温度.MinimumWidth = 10;
            厂内温度.Name = "厂内温度";
            厂内温度.ReadOnly = true;
            厂内温度.Width = 148;
            // 
            // 厂内湿度
            // 
            厂内湿度.DataPropertyName = "厂内湿度";
            厂内湿度.HeaderText = "厂内湿度";
            厂内湿度.MinimumWidth = 10;
            厂内湿度.Name = "厂内湿度";
            厂内湿度.ReadOnly = true;
            厂内湿度.Width = 148;
            // 
            // uiPagination1
            // 
            uiPagination1.ButtonFillSelectedColor = Color.FromArgb(64, 128, 204);
            uiPagination1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPagination1.Location = new Point(13, 775);
            uiPagination1.Margin = new Padding(4, 5, 4, 5);
            uiPagination1.MinimumSize = new Size(1, 1);
            uiPagination1.Name = "uiPagination1";
            uiPagination1.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPagination1.ShowText = false;
            uiPagination1.Size = new Size(1067, 42);
            uiPagination1.TabIndex = 4;
            uiPagination1.Text = "uiPagination1";
            uiPagination1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // PageReportManage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(uiPagination1);
            Controls.Add(dgv_Data);
            Controls.Add(btn_ExportData);
            Controls.Add(btn_QueryData);
            Controls.Add(dtp_End);
            Controls.Add(dtp_Start);
            Controls.Add(uiSymbolLabel2);
            Controls.Add(uiSymbolLabel1);
            Name = "PageReportManage";
            Symbol = 57586;
            Text = "报表管理";
            ((System.ComponentModel.ISupportInitialize)dgv_Data).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
        private Sunny.UI.UIDatetimePicker dtp_Start;
        private Sunny.UI.UISymbolLabel uiSymbolLabel2;
        private Sunny.UI.UIDatetimePicker dtp_End;
        private Sunny.UI.UISymbolButton btn_QueryData;
        private Sunny.UI.UISymbolButton btn_ExportData;
        private Sunny.UI.UIDataGridView dgv_Data;
        private DataGridViewTextBoxColumn 脱脂喷淋泵压力值;
        private DataGridViewTextBoxColumn 脱脂pH值;
        private DataGridViewTextBoxColumn 陶化喷淋泵压力值;
        private DataGridViewTextBoxColumn 陶化PH值;
        private DataGridViewTextBoxColumn 精洗喷淋泵压力值;
        private DataGridViewTextBoxColumn 粗洗喷淋泵压力值;
        private DataGridViewTextBoxColumn 水分炉测量温度;
        private DataGridViewTextBoxColumn 固化炉测量温度;
        private DataGridViewTextBoxColumn 厂内温度;
        private DataGridViewTextBoxColumn 厂内湿度;
        private Sunny.UI.UIPagination uiPagination1;
    }
}