namespace SprayProcessSCADASystemOnWinform {
    partial class UserSetValue {
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
            txt_Value = new Sunny.UI.UITextBox();
            lbl_Name = new Sunny.UI.UILabel();
            lbl_Unit = new Sunny.UI.UILabel();
            uiTableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 3;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            uiTableLayoutPanel1.Controls.Add(txt_Value, 1, 0);
            uiTableLayoutPanel1.Controls.Add(lbl_Name, 0, 0);
            uiTableLayoutPanel1.Controls.Add(lbl_Unit, 2, 0);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 1;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Size = new Size(470, 90);
            uiTableLayoutPanel1.TabIndex = 2;
            uiTableLayoutPanel1.TagString = null;
            // 
            // txt_Value
            // 
            txt_Value.Dock = DockStyle.Fill;
            txt_Value.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_Value.Location = new Point(224, 5);
            txt_Value.Margin = new Padding(4, 5, 4, 5);
            txt_Value.MinimumSize = new Size(1, 16);
            txt_Value.Name = "txt_Value";
            txt_Value.Padding = new Padding(5);
            txt_Value.ShowText = false;
            txt_Value.Size = new Size(142, 80);
            txt_Value.TabIndex = 4;
            txt_Value.TextAlignment = ContentAlignment.MiddleCenter;
            txt_Value.Watermark = "";
            txt_Value.TextChanged += txt_Value_TextChanged;
            // 
            // lbl_Name
            // 
            lbl_Name.Dock = DockStyle.Fill;
            lbl_Name.Font = new Font("微软雅黑", 10F);
            lbl_Name.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_Name.Location = new Point(3, 0);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(214, 90);
            lbl_Name.TabIndex = 0;
            lbl_Name.Text = "参数名称";
            lbl_Name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Unit
            // 
            lbl_Unit.Dock = DockStyle.Fill;
            lbl_Unit.Font = new Font("微软雅黑", 10F);
            lbl_Unit.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_Unit.Location = new Point(373, 0);
            lbl_Unit.Name = "lbl_Unit";
            lbl_Unit.Size = new Size(94, 90);
            lbl_Unit.TabIndex = 2;
            lbl_Unit.Text = "单位";
            lbl_Unit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserSetValue
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(uiTableLayoutPanel1);
            Name = "UserSetValue";
            Size = new Size(470, 90);
            uiTableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel lbl_Name;
        private Sunny.UI.UILabel lbl_Unit;
        private Sunny.UI.UITextBox txt_Value;
    }
}
