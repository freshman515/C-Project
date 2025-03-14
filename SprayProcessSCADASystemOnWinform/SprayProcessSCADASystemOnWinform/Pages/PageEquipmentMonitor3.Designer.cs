namespace SprayProcessSCADASystemOnWinform {
    partial class PageEquipmentMonitor3 {
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
            components = new System.ComponentModel.Container();
            userDeviceState3 = new UserDeviceState();
            userAlarmState3 = new UserAlarmState();
            userVarCurrentValue1 = new UserVarCurrentValue();
            userAlarmState1 = new UserAlarmState();
            uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            userAlarmState4 = new UserAlarmState();
            userAlarmState6 = new UserAlarmState();
            userDeviceState2 = new UserDeviceState();
            userDeviceState1 = new UserDeviceState();
            uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            userAlarmState8 = new UserAlarmState();
            userDeviceState4 = new UserDeviceState();
            timer1 = new System.Windows.Forms.Timer(components);
            uiTitlePanel1.SuspendLayout();
            uiTitlePanel2.SuspendLayout();
            SuspendLayout();
            // 
            // userDeviceState3
            // 
            userDeviceState3.BackColor = Color.Transparent;
            userDeviceState3.DeviceRunName = "输送机变频器电源状态";
            userDeviceState3.FillColor = Color.Transparent;
            userDeviceState3.FillColor2 = Color.Transparent;
            userDeviceState3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userDeviceState3.Location = new Point(48, 67);
            userDeviceState3.MinimumSize = new Size(1, 1);
            userDeviceState3.Name = "userDeviceState3";
            userDeviceState3.RectColor = Color.Transparent;
            userDeviceState3.Size = new Size(433, 81);
            userDeviceState3.State = false;
            userDeviceState3.TabIndex = 0;
            userDeviceState3.Text = "userDeviceState1";
            userDeviceState3.TextAlignment = ContentAlignment.MiddleCenter;
            userDeviceState3.VariableName = "输送机变频器电源状态";
            // 
            // userAlarmState3
            // 
            userAlarmState3.DeviceName = "输送机变频器故障报警";
            userAlarmState3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userAlarmState3.Location = new Point(487, 73);
            userAlarmState3.MinimumSize = new Size(1, 1);
            userAlarmState3.Name = "userAlarmState3";
            userAlarmState3.RectColor = Color.Transparent;
            userAlarmState3.Size = new Size(421, 69);
            userAlarmState3.State = true;
            userAlarmState3.TabIndex = 1;
            userAlarmState3.Text = "userAlarmState1";
            userAlarmState3.TextAlignment = ContentAlignment.MiddleCenter;
            userAlarmState3.VariableName = "输送机变频器故障报警";
            // 
            // userVarCurrentValue1
            // 
            userVarCurrentValue1.DeviceVarName = "固化炉测量温度";
            userVarCurrentValue1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userVarCurrentValue1.Location = new Point(25, 148);
            userVarCurrentValue1.MinimumSize = new Size(1, 1);
            userVarCurrentValue1.Name = "userVarCurrentValue1";
            userVarCurrentValue1.RectColor = Color.Transparent;
            userVarCurrentValue1.Size = new Size(553, 91);
            userVarCurrentValue1.TabIndex = 2;
            userVarCurrentValue1.Text = "userVarCurrentValue1";
            userVarCurrentValue1.TextAlignment = ContentAlignment.MiddleCenter;
            userVarCurrentValue1.Unit = "℃";
            userVarCurrentValue1.VariableName = "固化炉测量温度";
            userVarCurrentValue1.VarValue = 0F;
            // 
            // userAlarmState1
            // 
            userAlarmState1.DeviceName = "固化炉煤气泄漏报警";
            userAlarmState1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userAlarmState1.Location = new Point(1017, 61);
            userAlarmState1.MinimumSize = new Size(1, 1);
            userAlarmState1.Name = "userAlarmState1";
            userAlarmState1.RectColor = Color.Transparent;
            userAlarmState1.Size = new Size(416, 66);
            userAlarmState1.State = true;
            userAlarmState1.TabIndex = 1;
            userAlarmState1.Text = "userAlarmState1";
            userAlarmState1.TextAlignment = ContentAlignment.MiddleCenter;
            userAlarmState1.VariableName = "固化炉煤气泄漏报警";
            // 
            // uiTitlePanel1
            // 
            uiTitlePanel1.BackColor = Color.Transparent;
            uiTitlePanel1.Controls.Add(userVarCurrentValue1);
            uiTitlePanel1.Controls.Add(userAlarmState4);
            uiTitlePanel1.Controls.Add(userAlarmState6);
            uiTitlePanel1.Controls.Add(userAlarmState1);
            uiTitlePanel1.Controls.Add(userDeviceState2);
            uiTitlePanel1.Controls.Add(userDeviceState1);
            uiTitlePanel1.FillColor2 = Color.Transparent;
            uiTitlePanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel1.Location = new Point(13, 11);
            uiTitlePanel1.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel1.MinimumSize = new Size(1, 1);
            uiTitlePanel1.Name = "uiTitlePanel1";
            uiTitlePanel1.Padding = new Padding(1, 40, 1, 1);
            uiTitlePanel1.ShowText = false;
            uiTitlePanel1.Size = new Size(1482, 255);
            uiTitlePanel1.TabIndex = 5;
            uiTitlePanel1.Text = "固化炉工位";
            uiTitlePanel1.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel1.TitleHeight = 40;
            // 
            // userAlarmState4
            // 
            userAlarmState4.DeviceName = "固化炉燃烧机报警";
            userAlarmState4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userAlarmState4.Location = new Point(570, 159);
            userAlarmState4.MinimumSize = new Size(1, 1);
            userAlarmState4.Name = "userAlarmState4";
            userAlarmState4.RectColor = Color.Transparent;
            userAlarmState4.Size = new Size(358, 66);
            userAlarmState4.State = true;
            userAlarmState4.TabIndex = 1;
            userAlarmState4.Text = "userAlarmState6";
            userAlarmState4.TextAlignment = ContentAlignment.MiddleCenter;
            userAlarmState4.VariableName = "固化炉燃烧机报警";
            // 
            // userAlarmState6
            // 
            userAlarmState6.DeviceName = "固化炉煤气泄漏报警";
            userAlarmState6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userAlarmState6.Location = new Point(1036, 173);
            userAlarmState6.MinimumSize = new Size(1, 1);
            userAlarmState6.Name = "userAlarmState6";
            userAlarmState6.RectColor = Color.Transparent;
            userAlarmState6.Size = new Size(397, 66);
            userAlarmState6.State = true;
            userAlarmState6.TabIndex = 1;
            userAlarmState6.Text = "userAlarmState6";
            userAlarmState6.TextAlignment = ContentAlignment.MiddleCenter;
            userAlarmState6.VariableName = "固化炉煤气泄漏报警";
            // 
            // userDeviceState2
            // 
            userDeviceState2.BackColor = Color.Transparent;
            userDeviceState2.DeviceRunName = "固化炉炉口风帘风机运行状态";
            userDeviceState2.FillColor = Color.Transparent;
            userDeviceState2.FillColor2 = Color.Transparent;
            userDeviceState2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userDeviceState2.Location = new Point(487, 61);
            userDeviceState2.MinimumSize = new Size(1, 1);
            userDeviceState2.Name = "userDeviceState2";
            userDeviceState2.RectColor = Color.Transparent;
            userDeviceState2.Size = new Size(524, 81);
            userDeviceState2.State = false;
            userDeviceState2.TabIndex = 0;
            userDeviceState2.Text = "userDeviceState1";
            userDeviceState2.TextAlignment = ContentAlignment.MiddleCenter;
            userDeviceState2.VariableName = "固化炉炉口风帘风机运行状态";
            // 
            // userDeviceState1
            // 
            userDeviceState1.BackColor = Color.Transparent;
            userDeviceState1.DeviceRunName = "固化炉变频器运行状态";
            userDeviceState1.FillColor = Color.Transparent;
            userDeviceState1.FillColor2 = Color.Transparent;
            userDeviceState1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userDeviceState1.Location = new Point(25, 61);
            userDeviceState1.MinimumSize = new Size(1, 1);
            userDeviceState1.Name = "userDeviceState1";
            userDeviceState1.RectColor = Color.Transparent;
            userDeviceState1.Size = new Size(456, 81);
            userDeviceState1.State = false;
            userDeviceState1.TabIndex = 0;
            userDeviceState1.Text = "userDeviceState1";
            userDeviceState1.TextAlignment = ContentAlignment.MiddleCenter;
            userDeviceState1.VariableName = "固化炉变频器运行状态";
            // 
            // uiTitlePanel2
            // 
            uiTitlePanel2.Controls.Add(userDeviceState3);
            uiTitlePanel2.Controls.Add(userAlarmState3);
            uiTitlePanel2.Controls.Add(userAlarmState8);
            uiTitlePanel2.Controls.Add(userDeviceState4);
            uiTitlePanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel2.Location = new Point(14, 294);
            uiTitlePanel2.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel2.MinimumSize = new Size(1, 1);
            uiTitlePanel2.Name = "uiTitlePanel2";
            uiTitlePanel2.Padding = new Padding(1, 40, 1, 1);
            uiTitlePanel2.ShowText = false;
            uiTitlePanel2.Size = new Size(1482, 254);
            uiTitlePanel2.TabIndex = 7;
            uiTitlePanel2.Text = "输送机工位";
            uiTitlePanel2.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel2.TitleHeight = 40;
            // 
            // userAlarmState8
            // 
            userAlarmState8.DeviceName = "输送机行程报警";
            userAlarmState8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userAlarmState8.Location = new Point(487, 161);
            userAlarmState8.MinimumSize = new Size(1, 1);
            userAlarmState8.Name = "userAlarmState8";
            userAlarmState8.RectColor = Color.Transparent;
            userAlarmState8.Size = new Size(421, 69);
            userAlarmState8.State = true;
            userAlarmState8.TabIndex = 1;
            userAlarmState8.Text = "userAlarmState8";
            userAlarmState8.TextAlignment = ContentAlignment.MiddleCenter;
            userAlarmState8.VariableName = "输送机行程报警";
            // 
            // userDeviceState4
            // 
            userDeviceState4.BackColor = Color.Transparent;
            userDeviceState4.DeviceRunName = "输送机变频器运行状态";
            userDeviceState4.FillColor = Color.Transparent;
            userDeviceState4.FillColor2 = Color.Transparent;
            userDeviceState4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userDeviceState4.Location = new Point(25, 161);
            userDeviceState4.MinimumSize = new Size(1, 1);
            userDeviceState4.Name = "userDeviceState4";
            userDeviceState4.RectColor = Color.Transparent;
            userDeviceState4.Size = new Size(456, 81);
            userDeviceState4.State = false;
            userDeviceState4.TabIndex = 0;
            userDeviceState4.Text = "userDeviceState1";
            userDeviceState4.TextAlignment = ContentAlignment.MiddleCenter;
            userDeviceState4.VariableName = "输送机变频器运行状态";
            // 
            // PageEquipmentMonitor3
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(uiTitlePanel1);
            Controls.Add(uiTitlePanel2);
            Name = "PageEquipmentMonitor3";
            Symbol = 57397;
            Text = "设备监控3";
            uiTitlePanel1.ResumeLayout(false);
            uiTitlePanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private UserDeviceState userDeviceState3;
        private UserAlarmState userAlarmState3;
        private UserVarCurrentValue userVarCurrentValue1;
        private UserAlarmState userAlarmState1;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private UserAlarmState userAlarmState6;
        private UserDeviceState userDeviceState1;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private UserAlarmState userAlarmState8;
        private UserAlarmState userAlarmState4;
        private UserDeviceState userDeviceState2;
        private UserDeviceState userDeviceState4;
        private System.Windows.Forms.Timer timer1;
    }
}