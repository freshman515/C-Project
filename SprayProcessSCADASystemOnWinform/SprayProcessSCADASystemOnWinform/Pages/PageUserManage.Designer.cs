namespace SprayProcessSCADASystemOnWinform {
    partial class PageUserManage {
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
            uiLabel1 = new Sunny.UI.UILabel();
            txt_UserName = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            txt_EnterPassword = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            txt_Password = new Sunny.UI.UITextBox();
            btn_AddUser = new Sunny.UI.UISymbolButton();
            btn_Update = new Sunny.UI.UISymbolButton();
            btn_Delete = new Sunny.UI.UISymbolButton();
            dgv_User = new Sunny.UI.UIDataGridView();
            Id = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            UserPassword = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            cb_Auth = new Sunny.UI.UIComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_User).BeginInit();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(44, 38);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(147, 52);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "用户名称";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_UserName
            // 
            txt_UserName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_UserName.Location = new Point(198, 38);
            txt_UserName.Margin = new Padding(4, 5, 4, 5);
            txt_UserName.MinimumSize = new Size(1, 16);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Padding = new Padding(5);
            txt_UserName.ShowText = false;
            txt_UserName.Size = new Size(300, 58);
            txt_UserName.TabIndex = 1;
            txt_UserName.TextAlignment = ContentAlignment.MiddleLeft;
            txt_UserName.Watermark = "用户名称";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(44, 123);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(147, 52);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "用户名称";
            uiLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(44, 123);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(147, 52);
            uiLabel3.TabIndex = 0;
            uiLabel3.Text = "用户密码";
            uiLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(44, 207);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(147, 52);
            uiLabel4.TabIndex = 0;
            uiLabel4.Text = "确认密码";
            uiLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_EnterPassword
            // 
            txt_EnterPassword.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_EnterPassword.Location = new Point(198, 207);
            txt_EnterPassword.Margin = new Padding(4, 5, 4, 5);
            txt_EnterPassword.MinimumSize = new Size(1, 16);
            txt_EnterPassword.Name = "txt_EnterPassword";
            txt_EnterPassword.Padding = new Padding(5);
            txt_EnterPassword.ShowText = false;
            txt_EnterPassword.Size = new Size(300, 58);
            txt_EnterPassword.TabIndex = 1;
            txt_EnterPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txt_EnterPassword.Watermark = "确认密码";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(44, 295);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(147, 52);
            uiLabel5.TabIndex = 0;
            uiLabel5.Text = "权限选择";
            uiLabel5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_Password
            // 
            txt_Password.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_Password.Location = new Point(198, 123);
            txt_Password.Margin = new Padding(4, 5, 4, 5);
            txt_Password.MinimumSize = new Size(1, 16);
            txt_Password.Name = "txt_Password";
            txt_Password.Padding = new Padding(5);
            txt_Password.ShowText = false;
            txt_Password.Size = new Size(300, 58);
            txt_Password.TabIndex = 1;
            txt_Password.TextAlignment = ContentAlignment.MiddleLeft;
            txt_Password.Watermark = "用户密码";
            // 
            // btn_AddUser
            // 
            btn_AddUser.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_AddUser.Location = new Point(84, 385);
            btn_AddUser.MinimumSize = new Size(1, 1);
            btn_AddUser.Name = "btn_AddUser";
            btn_AddUser.Size = new Size(378, 85);
            btn_AddUser.Symbol = 561285;
            btn_AddUser.SymbolSize = 45;
            btn_AddUser.TabIndex = 2;
            btn_AddUser.Text = "添加用户";
            btn_AddUser.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_AddUser.Click += btn_AddUser_Click;
            // 
            // btn_Update
            // 
            btn_Update.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_Update.Location = new Point(84, 505);
            btn_Update.MinimumSize = new Size(1, 1);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(378, 87);
            btn_Update.Symbol = 561286;
            btn_Update.SymbolSize = 45;
            btn_Update.TabIndex = 2;
            btn_Update.Text = "修改用户";
            btn_Update.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // btn_Delete
            // 
            btn_Delete.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_Delete.Location = new Point(84, 628);
            btn_Delete.MinimumSize = new Size(1, 1);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(378, 89);
            btn_Delete.Symbol = 561286;
            btn_Delete.SymbolSize = 45;
            btn_Delete.TabIndex = 2;
            btn_Delete.Text = "删除用户";
            btn_Delete.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            // 
            // dgv_User
            // 
            dgv_User.AllowUserToAddRows = false;
            dgv_User.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgv_User.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_User.BackgroundColor = Color.White;
            dgv_User.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_User.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_User.ColumnHeadersHeight = 50;
            dgv_User.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_User.Columns.AddRange(new DataGridViewColumn[] { Id, UserName, UserPassword, Role });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_User.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_User.EnableHeadersVisualStyles = false;
            dgv_User.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_User.GridColor = Color.FromArgb(80, 160, 255);
            dgv_User.Location = new Point(520, 38);
            dgv_User.Name = "dgv_User";
            dgv_User.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_User.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_User.RowHeadersWidth = 82;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_User.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv_User.SelectedIndex = -1;
            dgv_User.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_User.Size = new Size(947, 775);
            dgv_User.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_User.TabIndex = 3;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 10;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 200;
            // 
            // UserName
            // 
            UserName.DataPropertyName = "UserName";
            UserName.HeaderText = "用户名";
            UserName.MinimumWidth = 10;
            UserName.Name = "UserName";
            UserName.ReadOnly = true;
            UserName.Width = 280;
            // 
            // UserPassword
            // 
            UserPassword.DataPropertyName = "UserPassword";
            UserPassword.HeaderText = "密码";
            UserPassword.MinimumWidth = 10;
            UserPassword.Name = "UserPassword";
            UserPassword.ReadOnly = true;
            UserPassword.Width = 290;
            // 
            // Role
            // 
            Role.DataPropertyName = "Role";
            Role.HeaderText = "角色";
            Role.MinimumWidth = 10;
            Role.Name = "Role";
            Role.ReadOnly = true;
            Role.Width = 290;
            // 
            // cb_Auth
            // 
            cb_Auth.DataSource = null;
            cb_Auth.FillColor = Color.White;
            cb_Auth.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cb_Auth.ItemHeight = 40;
            cb_Auth.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cb_Auth.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cb_Auth.Location = new Point(198, 295);
            cb_Auth.Margin = new Padding(4, 5, 4, 5);
            cb_Auth.MinimumSize = new Size(63, 0);
            cb_Auth.Name = "cb_Auth";
            cb_Auth.Padding = new Padding(0, 0, 30, 2);
            cb_Auth.Size = new Size(300, 58);
            cb_Auth.SymbolSize = 24;
            cb_Auth.TabIndex = 4;
            cb_Auth.TextAlignment = ContentAlignment.MiddleLeft;
            cb_Auth.Watermark = "权限选择";
            // 
            // PageUserManage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(cb_Auth);
            Controls.Add(dgv_User);
            Controls.Add(btn_Delete);
            Controls.Add(btn_Update);
            Controls.Add(btn_AddUser);
            Controls.Add(uiLabel5);
            Controls.Add(txt_EnterPassword);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(txt_Password);
            Controls.Add(txt_UserName);
            Controls.Add(uiLabel1);
            Name = "PageUserManage";
            Symbol = 561285;
            Text = "添加用户";
            ((System.ComponentModel.ISupportInitialize)dgv_User).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txt_UserName;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txt_EnterPassword;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txt_Password;
        private Sunny.UI.UISymbolButton btn_AddUser;
        private Sunny.UI.UISymbolButton btn_Update;
        private Sunny.UI.UISymbolButton btn_Delete;
        private Sunny.UI.UIDataGridView dgv_User;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn UserPassword;
        private DataGridViewTextBoxColumn Role;
        private Sunny.UI.UIComboBox cb_Auth;
    }
}