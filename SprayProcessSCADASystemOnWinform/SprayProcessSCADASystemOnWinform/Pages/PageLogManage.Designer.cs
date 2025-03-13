namespace SprayProcessSCADASystemOnWinform {
    partial class PageLogManage {
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            btn_ExportExcel = new Sunny.UI.UISymbolButton();
            btn_ShowToTXT = new Sunny.UI.UISymbolButton();
            btn_ShowToDgv = new Sunny.UI.UISymbolButton();
            btn_OpenDire = new Sunny.UI.UISymbolButton();
            lb_Files = new Sunny.UI.UIListBox();
            cb_LogLev = new Sunny.UI.UIComboBox();
            cb_Date = new Sunny.UI.UIComboBox();
            uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            txt_ShowLog = new Sunny.UI.UITextBox();
            dgv_ShowLog = new Sunny.UI.UIDataGridView();
            uiTitlePanel1.SuspendLayout();
            uiTitlePanel2.SuspendLayout();
            uiTitlePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ShowLog).BeginInit();
            SuspendLayout();
            // 
            // uiTitlePanel1
            // 
            uiTitlePanel1.Controls.Add(btn_ExportExcel);
            uiTitlePanel1.Controls.Add(btn_ShowToTXT);
            uiTitlePanel1.Controls.Add(btn_ShowToDgv);
            uiTitlePanel1.Controls.Add(btn_OpenDire);
            uiTitlePanel1.Controls.Add(lb_Files);
            uiTitlePanel1.Controls.Add(cb_LogLev);
            uiTitlePanel1.Controls.Add(cb_Date);
            uiTitlePanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel1.Location = new Point(0, 0);
            uiTitlePanel1.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel1.MinimumSize = new Size(1, 1);
            uiTitlePanel1.Name = "uiTitlePanel1";
            uiTitlePanel1.Padding = new Padding(1, 50, 1, 1);
            uiTitlePanel1.ShowText = false;
            uiTitlePanel1.Size = new Size(489, 826);
            uiTitlePanel1.TabIndex = 0;
            uiTitlePanel1.Text = "日志控制台";
            uiTitlePanel1.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel1.TitleHeight = 50;
            // 
            // btn_ExportExcel
            // 
            btn_ExportExcel.Font = new Font("微软雅黑", 15F);
            btn_ExportExcel.Location = new Point(13, 720);
            btn_ExportExcel.MinimumSize = new Size(1, 1);
            btn_ExportExcel.Name = "btn_ExportExcel";
            btn_ExportExcel.Size = new Size(459, 100);
            btn_ExportExcel.Symbol = 361891;
            btn_ExportExcel.SymbolSize = 50;
            btn_ExportExcel.TabIndex = 3;
            btn_ExportExcel.Text = "日志导出Excel";
            btn_ExportExcel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btn_ShowToTXT
            // 
            btn_ShowToTXT.Font = new Font("微软雅黑", 15F);
            btn_ShowToTXT.Location = new Point(13, 609);
            btn_ShowToTXT.MinimumSize = new Size(1, 1);
            btn_ShowToTXT.Name = "btn_ShowToTXT";
            btn_ShowToTXT.Size = new Size(459, 94);
            btn_ShowToTXT.Symbol = 57381;
            btn_ShowToTXT.SymbolSize = 50;
            btn_ShowToTXT.TabIndex = 3;
            btn_ShowToTXT.Text = "日志导出TXT";
            btn_ShowToTXT.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btn_ShowToDgv
            // 
            btn_ShowToDgv.Font = new Font("微软雅黑", 15F);
            btn_ShowToDgv.Location = new Point(12, 495);
            btn_ShowToDgv.MinimumSize = new Size(1, 1);
            btn_ShowToDgv.Name = "btn_ShowToDgv";
            btn_ShowToDgv.Size = new Size(459, 97);
            btn_ShowToDgv.Symbol = 57381;
            btn_ShowToDgv.SymbolSize = 50;
            btn_ShowToDgv.TabIndex = 3;
            btn_ShowToDgv.Text = "显示到表格";
            btn_ShowToDgv.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btn_OpenDire
            // 
            btn_OpenDire.Font = new Font("微软雅黑", 15F);
            btn_OpenDire.Location = new Point(15, 383);
            btn_OpenDire.MinimumSize = new Size(1, 1);
            btn_OpenDire.Name = "btn_OpenDire";
            btn_OpenDire.Size = new Size(459, 95);
            btn_OpenDire.Symbol = 261564;
            btn_OpenDire.SymbolSize = 50;
            btn_OpenDire.TabIndex = 3;
            btn_OpenDire.Text = "打开日志目录";
            btn_OpenDire.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // lb_Files
            // 
            lb_Files.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lb_Files.HoverColor = Color.FromArgb(155, 200, 255);
            lb_Files.ItemSelectForeColor = Color.White;
            lb_Files.Location = new Point(15, 137);
            lb_Files.Margin = new Padding(4, 5, 4, 5);
            lb_Files.MinimumSize = new Size(1, 1);
            lb_Files.Name = "lb_Files";
            lb_Files.Padding = new Padding(2);
            lb_Files.ShowText = false;
            lb_Files.Size = new Size(456, 238);
            lb_Files.TabIndex = 2;
            lb_Files.Text = "uiListBox1";
            // 
            // cb_LogLev
            // 
            cb_LogLev.DataSource = null;
            cb_LogLev.FillColor = Color.White;
            cb_LogLev.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cb_LogLev.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cb_LogLev.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cb_LogLev.Location = new Point(247, 76);
            cb_LogLev.Margin = new Padding(4, 5, 4, 5);
            cb_LogLev.MinimumSize = new Size(63, 0);
            cb_LogLev.Name = "cb_LogLev";
            cb_LogLev.Padding = new Padding(0, 0, 30, 2);
            cb_LogLev.Size = new Size(227, 40);
            cb_LogLev.SymbolSize = 24;
            cb_LogLev.TabIndex = 1;
            cb_LogLev.TextAlignment = ContentAlignment.MiddleLeft;
            cb_LogLev.Watermark = "选择类型";
            // 
            // cb_Date
            // 
            cb_Date.DataSource = null;
            cb_Date.FillColor = Color.White;
            cb_Date.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cb_Date.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cb_Date.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cb_Date.Location = new Point(13, 75);
            cb_Date.Margin = new Padding(4, 5, 4, 5);
            cb_Date.MinimumSize = new Size(63, 0);
            cb_Date.Name = "cb_Date";
            cb_Date.Padding = new Padding(0, 0, 30, 2);
            cb_Date.Size = new Size(216, 41);
            cb_Date.SymbolSize = 24;
            cb_Date.TabIndex = 0;
            cb_Date.TextAlignment = ContentAlignment.MiddleLeft;
            cb_Date.Watermark = "选择日期";
            // 
            // uiTitlePanel2
            // 
            uiTitlePanel2.Controls.Add(txt_ShowLog);
            uiTitlePanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel2.Location = new Point(497, 0);
            uiTitlePanel2.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel2.MinimumSize = new Size(1, 1);
            uiTitlePanel2.Name = "uiTitlePanel2";
            uiTitlePanel2.Padding = new Padding(1, 35, 1, 1);
            uiTitlePanel2.ShowText = false;
            uiTitlePanel2.Size = new Size(476, 826);
            uiTitlePanel2.TabIndex = 0;
            uiTitlePanel2.Text = "文本显示";
            uiTitlePanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiTitlePanel3
            // 
            uiTitlePanel3.Controls.Add(dgv_ShowLog);
            uiTitlePanel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel3.Location = new Point(981, 0);
            uiTitlePanel3.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel3.MinimumSize = new Size(1, 1);
            uiTitlePanel3.Name = "uiTitlePanel3";
            uiTitlePanel3.Padding = new Padding(1, 35, 1, 1);
            uiTitlePanel3.ShowText = false;
            uiTitlePanel3.Size = new Size(527, 826);
            uiTitlePanel3.TabIndex = 0;
            uiTitlePanel3.Text = "表格显示";
            uiTitlePanel3.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // txt_ShowLog
            // 
            txt_ShowLog.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_ShowLog.Location = new Point(0, 36);
            txt_ShowLog.Margin = new Padding(4, 5, 4, 5);
            txt_ShowLog.MinimumSize = new Size(1, 16);
            txt_ShowLog.Multiline = true;
            txt_ShowLog.Name = "txt_ShowLog";
            txt_ShowLog.Padding = new Padding(5);
            txt_ShowLog.ShowText = false;
            txt_ShowLog.Size = new Size(476, 790);
            txt_ShowLog.TabIndex = 0;
            txt_ShowLog.TextAlignment = ContentAlignment.MiddleLeft;
            txt_ShowLog.Watermark = "";
            // 
            // dgv_ShowLog
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgv_ShowLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgv_ShowLog.BackgroundColor = Color.White;
            dgv_ShowLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgv_ShowLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgv_ShowLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgv_ShowLog.DefaultCellStyle = dataGridViewCellStyle8;
            dgv_ShowLog.EnableHeadersVisualStyles = false;
            dgv_ShowLog.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_ShowLog.GridColor = Color.FromArgb(80, 160, 255);
            dgv_ShowLog.Location = new Point(3, 38);
            dgv_ShowLog.Name = "dgv_ShowLog";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgv_ShowLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgv_ShowLog.RowHeadersWidth = 82;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_ShowLog.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgv_ShowLog.SelectedIndex = -1;
            dgv_ShowLog.Size = new Size(520, 788);
            dgv_ShowLog.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_ShowLog.TabIndex = 0;
            // 
            // PageLogManage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(uiTitlePanel3);
            Controls.Add(uiTitlePanel2);
            Controls.Add(uiTitlePanel1);
            Name = "PageLogManage";
            Symbol = 162333;
            Text = "日志管理";
            uiTitlePanel1.ResumeLayout(false);
            uiTitlePanel2.ResumeLayout(false);
            uiTitlePanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ShowLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private Sunny.UI.UIComboBox cb_Date;
        private Sunny.UI.UIComboBox cb_LogLev;
        private Sunny.UI.UIListBox lb_Files;
        private Sunny.UI.UISymbolButton btn_OpenDire;
        private Sunny.UI.UISymbolButton btn_ShowToDgv;
        private Sunny.UI.UISymbolButton btn_ShowToTXT;
        private Sunny.UI.UISymbolButton btn_ExportExcel;
        private Sunny.UI.UITextBox txt_ShowLog;
        private Sunny.UI.UIDataGridView dgv_ShowLog;
    }
}