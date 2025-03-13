namespace SprayProcessSCADASystemOnWinform {
    partial class PageSystemParameterSet {
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
            cb_CPUType = new Sunny.UI.UITitlePanel();
            txt_PLCVarAddressPath = new Sunny.UI.UITextBox();
            uiLabel11 = new Sunny.UI.UILabel();
            uiComboBox1 = new Sunny.UI.UIComboBox();
            txt_ReConnectTimeInterval = new Sunny.UI.UITextBox();
            txt_ConnectTimeOut = new Sunny.UI.UITextBox();
            txt_ReadTimeInterval = new Sunny.UI.UITextBox();
            txt_Slot = new Sunny.UI.UITextBox();
            txt_Rack = new Sunny.UI.UITextBox();
            txt_Port = new Sunny.UI.UITextBox();
            uiLabel10 = new Sunny.UI.UILabel();
            uiLabel8 = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            机架号 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            txt_IPAddress = new Sunny.UI.UIIPTextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            rbg_Save = new Sunny.UI.UIRadioButtonGroup();
            txt_DirePath = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            txt_SoftTime = new Sunny.UI.UITextBox();
            uiLabel9 = new Sunny.UI.UILabel();
            txt_SoftwareVersion = new Sunny.UI.UITextBox();
            uiLabel5 = new Sunny.UI.UILabel();
            btn_Save = new Sunny.UI.UIButton();
            cb_CPUType.SuspendLayout();
            uiTitlePanel2.SuspendLayout();
            uiTitlePanel3.SuspendLayout();
            SuspendLayout();
            // 
            // cb_CPUType
            // 
            cb_CPUType.Controls.Add(txt_PLCVarAddressPath);
            cb_CPUType.Controls.Add(uiLabel11);
            cb_CPUType.Controls.Add(uiComboBox1);
            cb_CPUType.Controls.Add(txt_ReConnectTimeInterval);
            cb_CPUType.Controls.Add(txt_ConnectTimeOut);
            cb_CPUType.Controls.Add(txt_ReadTimeInterval);
            cb_CPUType.Controls.Add(txt_Slot);
            cb_CPUType.Controls.Add(txt_Rack);
            cb_CPUType.Controls.Add(txt_Port);
            cb_CPUType.Controls.Add(uiLabel10);
            cb_CPUType.Controls.Add(uiLabel8);
            cb_CPUType.Controls.Add(uiLabel7);
            cb_CPUType.Controls.Add(uiLabel6);
            cb_CPUType.Controls.Add(机架号);
            cb_CPUType.Controls.Add(uiLabel4);
            cb_CPUType.Controls.Add(uiLabel3);
            cb_CPUType.Controls.Add(txt_IPAddress);
            cb_CPUType.Controls.Add(uiLabel1);
            cb_CPUType.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cb_CPUType.Location = new Point(13, 14);
            cb_CPUType.Margin = new Padding(4, 5, 4, 5);
            cb_CPUType.MinimumSize = new Size(1, 1);
            cb_CPUType.Name = "cb_CPUType";
            cb_CPUType.Padding = new Padding(1, 35, 1, 1);
            cb_CPUType.ShowText = false;
            cb_CPUType.Size = new Size(891, 510);
            cb_CPUType.TabIndex = 0;
            cb_CPUType.Text = "PLC参数";
            cb_CPUType.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // txt_PLCVarAddressPath
            // 
            txt_PLCVarAddressPath.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_PLCVarAddressPath.Location = new Point(252, 48);
            txt_PLCVarAddressPath.Margin = new Padding(4, 5, 4, 5);
            txt_PLCVarAddressPath.MinimumSize = new Size(1, 16);
            txt_PLCVarAddressPath.Name = "txt_PLCVarAddressPath";
            txt_PLCVarAddressPath.Padding = new Padding(5);
            txt_PLCVarAddressPath.ShowText = false;
            txt_PLCVarAddressPath.Size = new Size(627, 55);
            txt_PLCVarAddressPath.TabIndex = 5;
            txt_PLCVarAddressPath.TextAlignment = ContentAlignment.MiddleLeft;
            txt_PLCVarAddressPath.Watermark = "";
            // 
            // uiLabel11
            // 
            uiLabel11.Font = new Font("宋体", 10F);
            uiLabel11.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel11.Location = new Point(13, 61);
            uiLabel11.Name = "uiLabel11";
            uiLabel11.Size = new Size(232, 46);
            uiLabel11.TabIndex = 4;
            uiLabel11.Text = "PLC变量地址配置";
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.FillColor = Color.White;
            uiComboBox1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiComboBox1.ItemHoverColor = Color.FromArgb(155, 200, 255);
            uiComboBox1.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            uiComboBox1.Location = new Point(127, 260);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(270, 55);
            uiComboBox1.SymbolSize = 24;
            uiComboBox1.TabIndex = 3;
            uiComboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            // 
            // txt_ReConnectTimeInterval
            // 
            txt_ReConnectTimeInterval.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_ReConnectTimeInterval.Location = new Point(628, 260);
            txt_ReConnectTimeInterval.Margin = new Padding(4, 5, 4, 5);
            txt_ReConnectTimeInterval.MinimumSize = new Size(1, 16);
            txt_ReConnectTimeInterval.Name = "txt_ReConnectTimeInterval";
            txt_ReConnectTimeInterval.Padding = new Padding(5);
            txt_ReConnectTimeInterval.ShowText = false;
            txt_ReConnectTimeInterval.Size = new Size(251, 55);
            txt_ReConnectTimeInterval.TabIndex = 2;
            txt_ReConnectTimeInterval.TextAlignment = ContentAlignment.MiddleLeft;
            txt_ReConnectTimeInterval.Watermark = "";
            // 
            // txt_ConnectTimeOut
            // 
            txt_ConnectTimeOut.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_ConnectTimeOut.Location = new Point(628, 113);
            txt_ConnectTimeOut.Margin = new Padding(4, 5, 4, 5);
            txt_ConnectTimeOut.MinimumSize = new Size(1, 16);
            txt_ConnectTimeOut.Name = "txt_ConnectTimeOut";
            txt_ConnectTimeOut.Padding = new Padding(5);
            txt_ConnectTimeOut.ShowText = false;
            txt_ConnectTimeOut.Size = new Size(251, 55);
            txt_ConnectTimeOut.TabIndex = 2;
            txt_ConnectTimeOut.TextAlignment = ContentAlignment.MiddleLeft;
            txt_ConnectTimeOut.Watermark = "";
            // 
            // txt_ReadTimeInterval
            // 
            txt_ReadTimeInterval.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_ReadTimeInterval.Location = new Point(628, 184);
            txt_ReadTimeInterval.Margin = new Padding(4, 5, 4, 5);
            txt_ReadTimeInterval.MinimumSize = new Size(1, 16);
            txt_ReadTimeInterval.Name = "txt_ReadTimeInterval";
            txt_ReadTimeInterval.Padding = new Padding(5);
            txt_ReadTimeInterval.ShowText = false;
            txt_ReadTimeInterval.Size = new Size(251, 55);
            txt_ReadTimeInterval.TabIndex = 2;
            txt_ReadTimeInterval.TextAlignment = ContentAlignment.MiddleLeft;
            txt_ReadTimeInterval.Watermark = "";
            // 
            // txt_Slot
            // 
            txt_Slot.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_Slot.Location = new Point(127, 419);
            txt_Slot.Margin = new Padding(4, 5, 4, 5);
            txt_Slot.MinimumSize = new Size(1, 16);
            txt_Slot.Name = "txt_Slot";
            txt_Slot.Padding = new Padding(5);
            txt_Slot.ShowText = false;
            txt_Slot.Size = new Size(270, 55);
            txt_Slot.TabIndex = 2;
            txt_Slot.TextAlignment = ContentAlignment.MiddleLeft;
            txt_Slot.Watermark = "";
            // 
            // txt_Rack
            // 
            txt_Rack.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_Rack.Location = new Point(125, 341);
            txt_Rack.Margin = new Padding(4, 5, 4, 5);
            txt_Rack.MinimumSize = new Size(1, 16);
            txt_Rack.Name = "txt_Rack";
            txt_Rack.Padding = new Padding(5);
            txt_Rack.ShowText = false;
            txt_Rack.Size = new Size(272, 55);
            txt_Rack.TabIndex = 2;
            txt_Rack.TextAlignment = ContentAlignment.MiddleLeft;
            txt_Rack.Watermark = "";
            // 
            // txt_Port
            // 
            txt_Port.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_Port.Location = new Point(127, 187);
            txt_Port.Margin = new Padding(4, 5, 4, 5);
            txt_Port.MinimumSize = new Size(1, 16);
            txt_Port.Name = "txt_Port";
            txt_Port.Padding = new Padding(5);
            txt_Port.ShowText = false;
            txt_Port.Size = new Size(270, 55);
            txt_Port.TabIndex = 2;
            txt_Port.TextAlignment = ContentAlignment.MiddleLeft;
            txt_Port.Watermark = "";
            // 
            // uiLabel10
            // 
            uiLabel10.Font = new Font("宋体", 11F);
            uiLabel10.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel10.Location = new Point(438, 125);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new Size(190, 46);
            uiLabel10.TabIndex = 0;
            uiLabel10.Text = "PLC连接超时";
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new Font("宋体", 11F);
            uiLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new Point(470, 260);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(147, 46);
            uiLabel8.TabIndex = 0;
            uiLabel8.Text = "重连时间";
            // 
            // uiLabel7
            // 
            uiLabel7.Font = new Font("宋体", 11F);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Location = new Point(419, 196);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(200, 46);
            uiLabel7.TabIndex = 0;
            uiLabel7.Text = "读取时间间隔";
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("宋体", 11F);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(13, 430);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(200, 46);
            uiLabel6.TabIndex = 0;
            uiLabel6.Text = "插槽号";
            // 
            // 机架号
            // 
            机架号.Font = new Font("宋体", 11F);
            机架号.ForeColor = Color.FromArgb(48, 48, 48);
            机架号.Location = new Point(13, 353);
            机架号.Name = "机架号";
            机架号.Size = new Size(200, 46);
            机架号.TabIndex = 0;
            机架号.Text = "机架号";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("宋体", 11F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(13, 276);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(200, 46);
            uiLabel4.TabIndex = 0;
            uiLabel4.Text = "CPU类型";
            // 
            // uiLabel3
            // 
            uiLabel3.Font = new Font("宋体", 11F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(13, 199);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(200, 46);
            uiLabel3.TabIndex = 0;
            uiLabel3.Text = "端口号";
            // 
            // txt_IPAddress
            // 
            txt_IPAddress.FillColor2 = Color.FromArgb(235, 243, 255);
            txt_IPAddress.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_IPAddress.Location = new Point(127, 113);
            txt_IPAddress.Margin = new Padding(4, 5, 4, 5);
            txt_IPAddress.MinimumSize = new Size(1, 1);
            txt_IPAddress.Name = "txt_IPAddress";
            txt_IPAddress.Padding = new Padding(1);
            txt_IPAddress.ShowText = false;
            txt_IPAddress.Size = new Size(270, 55);
            txt_IPAddress.TabIndex = 1;
            txt_IPAddress.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 11F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(13, 122);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(200, 46);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "IP地址";
            // 
            // uiTitlePanel2
            // 
            uiTitlePanel2.Controls.Add(rbg_Save);
            uiTitlePanel2.Controls.Add(txt_DirePath);
            uiTitlePanel2.Controls.Add(uiLabel2);
            uiTitlePanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel2.Location = new Point(912, 14);
            uiTitlePanel2.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel2.MinimumSize = new Size(1, 1);
            uiTitlePanel2.Name = "uiTitlePanel2";
            uiTitlePanel2.Padding = new Padding(1, 35, 1, 1);
            uiTitlePanel2.ShowText = false;
            uiTitlePanel2.Size = new Size(540, 445);
            uiTitlePanel2.TabIndex = 1;
            uiTitlePanel2.Text = "定时清理Log";
            uiTitlePanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // rbg_Save
            // 
            rbg_Save.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            rbg_Save.Items.AddRange(new object[] { "不清理", "3天", "7天", "15天", "30天", "60天" });
            rbg_Save.Location = new Point(35, 124);
            rbg_Save.Margin = new Padding(4, 5, 4, 5);
            rbg_Save.MinimumSize = new Size(1, 1);
            rbg_Save.Name = "rbg_Save";
            rbg_Save.Padding = new Padding(0, 46, 0, 0);
            rbg_Save.RowInterval = 10;
            rbg_Save.Size = new Size(489, 296);
            rbg_Save.StartPos = new Point(12, 30);
            rbg_Save.TabIndex = 3;
            rbg_Save.Text = "定期清理";
            rbg_Save.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // txt_DirePath
            // 
            txt_DirePath.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_DirePath.Location = new Point(230, 66);
            txt_DirePath.Margin = new Padding(4, 5, 4, 5);
            txt_DirePath.MinimumSize = new Size(1, 16);
            txt_DirePath.Name = "txt_DirePath";
            txt_DirePath.Padding = new Padding(5);
            txt_DirePath.ShowText = false;
            txt_DirePath.Size = new Size(251, 55);
            txt_DirePath.TabIndex = 2;
            txt_DirePath.TextAlignment = ContentAlignment.MiddleLeft;
            txt_DirePath.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("宋体", 10F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(33, 75);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(200, 46);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "文件夹路径";
            // 
            // uiTitlePanel3
            // 
            uiTitlePanel3.Controls.Add(txt_SoftTime);
            uiTitlePanel3.Controls.Add(uiLabel9);
            uiTitlePanel3.Controls.Add(txt_SoftwareVersion);
            uiTitlePanel3.Controls.Add(uiLabel5);
            uiTitlePanel3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel3.Location = new Point(40, 534);
            uiTitlePanel3.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel3.MinimumSize = new Size(1, 1);
            uiTitlePanel3.Name = "uiTitlePanel3";
            uiTitlePanel3.Padding = new Padding(1, 35, 1, 1);
            uiTitlePanel3.ShowText = false;
            uiTitlePanel3.Size = new Size(837, 271);
            uiTitlePanel3.TabIndex = 1;
            uiTitlePanel3.Text = "软件参数";
            uiTitlePanel3.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // txt_SoftTime
            // 
            txt_SoftTime.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_SoftTime.Location = new Point(247, 181);
            txt_SoftTime.Margin = new Padding(4, 5, 4, 5);
            txt_SoftTime.MinimumSize = new Size(1, 16);
            txt_SoftTime.Name = "txt_SoftTime";
            txt_SoftTime.Padding = new Padding(5);
            txt_SoftTime.ShowText = false;
            txt_SoftTime.Size = new Size(195, 55);
            txt_SoftTime.TabIndex = 2;
            txt_SoftTime.TextAlignment = ContentAlignment.MiddleLeft;
            txt_SoftTime.Watermark = "";
            // 
            // uiLabel9
            // 
            uiLabel9.Font = new Font("宋体", 11F);
            uiLabel9.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel9.Location = new Point(31, 190);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new Size(197, 46);
            uiLabel9.TabIndex = 0;
            uiLabel9.Text = "软件试用时间";
            // 
            // txt_SoftwareVersion
            // 
            txt_SoftwareVersion.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_SoftwareVersion.Location = new Point(247, 101);
            txt_SoftwareVersion.Margin = new Padding(4, 5, 4, 5);
            txt_SoftwareVersion.MinimumSize = new Size(1, 16);
            txt_SoftwareVersion.Name = "txt_SoftwareVersion";
            txt_SoftwareVersion.Padding = new Padding(5);
            txt_SoftwareVersion.ShowText = false;
            txt_SoftwareVersion.Size = new Size(195, 55);
            txt_SoftwareVersion.TabIndex = 2;
            txt_SoftwareVersion.TextAlignment = ContentAlignment.MiddleLeft;
            txt_SoftwareVersion.Watermark = "";
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("宋体", 11F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(86, 101);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(142, 46);
            uiLabel5.TabIndex = 0;
            uiLabel5.Text = "软件版本";
            // 
            // btn_Save
            // 
            btn_Save.Font = new Font("宋体", 16F);
            btn_Save.Location = new Point(945, 518);
            btn_Save.MinimumSize = new Size(1, 1);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(478, 181);
            btn_Save.TabIndex = 2;
            btn_Save.Text = "保存";
            btn_Save.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_Save.Click += btn_Save_Click;
            // 
            // PageSystemParameterSet
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(btn_Save);
            Controls.Add(uiTitlePanel3);
            Controls.Add(uiTitlePanel2);
            Controls.Add(cb_CPUType);
            Name = "PageSystemParameterSet";
            Symbol = 559577;
            Text = "参数管理";
            cb_CPUType.ResumeLayout(false);
            uiTitlePanel2.ResumeLayout(false);
            uiTitlePanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITitlePanel cb_CPUType;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIIPTextBox txt_IPAddress;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel 机架号;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txt_Port;
        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UITextBox txt_Rack;
        private Sunny.UI.UITextBox txt_Slot;
        private Sunny.UI.UITextBox txt_ReadTimeInterval;
        private Sunny.UI.UITextBox txt_DirePath;
        private Sunny.UI.UITextBox txt_ReConnectTimeInterval;
        private Sunny.UI.UITextBox txt_SoftwareVersion;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txt_SoftTime;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIRadioButtonGroup rbg_Save;
        private Sunny.UI.UIButton btn_Save;
        private Sunny.UI.UITextBox txt_ConnectTimeOut;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UITextBox txt_PLCVarAddressPath;
        private Sunny.UI.UILabel uiLabel11;
    }
}