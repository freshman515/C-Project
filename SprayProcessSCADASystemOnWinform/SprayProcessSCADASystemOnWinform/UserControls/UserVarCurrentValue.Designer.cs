namespace SprayProcessSCADASystemOnWinform {
    partial class UserVarCurrentValue {
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
            lbl_Name = new Sunny.UI.UILabel();
            lbl_Unit = new Sunny.UI.UILabel();
            dl_Value = new Sunny.UI.UIDigitalLabel();
            uiTableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 3;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel1.Controls.Add(dl_Value, 1, 0);
            uiTableLayoutPanel1.Controls.Add(lbl_Name, 0, 0);
            uiTableLayoutPanel1.Controls.Add(lbl_Unit, 2, 0);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 1;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Size = new Size(470, 90);
            uiTableLayoutPanel1.TabIndex = 3;
            uiTableLayoutPanel1.TagString = null;
            // 
            // lbl_Name
            // 
            lbl_Name.Dock = DockStyle.Fill;
            lbl_Name.Font = new Font("微软雅黑", 11F);
            lbl_Name.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_Name.Location = new Point(3, 0);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(179, 90);
            lbl_Name.TabIndex = 0;
            lbl_Name.Text = "名称";
            lbl_Name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Unit
            // 
            lbl_Unit.Dock = DockStyle.Fill;
            lbl_Unit.Font = new Font("微软雅黑", 11F);
            lbl_Unit.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_Unit.Location = new Point(373, 0);
            lbl_Unit.Name = "lbl_Unit";
            lbl_Unit.Size = new Size(94, 90);
            lbl_Unit.TabIndex = 2;
            lbl_Unit.Text = "单位";
            lbl_Unit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dl_Value
            // 
            dl_Value.BackColor = Color.Transparent;
            dl_Value.DecimalPlaces = 1;
            dl_Value.DigitalSize = 23;
            dl_Value.Dock = DockStyle.Fill;
            dl_Value.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dl_Value.ForeColor = Color.DeepSkyBlue;
            dl_Value.Location = new Point(188, 3);
            dl_Value.MinimumSize = new Size(1, 1);
            dl_Value.Name = "dl_Value";
            dl_Value.Size = new Size(179, 84);
            dl_Value.TabIndex = 3;
            dl_Value.Text = "uiDigitalLabel1";
            dl_Value.TextAlign = HorizontalAlignment.Center;
            // 
            // UserVarCurrentValue
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(uiTableLayoutPanel1);
            Name = "UserVarCurrentValue";
            RectColor = Color.Transparent;
            Size = new Size(470, 90);
            uiTableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel lbl_Name;
        private Sunny.UI.UILabel lbl_Unit;
        private Sunny.UI.UIDigitalLabel dl_Value;
    }
}
