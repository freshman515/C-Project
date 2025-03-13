namespace SprayProcessSCADASystemOnWinform {
    partial class UserAlarmState {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            lbl_AlarmName = new Sunny.UI.UILabel();
            lbl_AlarmState = new Sunny.UI.UISymbolLabel();
            uiTableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 2;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            uiTableLayoutPanel1.Controls.Add(lbl_AlarmName, 0, 0);
            uiTableLayoutPanel1.Controls.Add(lbl_AlarmState, 1, 0);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 1;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Size = new Size(360, 90);
            uiTableLayoutPanel1.TabIndex = 3;
            uiTableLayoutPanel1.TagString = null;
            // 
            // lbl_AlarmName
            // 
            lbl_AlarmName.BackColor = Color.Transparent;
            lbl_AlarmName.Dock = DockStyle.Fill;
            lbl_AlarmName.Font = new Font("微软雅黑", 11F);
            lbl_AlarmName.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_AlarmName.Location = new Point(3, 0);
            lbl_AlarmName.Name = "lbl_AlarmName";
            lbl_AlarmName.Size = new Size(274, 90);
            lbl_AlarmName.TabIndex = 2;
            lbl_AlarmName.Text = "报警名称";
            lbl_AlarmName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_AlarmState
            // 
            lbl_AlarmState.Dock = DockStyle.Fill;
            lbl_AlarmState.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbl_AlarmState.Location = new Point(283, 3);
            lbl_AlarmState.MinimumSize = new Size(1, 1);
            lbl_AlarmState.Name = "lbl_AlarmState";
            lbl_AlarmState.Size = new Size(74, 84);
            lbl_AlarmState.Style = Sunny.UI.UIStyle.Custom;
            lbl_AlarmState.Symbol = 61683;
            lbl_AlarmState.SymbolColor = Color.Red;
            lbl_AlarmState.SymbolSize = 75;
            lbl_AlarmState.TabIndex = 3;
            // 
            // UserAlarmState
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(uiTableLayoutPanel1);
            Name = "UserAlarmState";
            RectColor = Color.Transparent;
            Size = new Size(360, 90);
            uiTableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel lbl_AlarmName;
        private Sunny.UI.UISymbolLabel lbl_AlarmState;
    }
}
