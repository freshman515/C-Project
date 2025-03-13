namespace SprayProcessSCADASystemOnWinform {
    partial class PageTotalEquipmentControl {
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
            uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            btn_DryRun = new UserControls.UserCounterButton();
            btn_AlarmReset = new Sunny.UI.UISymbolButton();
            btn_MachineReset = new Sunny.UI.UISymbolButton();
            btn_Stop = new Sunny.UI.UISymbolButton();
            btn_Start = new Sunny.UI.UISymbolButton();
            uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            device_SSJ = new UserDeviceUnitControl();
            device_GHL = new UserDeviceUnitControl();
            device_LQS = new UserDeviceUnitControl();
            device_SFL = new UserDeviceUnitControl();
            device_JX = new UserDeviceUnitControl();
            device_TH = new UserDeviceUnitControl();
            device_CX = new UserDeviceUnitControl();
            device_TZ = new UserDeviceUnitControl();
            uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            txt_Log = new Sunny.UI.UITextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            uiTitlePanel1.SuspendLayout();
            uiTitlePanel2.SuspendLayout();
            uiTitlePanel3.SuspendLayout();
            SuspendLayout();
            // 
            // uiTitlePanel1
            // 
            uiTitlePanel1.Controls.Add(btn_DryRun);
            uiTitlePanel1.Controls.Add(btn_AlarmReset);
            uiTitlePanel1.Controls.Add(btn_MachineReset);
            uiTitlePanel1.Controls.Add(btn_Stop);
            uiTitlePanel1.Controls.Add(btn_Start);
            uiTitlePanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel1.Location = new Point(12, 8);
            uiTitlePanel1.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel1.MinimumSize = new Size(1, 1);
            uiTitlePanel1.Name = "uiTitlePanel1";
            uiTitlePanel1.Padding = new Padding(1, 45, 1, 1);
            uiTitlePanel1.ShowText = false;
            uiTitlePanel1.Size = new Size(1482, 208);
            uiTitlePanel1.TabIndex = 0;
            uiTitlePanel1.Text = "产线总控制";
            uiTitlePanel1.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel1.TitleHeight = 45;
            // 
            // btn_DryRun
            // 
            btn_DryRun.BackColor = Color.Transparent;
            btn_DryRun.CounterButtonState = false;
            btn_DryRun.CounterButtonSymbol = 61452;
            btn_DryRun.FillColor = Color.Transparent;
            btn_DryRun.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_DryRun.Location = new Point(1209, 64);
            btn_DryRun.MinimumSize = new Size(1, 1);
            btn_DryRun.Name = "btn_DryRun";
            btn_DryRun.Radius = 118;
            btn_DryRun.RectColor = Color.Transparent;
            btn_DryRun.Size = new Size(258, 118);
            btn_DryRun.TabIndex = 4;
            btn_DryRun.Text = "userCounterButton1";
            btn_DryRun.TextAlignment = ContentAlignment.MiddleCenter;
            btn_DryRun.VariableName = "空运行";
            btn_DryRun.ClickedEvent += btn_DryRun_ClickedEvent;
            // 
            // btn_AlarmReset
            // 
            btn_AlarmReset.Font = new Font("微软雅黑", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_AlarmReset.Location = new Point(913, 64);
            btn_AlarmReset.MinimumSize = new Size(1, 1);
            btn_AlarmReset.Name = "btn_AlarmReset";
            btn_AlarmReset.Radius = 40;
            btn_AlarmReset.Size = new Size(259, 118);
            btn_AlarmReset.Symbol = 61473;
            btn_AlarmReset.SymbolSize = 70;
            btn_AlarmReset.TabIndex = 3;
            btn_AlarmReset.TagString = "报警复位";
            btn_AlarmReset.Text = "报警复位";
            btn_AlarmReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_AlarmReset.Click += btn_Control_Comman_Click;
            // 
            // btn_MachineReset
            // 
            btn_MachineReset.Font = new Font("微软雅黑", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_MachineReset.Location = new Point(617, 64);
            btn_MachineReset.MinimumSize = new Size(1, 1);
            btn_MachineReset.Name = "btn_MachineReset";
            btn_MachineReset.Radius = 40;
            btn_MachineReset.Size = new Size(259, 118);
            btn_MachineReset.Symbol = 61473;
            btn_MachineReset.SymbolSize = 70;
            btn_MachineReset.TabIndex = 2;
            btn_MachineReset.TagString = "机械复位";
            btn_MachineReset.Text = "机械复位";
            btn_MachineReset.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_MachineReset.Click += btn_Control_Comman_Click;
            // 
            // btn_Stop
            // 
            btn_Stop.Font = new Font("微软雅黑", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_Stop.Location = new Point(321, 64);
            btn_Stop.MinimumSize = new Size(1, 1);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Radius = 40;
            btn_Stop.Size = new Size(259, 118);
            btn_Stop.Symbol = 561649;
            btn_Stop.SymbolSize = 70;
            btn_Stop.TabIndex = 1;
            btn_Stop.TagString = "总停止";
            btn_Stop.Text = "总停止";
            btn_Stop.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_Stop.Click += btn_Control_Comman_Click;
            // 
            // btn_Start
            // 
            btn_Start.Font = new Font("微软雅黑", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_Start.Location = new Point(25, 64);
            btn_Start.MinimumSize = new Size(1, 1);
            btn_Start.Name = "btn_Start";
            btn_Start.Radius = 40;
            btn_Start.Size = new Size(259, 118);
            btn_Start.Symbol = 561649;
            btn_Start.SymbolSize = 70;
            btn_Start.TabIndex = 0;
            btn_Start.TagString = "总启动";
            btn_Start.Text = "总启动";
            btn_Start.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_Start.Click += btn_Control_Comman_Click;
            // 
            // uiTitlePanel2
            // 
            uiTitlePanel2.Controls.Add(device_SSJ);
            uiTitlePanel2.Controls.Add(device_GHL);
            uiTitlePanel2.Controls.Add(device_LQS);
            uiTitlePanel2.Controls.Add(device_SFL);
            uiTitlePanel2.Controls.Add(device_JX);
            uiTitlePanel2.Controls.Add(device_TH);
            uiTitlePanel2.Controls.Add(device_CX);
            uiTitlePanel2.Controls.Add(device_TZ);
            uiTitlePanel2.Font = new Font("宋体", 10F);
            uiTitlePanel2.Location = new Point(13, 246);
            uiTitlePanel2.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel2.MinimumSize = new Size(1, 1);
            uiTitlePanel2.Name = "uiTitlePanel2";
            uiTitlePanel2.Padding = new Padding(1, 45, 1, 1);
            uiTitlePanel2.ShowText = false;
            uiTitlePanel2.Size = new Size(853, 571);
            uiTitlePanel2.TabIndex = 1;
            uiTitlePanel2.Text = "设备单元控制";
            uiTitlePanel2.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel2.TitleHeight = 45;
            // 
            // device_SSJ
            // 
            device_SSJ.CloseVariableName = "输送机工位关";
            device_SSJ.EquipmentUnitName = "输送机工位";
            device_SSJ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_SSJ.Location = new Point(415, 448);
            device_SSJ.MinimumSize = new Size(1, 1);
            device_SSJ.Name = "device_SSJ";
            device_SSJ.OpenVariableName = "输送机工位开";
            device_SSJ.RectColor = Color.Transparent;
            device_SSJ.Size = new Size(365, 88);
            device_SSJ.State = false;
            device_SSJ.TabIndex = 0;
            device_SSJ.Text = "脱脂工位";
            device_SSJ.TextAlignment = ContentAlignment.MiddleCenter;
            device_SSJ.ClickEvent += device_Common_ClickEvent;
            // 
            // device_GHL
            // 
            device_GHL.CloseVariableName = "固化炉工位关";
            device_GHL.EquipmentUnitName = "固化炉工位";
            device_GHL.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_GHL.Location = new Point(415, 322);
            device_GHL.MinimumSize = new Size(1, 1);
            device_GHL.Name = "device_GHL";
            device_GHL.OpenVariableName = "固化炉工位开";
            device_GHL.RectColor = Color.Transparent;
            device_GHL.Size = new Size(365, 88);
            device_GHL.State = false;
            device_GHL.TabIndex = 0;
            device_GHL.Text = "脱脂工位";
            device_GHL.TextAlignment = ContentAlignment.MiddleCenter;
            device_GHL.ClickEvent += device_Common_ClickEvent;
            // 
            // device_LQS
            // 
            device_LQS.CloseVariableName = "冷却室工位关";
            device_LQS.EquipmentUnitName = "冷却室工位";
            device_LQS.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_LQS.Location = new Point(415, 196);
            device_LQS.MinimumSize = new Size(1, 1);
            device_LQS.Name = "device_LQS";
            device_LQS.OpenVariableName = "冷却室工位开";
            device_LQS.RectColor = Color.Transparent;
            device_LQS.Size = new Size(365, 88);
            device_LQS.State = false;
            device_LQS.TabIndex = 0;
            device_LQS.Text = "脱脂工位";
            device_LQS.TextAlignment = ContentAlignment.MiddleCenter;
            device_LQS.ClickEvent += device_Common_ClickEvent;
            // 
            // device_SFL
            // 
            device_SFL.CloseVariableName = "水分炉工位关";
            device_SFL.EquipmentUnitName = "水分炉工位";
            device_SFL.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_SFL.Location = new Point(415, 70);
            device_SFL.MinimumSize = new Size(1, 1);
            device_SFL.Name = "device_SFL";
            device_SFL.OpenVariableName = "水分炉工位开";
            device_SFL.RectColor = Color.Transparent;
            device_SFL.Size = new Size(365, 88);
            device_SFL.State = false;
            device_SFL.TabIndex = 0;
            device_SFL.Text = "脱脂工位";
            device_SFL.TextAlignment = ContentAlignment.MiddleCenter;
            device_SFL.ClickEvent += device_Common_ClickEvent;
            // 
            // device_JX
            // 
            device_JX.CloseVariableName = "精洗工位关";
            device_JX.EquipmentUnitName = "精洗工位";
            device_JX.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_JX.Location = new Point(24, 448);
            device_JX.MinimumSize = new Size(1, 1);
            device_JX.Name = "device_JX";
            device_JX.OpenVariableName = "精洗工位开";
            device_JX.RectColor = Color.Transparent;
            device_JX.Size = new Size(339, 88);
            device_JX.State = false;
            device_JX.TabIndex = 0;
            device_JX.Text = "脱脂工位";
            device_JX.TextAlignment = ContentAlignment.MiddleCenter;
            device_JX.ClickEvent += device_Common_ClickEvent;
            // 
            // device_TH
            // 
            device_TH.CloseVariableName = "陶化工位关";
            device_TH.EquipmentUnitName = "陶化工位";
            device_TH.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_TH.Location = new Point(24, 322);
            device_TH.MinimumSize = new Size(1, 1);
            device_TH.Name = "device_TH";
            device_TH.OpenVariableName = "陶化工位开";
            device_TH.RectColor = Color.Transparent;
            device_TH.Size = new Size(339, 88);
            device_TH.State = false;
            device_TH.TabIndex = 0;
            device_TH.Text = "脱脂工位";
            device_TH.TextAlignment = ContentAlignment.MiddleCenter;
            device_TH.ClickEvent += device_Common_ClickEvent;
            // 
            // device_CX
            // 
            device_CX.CloseVariableName = "粗洗工位关";
            device_CX.EquipmentUnitName = "粗洗工位";
            device_CX.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_CX.Location = new Point(24, 196);
            device_CX.MinimumSize = new Size(1, 1);
            device_CX.Name = "device_CX";
            device_CX.OpenVariableName = "粗洗工位开";
            device_CX.RectColor = Color.Transparent;
            device_CX.Size = new Size(339, 88);
            device_CX.State = false;
            device_CX.TabIndex = 0;
            device_CX.Text = "脱脂工位";
            device_CX.TextAlignment = ContentAlignment.MiddleCenter;
            device_CX.ClickEvent += device_Common_ClickEvent;
            // 
            // device_TZ
            // 
            device_TZ.CloseVariableName = "脱脂工位关";
            device_TZ.EquipmentUnitName = "脱脂工位";
            device_TZ.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            device_TZ.Location = new Point(24, 70);
            device_TZ.MinimumSize = new Size(1, 1);
            device_TZ.Name = "device_TZ";
            device_TZ.OpenVariableName = "脱脂工位开";
            device_TZ.RectColor = Color.Transparent;
            device_TZ.Size = new Size(339, 88);
            device_TZ.State = false;
            device_TZ.TabIndex = 0;
            device_TZ.Text = "脱脂工位";
            device_TZ.TextAlignment = ContentAlignment.MiddleCenter;
            device_TZ.ClickEvent += device_Common_ClickEvent;
            // 
            // uiTitlePanel3
            // 
            uiTitlePanel3.Controls.Add(txt_Log);
            uiTitlePanel3.Font = new Font("宋体", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel3.Location = new Point(881, 246);
            uiTitlePanel3.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel3.MinimumSize = new Size(1, 1);
            uiTitlePanel3.Name = "uiTitlePanel3";
            uiTitlePanel3.Padding = new Padding(1, 45, 1, 1);
            uiTitlePanel3.ShowText = false;
            uiTitlePanel3.Size = new Size(613, 571);
            uiTitlePanel3.TabIndex = 2;
            uiTitlePanel3.Text = "日志栏";
            uiTitlePanel3.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel3.TitleHeight = 45;
            // 
            // txt_Log
            // 
            txt_Log.Dock = DockStyle.Fill;
            txt_Log.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_Log.Location = new Point(1, 45);
            txt_Log.Margin = new Padding(4, 5, 4, 5);
            txt_Log.MinimumSize = new Size(1, 16);
            txt_Log.Multiline = true;
            txt_Log.Name = "txt_Log";
            txt_Log.Padding = new Padding(5);
            txt_Log.ShowText = false;
            txt_Log.Size = new Size(611, 525);
            txt_Log.TabIndex = 0;
            txt_Log.TextAlignment = ContentAlignment.MiddleLeft;
            txt_Log.Watermark = "";
            // 
            // PageTotalEquipmentControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(uiTitlePanel3);
            Controls.Add(uiTitlePanel2);
            Controls.Add(uiTitlePanel1);
            Name = "PageTotalEquipmentControl";
            Symbol = 62093;
            SymbolSize = 55;
            TagString = "";
            Text = "设备总控";
            uiTitlePanel1.ResumeLayout(false);
            uiTitlePanel2.ResumeLayout(false);
            uiTitlePanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UISymbolButton btn_Start;
        private Sunny.UI.UISymbolButton btn_Stop;
        private Sunny.UI.UISymbolButton btn_MachineReset;
        private Sunny.UI.UISymbolButton btn_AlarmReset;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private UserDeviceUnitControl evice_TZ;
        private UserDeviceUnitControl device_SFL;
        private UserDeviceUnitControl device_LQS;
        private UserDeviceUnitControl device_GHL;
        private UserDeviceUnitControl device_JX;
        private UserDeviceUnitControl device_TH;
        private Sunny.UI.UITextBox txt_Log;
        private UserDeviceUnitControl device_TZ;
        private UserDeviceUnitControl device_CX;
        private UserDeviceUnitControl device_SSJ;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UserControls.UserCounterButton btn_DryRun;
    }
}