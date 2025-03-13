namespace SprayProcessSCADASystemOnWinform {
    partial class PageAuthManage {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageAuthManage));
            cbg_Engineer = new Sunny.UI.UICheckBoxGroup();
            cbg_Operator = new Sunny.UI.UICheckBoxGroup();
            cbg_Visitor = new Sunny.UI.UICheckBoxGroup();
            btn_UpdateEngAuth = new Sunny.UI.UIButton();
            btn_UpdateOpAuth = new Sunny.UI.UIButton();
            btn_UpdateVisitorAuth = new Sunny.UI.UIButton();
            uiLabel1 = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // cbg_Engineer
            // 
            cbg_Engineer.CheckBoxSize = 35;
            cbg_Engineer.ColumnInterval = 20;
            cbg_Engineer.Font = new Font("微软雅黑", 15F);
            cbg_Engineer.HoverColor = Color.FromArgb(220, 236, 255);
            cbg_Engineer.Items.AddRange(new object[] { "控制模块", "监控模块", "配方模块", "日志模块", "报表模块", "图标模块", "参数模块" });
            cbg_Engineer.Location = new Point(43, 140);
            cbg_Engineer.Margin = new Padding(4, 5, 4, 5);
            cbg_Engineer.MinimumSize = new Size(1, 1);
            cbg_Engineer.Name = "cbg_Engineer";
            cbg_Engineer.Padding = new Padding(0, 66, 0, 0);
            cbg_Engineer.RowInterval = 50;
            cbg_Engineer.SelectedIndexes = (List<int>)resources.GetObject("cbg_Engineer.SelectedIndexes");
            cbg_Engineer.Size = new Size(346, 653);
            cbg_Engineer.StartPos = new Point(40, 70);
            cbg_Engineer.TabIndex = 0;
            cbg_Engineer.Text = "工程师权限";
            cbg_Engineer.TextAlignment = ContentAlignment.MiddleCenter;
            cbg_Engineer.TitleInterval = 40;
            cbg_Engineer.TitleTop = 30;
            // 
            // cbg_Operator
            // 
            cbg_Operator.CheckBoxSize = 35;
            cbg_Operator.ColumnInterval = 20;
            cbg_Operator.Font = new Font("微软雅黑", 15F);
            cbg_Operator.HoverColor = Color.FromArgb(220, 236, 255);
            cbg_Operator.Items.AddRange(new object[] { "控制模块", "监控模块", "配方模块", "日志模块", "报表模块", "图标模块", "参数模块" });
            cbg_Operator.Location = new Point(434, 140);
            cbg_Operator.Margin = new Padding(4, 5, 4, 5);
            cbg_Operator.MinimumSize = new Size(1, 1);
            cbg_Operator.Name = "cbg_Operator";
            cbg_Operator.Padding = new Padding(0, 66, 0, 0);
            cbg_Operator.RowInterval = 50;
            cbg_Operator.SelectedIndexes = (List<int>)resources.GetObject("cbg_Operator.SelectedIndexes");
            cbg_Operator.Size = new Size(346, 653);
            cbg_Operator.StartPos = new Point(40, 70);
            cbg_Operator.TabIndex = 0;
            cbg_Operator.Text = "操作员权限";
            cbg_Operator.TextAlignment = ContentAlignment.MiddleCenter;
            cbg_Operator.TitleInterval = 40;
            cbg_Operator.TitleTop = 30;
            // 
            // cbg_Visitor
            // 
            cbg_Visitor.CheckBoxSize = 35;
            cbg_Visitor.ColumnInterval = 20;
            cbg_Visitor.Font = new Font("微软雅黑", 15F);
            cbg_Visitor.HoverColor = Color.FromArgb(220, 236, 255);
            cbg_Visitor.Items.AddRange(new object[] { "控制模块", "监控模块", "配方模块", "日志模块", "报表模块", "图标模块", "参数模块" });
            cbg_Visitor.Location = new Point(817, 140);
            cbg_Visitor.Margin = new Padding(4, 5, 4, 5);
            cbg_Visitor.MinimumSize = new Size(1, 1);
            cbg_Visitor.Name = "cbg_Visitor";
            cbg_Visitor.Padding = new Padding(0, 66, 0, 0);
            cbg_Visitor.RowInterval = 50;
            cbg_Visitor.SelectedIndexes = (List<int>)resources.GetObject("cbg_Visitor.SelectedIndexes");
            cbg_Visitor.Size = new Size(346, 653);
            cbg_Visitor.StartPos = new Point(40, 70);
            cbg_Visitor.TabIndex = 0;
            cbg_Visitor.Text = "访客权限";
            cbg_Visitor.TextAlignment = ContentAlignment.MiddleCenter;
            cbg_Visitor.TitleInterval = 40;
            cbg_Visitor.TitleTop = 30;
            // 
            // btn_UpdateEngAuth
            // 
            btn_UpdateEngAuth.Font = new Font("微软雅黑", 13F);
            btn_UpdateEngAuth.Location = new Point(1189, 162);
            btn_UpdateEngAuth.MinimumSize = new Size(1, 1);
            btn_UpdateEngAuth.Name = "btn_UpdateEngAuth";
            btn_UpdateEngAuth.Size = new Size(307, 134);
            btn_UpdateEngAuth.TabIndex = 1;
            btn_UpdateEngAuth.Text = "修改工程师权限";
            btn_UpdateEngAuth.TipsFont = new Font("宋体", 11F);
            // 
            // btn_UpdateOpAuth
            // 
            btn_UpdateOpAuth.Font = new Font("微软雅黑", 13F);
            btn_UpdateOpAuth.Location = new Point(1189, 412);
            btn_UpdateOpAuth.MinimumSize = new Size(1, 1);
            btn_UpdateOpAuth.Name = "btn_UpdateOpAuth";
            btn_UpdateOpAuth.Size = new Size(307, 137);
            btn_UpdateOpAuth.TabIndex = 1;
            btn_UpdateOpAuth.Text = "修改操作员权限";
            btn_UpdateOpAuth.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btn_UpdateVisitorAuth
            // 
            btn_UpdateVisitorAuth.Font = new Font("微软雅黑", 13F);
            btn_UpdateVisitorAuth.Location = new Point(1189, 665);
            btn_UpdateVisitorAuth.MinimumSize = new Size(1, 1);
            btn_UpdateVisitorAuth.Name = "btn_UpdateVisitorAuth";
            btn_UpdateVisitorAuth.Size = new Size(307, 128);
            btn_UpdateVisitorAuth.TabIndex = 1;
            btn_UpdateVisitorAuth.Text = "修改访客权限";
            btn_UpdateVisitorAuth.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(66, 18);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(922, 83);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "温馨提示：管理员开放所有权限，用户权限只有管理员可以更改";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PageAuthManage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(uiLabel1);
            Controls.Add(btn_UpdateVisitorAuth);
            Controls.Add(btn_UpdateOpAuth);
            Controls.Add(btn_UpdateEngAuth);
            Controls.Add(cbg_Visitor);
            Controls.Add(cbg_Operator);
            Controls.Add(cbg_Engineer);
            Name = "PageAuthManage";
            Symbol = 362722;
            Text = "权限管理";
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UICheckBoxGroup cbg_Engineer;
        private Sunny.UI.UICheckBoxGroup cbg_Operator;
        private Sunny.UI.UICheckBoxGroup cbg_Visitor;
        private Sunny.UI.UIButton btn_UpdateEngAuth;
        private Sunny.UI.UIButton btn_UpdateOpAuth;
        private Sunny.UI.UIButton btn_UpdateVisitorAuth;
        private Sunny.UI.UILabel uiLabel1;
    }
}