namespace SprayProcessSCADASystemOnWinform {
    partial class FrmLogin {
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
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(44, 2);
            lblTitle.Size = new Size(694, 63);
            lblTitle.Text = "登录界面";
            // 
            // uiPanel1
            // 
            uiPanel1.Location = new Point(656, 197);
            uiPanel1.Size = new Size(216, 255);
            // 
            // lblSubText
            // 
            lblSubText.Location = new Point(626, 421);
            lblSubText.Size = new Size(315, 31);
            // 
            // FrmLogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1000, 592);
            MaximumSize = new Size(1000, 1000);
            Name = "FrmLogin";
            Text = "FrmLogin";
            Title = "登录界面";
            ButtonLoginClick += FrmLogin_ButtonLoginClick;
            ResumeLayout(false);
        }

        #endregion
    }
}