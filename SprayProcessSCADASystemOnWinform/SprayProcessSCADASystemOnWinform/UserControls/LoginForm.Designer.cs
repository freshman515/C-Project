namespace SprayProcessSCADASystemOnWinform.UserControls {
    partial class LoginForm {
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
            uiLabel1 = new Sunny.UI.UILabel();
            uiButton1 = new Sunny.UI.UIButton();
            txt_UserName = new Sunny.UI.UITextBox();
            txt_Password = new Sunny.UI.UITextBox();
            uiButton2 = new Sunny.UI.UIButton();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            pictureBox2 = new PictureBox();
            uiLabel2 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("华文新魏", 19.8749981F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel1.ForeColor = Color.Black;
            uiLabel1.Location = new Point(226, 37);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(621, 77);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "喷涂工艺系统登录界面";
            // 
            // uiButton1
            // 
            uiButton1.BackColor = Color.Transparent;
            uiButton1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Location = new Point(287, 471);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Radius = 40;
            uiButton1.Size = new Size(200, 70);
            uiButton1.TabIndex = 1;
            uiButton1.Text = "登录";
            uiButton1.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.Click += uiButton1_Click;
            // 
            // txt_UserName
            // 
            txt_UserName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_UserName.Location = new Point(443, 274);
            txt_UserName.Margin = new Padding(4, 5, 4, 5);
            txt_UserName.MinimumSize = new Size(1, 16);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Padding = new Padding(5);
            txt_UserName.ShowText = false;
            txt_UserName.Size = new Size(300, 58);
            txt_UserName.TabIndex = 2;
            txt_UserName.TextAlignment = ContentAlignment.MiddleLeft;
            txt_UserName.Watermark = "请输入用户名";
            // 
            // txt_Password
            // 
            txt_Password.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_Password.Location = new Point(443, 352);
            txt_Password.Margin = new Padding(4, 5, 4, 5);
            txt_Password.MinimumSize = new Size(1, 16);
            txt_Password.Name = "txt_Password";
            txt_Password.Padding = new Padding(5);
            txt_Password.ShowText = false;
            txt_Password.Size = new Size(300, 58);
            txt_Password.TabIndex = 3;
            txt_Password.TextAlignment = ContentAlignment.MiddleLeft;
            txt_Password.Watermark = "请输入密码";
            // 
            // uiButton2
            // 
            uiButton2.BackColor = Color.Transparent;
            uiButton2.FillColor = Color.Brown;
            uiButton2.FillPressColor = Color.FromArgb(192, 0, 0);
            uiButton2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Location = new Point(543, 471);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.Radius = 40;
            uiButton2.Size = new Size(200, 70);
            uiButton2.TabIndex = 1;
            uiButton2.Text = "取消";
            uiButton2.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.Click += uiButton2_Click;
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.Transparent;
            uiLabel3.Font = new Font("微软雅黑", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(287, 274);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(147, 52);
            uiLabel3.TabIndex = 0;
            uiLabel3.Text = "用户名：";
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = Color.Transparent;
            uiLabel4.Font = new Font("微软雅黑", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(287, 352);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(132, 52);
            uiLabel4.TabIndex = 0;
            uiLabel4.Text = "密码：";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.用户;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(492, 117);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(69, 71);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("微软雅黑", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(443, 200);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(200, 46);
            uiLabel2.TabIndex = 6;
            uiLabel2.Text = "用户登录";
            // 
            // LoginForm
            // 
            AllowShowTitle = false;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1041, 634);
            Controls.Add(uiLabel2);
            Controls.Add(pictureBox2);
            Controls.Add(txt_Password);
            Controls.Add(txt_UserName);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel1);
            Name = "LoginForm";
            Padding = new Padding(0);
            ShowTitle = false;
            Text = "登录界面";
            TitleHeight = 50;
            ZoomScaleRect = new Rectangle(30, 30, 800, 450);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UITextBox txt_UserName;
        private Sunny.UI.UITextBox txt_Password;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private PictureBox pictureBox2;
        private Sunny.UI.UILabel uiLabel2;
    }
}