namespace SprayProcessSCADASystemOnWinform
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            uiPanel1 = new Sunny.UI.UIPanel();
            lbl_Exit = new Sunny.UI.UISymbolLabel();
            lbl_Min = new Sunny.UI.UISymbolLabel();
            lbl_Time = new Sunny.UI.UILabel();
            lbl_Humidness = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            lbl_Temperature = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            st_AlarmInfo = new Sunny.UI.UIScrollingText();
            lbl_User = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            lbl_Title = new Sunny.UI.UILabel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            led_PlcState = new Sunny.UI.UILedBulb();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel10 = new Sunny.UI.UILabel();
            lbl_CPUInformation = new Sunny.UI.UILabel();
            lbl_MemoryInformation = new Sunny.UI.UILabel();
            uiLabel13 = new Sunny.UI.UILabel();
            uiLabel12 = new Sunny.UI.UILabel();
            lbl_SoftwareVersion = new Sunny.UI.UILabel();
            lbl_IsAuthorization = new Sunny.UI.UILabel();
            uiLabel15 = new Sunny.UI.UILabel();
            lbl_Deadline = new Sunny.UI.UILabel();
            uiLabel14 = new Sunny.UI.UILabel();
            StyleManager = new Sunny.UI.UIStyleManager(components);
            uiPanel2 = new Sunny.UI.UIPanel();
            led_ProducteState = new Sunny.UI.UILedBulb();
            uiLabel9 = new Sunny.UI.UILabel();
            lbl_TotalAlarm = new Sunny.UI.UILabel();
            uiLabel7 = new Sunny.UI.UILabel();
            lbl_Beat = new Sunny.UI.UILabel();
            uiLabel8 = new Sunny.UI.UILabel();
            lbl_BadCount = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            lbl_ProducteCount = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            Footer.SuspendLayout();
            Header.SuspendLayout();
            uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            uiPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // Footer
            // 
            Footer.Controls.Add(lbl_Deadline);
            Footer.Controls.Add(uiLabel14);
            Footer.Controls.Add(lbl_IsAuthorization);
            Footer.Controls.Add(uiLabel15);
            Footer.Controls.Add(lbl_SoftwareVersion);
            Footer.Controls.Add(uiLabel12);
            Footer.Controls.Add(lbl_MemoryInformation);
            Footer.Controls.Add(uiLabel13);
            Footer.Controls.Add(lbl_CPUInformation);
            Footer.Controls.Add(uiLabel10);
            Footer.Controls.Add(led_PlcState);
            Footer.Controls.Add(uiLabel4);
            Footer.Location = new Point(292, 996);
            Footer.Size = new Size(1508, 84);
            // 
            // Aside
            // 
            Aside.Location = new Point(0, 165);
            Aside.Size = new Size(292, 915);
            Aside.BeforeExpand += Aside_BeforeExpand;
            // 
            // Header
            // 
            Header.BackColor = Color.WhiteSmoke;
            Header.Controls.Add(uiPanel2);
            Header.Controls.Add(uiPanel1);
            Header.Location = new Point(0, 0);
            Header.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            Header.NodeInterval = 0;
            Header.NodeSize = new Size(110, 50);
            Header.Size = new Size(1800, 165);
            Header.MenuItemClick += Header_MenuItemClick;
            Header.MouseDown += Panel_MouseDown;
            Header.MouseMove += Panel_MouseMove;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(lbl_Exit);
            uiPanel1.Controls.Add(lbl_Min);
            uiPanel1.Controls.Add(lbl_Time);
            uiPanel1.Controls.Add(lbl_Humidness);
            uiPanel1.Controls.Add(uiLabel6);
            uiPanel1.Controls.Add(lbl_Temperature);
            uiPanel1.Controls.Add(uiLabel2);
            uiPanel1.Controls.Add(st_AlarmInfo);
            uiPanel1.Controls.Add(lbl_User);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.Controls.Add(lbl_Title);
            uiPanel1.Controls.Add(pictureBox2);
            uiPanel1.Controls.Add(pictureBox1);
            uiPanel1.FillColor = Color.Transparent;
            uiPanel1.FillColor2 = Color.Transparent;
            uiPanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel1.Location = new Point(0, 0);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(1800, 101);
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            uiPanel1.MouseDown += Panel_MouseDown;
            uiPanel1.MouseMove += Panel_MouseMove;
            // 
            // lbl_Exit
            // 
            lbl_Exit.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbl_Exit.Location = new Point(1687, 7);
            lbl_Exit.MinimumSize = new Size(1, 1);
            lbl_Exit.Name = "lbl_Exit";
            lbl_Exit.Size = new Size(77, 76);
            lbl_Exit.Symbol = 61453;
            lbl_Exit.SymbolSize = 55;
            lbl_Exit.TabIndex = 12;
            lbl_Exit.Click += lbl_Exit_Click;
            // 
            // lbl_Min
            // 
            lbl_Min.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lbl_Min.Location = new Point(1587, 7);
            lbl_Min.MinimumSize = new Size(1, 1);
            lbl_Min.Name = "lbl_Min";
            lbl_Min.Size = new Size(77, 76);
            lbl_Min.Symbol = 61544;
            lbl_Min.SymbolSize = 55;
            lbl_Min.TabIndex = 10;
            lbl_Min.Click += lbl_Min_Click;
            // 
            // lbl_Time
            // 
            lbl_Time.BackColor = Color.Transparent;
            lbl_Time.Font = new Font("Microsoft Sans Serif", 11.25F);
            lbl_Time.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_Time.Location = new Point(1169, 51);
            lbl_Time.Name = "lbl_Time";
            lbl_Time.Size = new Size(323, 37);
            lbl_Time.TabIndex = 9;
            lbl_Time.Text = "2024-10-12 23:05:23";
            lbl_Time.MouseDown += Panel_MouseDown;
            lbl_Time.MouseMove += Panel_MouseMove;
            // 
            // lbl_Humidness
            // 
            lbl_Humidness.BackColor = Color.Transparent;
            lbl_Humidness.Font = new Font("宋体", 10F);
            lbl_Humidness.ForeColor = Color.Green;
            lbl_Humidness.Location = new Point(1470, 14);
            lbl_Humidness.Name = "lbl_Humidness";
            lbl_Humidness.Size = new Size(87, 37);
            lbl_Humidness.TabIndex = 8;
            lbl_Humidness.TagString = "厂内湿度";
            lbl_Humidness.Text = "60%";
            lbl_Humidness.MouseDown += Panel_MouseDown;
            lbl_Humidness.MouseMove += Panel_MouseMove;
            // 
            // uiLabel6
            // 
            uiLabel6.BackColor = Color.Transparent;
            uiLabel6.Font = new Font("宋体", 9F, FontStyle.Bold);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Image = Properties.Resources.湿度;
            uiLabel6.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel6.Location = new Point(1333, 4);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(159, 49);
            uiLabel6.TabIndex = 7;
            uiLabel6.Text = "厂房湿度";
            uiLabel6.TextAlign = ContentAlignment.MiddleCenter;
            uiLabel6.MouseDown += Panel_MouseDown;
            uiLabel6.MouseMove += Panel_MouseMove;
            // 
            // lbl_Temperature
            // 
            lbl_Temperature.BackColor = Color.Transparent;
            lbl_Temperature.Font = new Font("宋体", 10F);
            lbl_Temperature.ForeColor = Color.Green;
            lbl_Temperature.Location = new Point(1261, 14);
            lbl_Temperature.Name = "lbl_Temperature";
            lbl_Temperature.Size = new Size(74, 31);
            lbl_Temperature.TabIndex = 6;
            lbl_Temperature.TagString = "厂内温度";
            lbl_Temperature.Text = "25℃";
            lbl_Temperature.MouseDown += Panel_MouseDown;
            lbl_Temperature.MouseMove += Panel_MouseMove;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.Transparent;
            uiLabel2.Font = new Font("宋体", 9F, FontStyle.Bold);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Image = Properties.Resources.温度;
            uiLabel2.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel2.Location = new Point(1110, 2);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(145, 51);
            uiLabel2.TabIndex = 5;
            uiLabel2.Text = "厂房温度";
            uiLabel2.TextAlign = ContentAlignment.MiddleRight;
            uiLabel2.MouseDown += Panel_MouseDown;
            uiLabel2.MouseMove += Panel_MouseMove;
            // 
            // st_AlarmInfo
            // 
            st_AlarmInfo.Active = true;
            st_AlarmInfo.BackColor = Color.Transparent;
            st_AlarmInfo.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            st_AlarmInfo.Location = new Point(741, 7);
            st_AlarmInfo.MinimumSize = new Size(1, 1);
            st_AlarmInfo.Name = "st_AlarmInfo";
            st_AlarmInfo.Size = new Size(354, 72);
            st_AlarmInfo.TabIndex = 4;
            st_AlarmInfo.Text = "系统正常";
            st_AlarmInfo.MouseDown += Panel_MouseDown;
            st_AlarmInfo.MouseMove += Panel_MouseMove;
            // 
            // lbl_User
            // 
            lbl_User.BackColor = Color.Transparent;
            lbl_User.Font = new Font("宋体", 20.875F, FontStyle.Bold);
            lbl_User.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_User.Location = new Point(532, 10);
            lbl_User.Name = "lbl_User";
            lbl_User.Size = new Size(203, 69);
            lbl_User.TabIndex = 3;
            lbl_User.Text = "风吹过";
            lbl_User.TextAlign = ContentAlignment.MiddleCenter;
            lbl_User.MouseDown += Panel_MouseDown;
            lbl_User.MouseMove += Panel_MouseMove;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("宋体", 10.875F);
            uiLabel1.ForeColor = Color.FromArgb(0, 192, 192);
            uiLabel1.Location = new Point(121, 53);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(318, 42);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "Spray Process SCADA System";
            uiLabel1.MouseDown += Panel_MouseDown;
            uiLabel1.MouseMove += Panel_MouseMove;
            // 
            // lbl_Title
            // 
            lbl_Title.BackColor = Color.Transparent;
            lbl_Title.Font = new Font("宋体", 13.875F, FontStyle.Bold);
            lbl_Title.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_Title.Location = new Point(105, 10);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(354, 46);
            lbl_Title.TabIndex = 1;
            lbl_Title.Text = "喷涂工艺SCADA系统";
            lbl_Title.MouseDown += Panel_MouseDown;
            lbl_Title.MouseMove += Panel_MouseMove;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.用户;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(458, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(75, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox2.MouseDown += Panel_MouseDown;
            pictureBox2.MouseMove += Panel_MouseMove;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.喷涂生产;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(13, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(82, 80);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += Panel_MouseDown;
            pictureBox1.MouseMove += Panel_MouseMove;
            // 
            // led_PlcState
            // 
            led_PlcState.BackColor = Color.Transparent;
            led_PlcState.Location = new Point(218, 15);
            led_PlcState.Name = "led_PlcState";
            led_PlcState.Size = new Size(55, 55);
            led_PlcState.TabIndex = 23;
            led_PlcState.Text = "uiLedBulb1";
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = Color.Transparent;
            uiLabel4.Font = new Font("宋体", 10F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Image = Properties.Resources.连接状态;
            uiLabel4.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel4.Location = new Point(18, 19);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(198, 46);
            uiLabel4.TabIndex = 22;
            uiLabel4.Text = "PLC连接状态";
            uiLabel4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel10
            // 
            uiLabel10.BackColor = Color.Transparent;
            uiLabel10.Font = new Font("宋体", 10F);
            uiLabel10.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel10.Image = Properties.Resources.CPU信息;
            uiLabel10.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel10.Location = new Point(280, 19);
            uiLabel10.Name = "uiLabel10";
            uiLabel10.Size = new Size(142, 46);
            uiLabel10.TabIndex = 24;
            uiLabel10.Text = "CPU信息";
            uiLabel10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_CPUInformation
            // 
            lbl_CPUInformation.BackColor = Color.Transparent;
            lbl_CPUInformation.Font = new Font("宋体", 10F);
            lbl_CPUInformation.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_CPUInformation.Location = new Point(415, 17);
            lbl_CPUInformation.Name = "lbl_CPUInformation";
            lbl_CPUInformation.Size = new Size(98, 51);
            lbl_CPUInformation.TabIndex = 26;
            lbl_CPUInformation.Text = "58%";
            lbl_CPUInformation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_MemoryInformation
            // 
            lbl_MemoryInformation.BackColor = Color.Transparent;
            lbl_MemoryInformation.Font = new Font("宋体", 10F);
            lbl_MemoryInformation.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_MemoryInformation.Location = new Point(641, 17);
            lbl_MemoryInformation.Name = "lbl_MemoryInformation";
            lbl_MemoryInformation.Size = new Size(83, 51);
            lbl_MemoryInformation.TabIndex = 28;
            lbl_MemoryInformation.Text = "58%";
            lbl_MemoryInformation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel13
            // 
            uiLabel13.BackColor = Color.Transparent;
            uiLabel13.Font = new Font("宋体", 10F);
            uiLabel13.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel13.Image = Properties.Resources.内存信息;
            uiLabel13.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel13.Location = new Point(505, 18);
            uiLabel13.Name = "uiLabel13";
            uiLabel13.Size = new Size(145, 51);
            uiLabel13.TabIndex = 27;
            uiLabel13.Text = "内存信息";
            uiLabel13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // uiLabel12
            // 
            uiLabel12.BackColor = Color.Transparent;
            uiLabel12.Font = new Font("宋体", 10F);
            uiLabel12.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel12.Image = Properties.Resources.软件版本;
            uiLabel12.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel12.Location = new Point(724, 19);
            uiLabel12.Name = "uiLabel12";
            uiLabel12.Size = new Size(151, 51);
            uiLabel12.TabIndex = 29;
            uiLabel12.Text = "软件版本";
            uiLabel12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_SoftwareVersion
            // 
            lbl_SoftwareVersion.BackColor = Color.Transparent;
            lbl_SoftwareVersion.Font = new Font("宋体", 10F);
            lbl_SoftwareVersion.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_SoftwareVersion.Location = new Point(876, 18);
            lbl_SoftwareVersion.Name = "lbl_SoftwareVersion";
            lbl_SoftwareVersion.Size = new Size(71, 51);
            lbl_SoftwareVersion.TabIndex = 30;
            lbl_SoftwareVersion.Text = "58%";
            lbl_SoftwareVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_IsAuthorization
            // 
            lbl_IsAuthorization.BackColor = Color.Transparent;
            lbl_IsAuthorization.Font = new Font("宋体", 10F);
            lbl_IsAuthorization.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_IsAuthorization.Location = new Point(1127, 21);
            lbl_IsAuthorization.Name = "lbl_IsAuthorization";
            lbl_IsAuthorization.Size = new Size(42, 46);
            lbl_IsAuthorization.TabIndex = 32;
            lbl_IsAuthorization.Text = "否";
            lbl_IsAuthorization.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel15
            // 
            uiLabel15.BackColor = Color.Transparent;
            uiLabel15.Font = new Font("宋体", 10F);
            uiLabel15.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel15.Image = Properties.Resources.授权;
            uiLabel15.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel15.Location = new Point(953, 19);
            uiLabel15.Name = "uiLabel15";
            uiLabel15.Size = new Size(173, 51);
            uiLabel15.TabIndex = 31;
            uiLabel15.Text = "是否授权";
            uiLabel15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Deadline
            // 
            lbl_Deadline.BackColor = Color.Transparent;
            lbl_Deadline.Font = new Font("宋体", 10F);
            lbl_Deadline.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_Deadline.Location = new Point(1334, 20);
            lbl_Deadline.Name = "lbl_Deadline";
            lbl_Deadline.Size = new Size(148, 51);
            lbl_Deadline.TabIndex = 34;
            lbl_Deadline.Text = "适用五分钟";
            lbl_Deadline.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel14
            // 
            uiLabel14.BackColor = Color.Transparent;
            uiLabel14.Font = new Font("宋体", 10F);
            uiLabel14.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel14.Image = Properties.Resources.期限;
            uiLabel14.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel14.Location = new Point(1182, 19);
            uiLabel14.Name = "uiLabel14";
            uiLabel14.Size = new Size(159, 51);
            uiLabel14.TabIndex = 33;
            uiLabel14.Text = "使用期限";
            uiLabel14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StyleManager
            // 
            StyleManager.GlobalFont = true;
            // 
            // uiPanel2
            // 
            uiPanel2.BackColor = Color.Transparent;
            uiPanel2.Controls.Add(led_ProducteState);
            uiPanel2.Controls.Add(uiLabel9);
            uiPanel2.Controls.Add(lbl_TotalAlarm);
            uiPanel2.Controls.Add(uiLabel7);
            uiPanel2.Controls.Add(lbl_Beat);
            uiPanel2.Controls.Add(uiLabel8);
            uiPanel2.Controls.Add(lbl_BadCount);
            uiPanel2.Controls.Add(uiLabel5);
            uiPanel2.Controls.Add(lbl_ProducteCount);
            uiPanel2.Controls.Add(uiLabel3);
            uiPanel2.FillColor = Color.Transparent;
            uiPanel2.FillColor2 = Color.Transparent;
            uiPanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel2.Location = new Point(0, 100);
            uiPanel2.Margin = new Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.RectColor = Color.Transparent;
            uiPanel2.Size = new Size(1482, 65);
            uiPanel2.TabIndex = 22;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // led_ProducteState
            // 
            led_ProducteState.BackColor = Color.Transparent;
            led_ProducteState.Location = new Point(1409, 3);
            led_ProducteState.Name = "led_ProducteState";
            led_ProducteState.Size = new Size(55, 55);
            led_ProducteState.TabIndex = 31;
            led_ProducteState.Text = "uiLedBulb1";
            // 
            // uiLabel9
            // 
            uiLabel9.BackColor = Color.Transparent;
            uiLabel9.Font = new Font("宋体", 12F);
            uiLabel9.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel9.Image = Properties.Resources.系统状态;
            uiLabel9.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel9.Location = new Point(1210, 13);
            uiLabel9.Name = "uiLabel9";
            uiLabel9.Size = new Size(187, 38);
            uiLabel9.TabIndex = 30;
            uiLabel9.Text = "系统状态";
            uiLabel9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_TotalAlarm
            // 
            lbl_TotalAlarm.BackColor = Color.Transparent;
            lbl_TotalAlarm.Font = new Font("宋体", 14.875F, FontStyle.Bold);
            lbl_TotalAlarm.ForeColor = Color.DeepSkyBlue;
            lbl_TotalAlarm.Location = new Point(1088, 12);
            lbl_TotalAlarm.Name = "lbl_TotalAlarm";
            lbl_TotalAlarm.Size = new Size(104, 50);
            lbl_TotalAlarm.TabIndex = 29;
            lbl_TotalAlarm.TagString = "累计报警";
            lbl_TotalAlarm.Text = "0500";
            // 
            // uiLabel7
            // 
            uiLabel7.BackColor = Color.Transparent;
            uiLabel7.Font = new Font("宋体", 12F);
            uiLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel7.Image = Properties.Resources.报警数;
            uiLabel7.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel7.Location = new Point(901, 14);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(187, 38);
            uiLabel7.TabIndex = 28;
            uiLabel7.Text = "累计报警";
            uiLabel7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Beat
            // 
            lbl_Beat.BackColor = Color.Transparent;
            lbl_Beat.Font = new Font("宋体", 14.875F, FontStyle.Bold);
            lbl_Beat.ForeColor = Color.DeepSkyBlue;
            lbl_Beat.Location = new Point(788, 10);
            lbl_Beat.Name = "lbl_Beat";
            lbl_Beat.Size = new Size(103, 50);
            lbl_Beat.TabIndex = 27;
            lbl_Beat.TagString = "生产节拍";
            lbl_Beat.Text = "60 S";
            lbl_Beat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiLabel8
            // 
            uiLabel8.BackColor = Color.Transparent;
            uiLabel8.Font = new Font("宋体", 12F);
            uiLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel8.Image = Properties.Resources.生产节拍;
            uiLabel8.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel8.Location = new Point(604, 14);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(187, 38);
            uiLabel8.TabIndex = 26;
            uiLabel8.Text = "生产节拍";
            uiLabel8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_BadCount
            // 
            lbl_BadCount.BackColor = Color.Transparent;
            lbl_BadCount.Font = new Font("宋体", 14.875F, FontStyle.Bold);
            lbl_BadCount.ForeColor = Color.DeepSkyBlue;
            lbl_BadCount.Location = new Point(506, 11);
            lbl_BadCount.Name = "lbl_BadCount";
            lbl_BadCount.Size = new Size(107, 50);
            lbl_BadCount.TabIndex = 25;
            lbl_BadCount.TagString = "不良计数";
            lbl_BadCount.Text = "5000";
            // 
            // uiLabel5
            // 
            uiLabel5.BackColor = Color.Transparent;
            uiLabel5.Font = new Font("宋体", 12F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Image = Properties.Resources.产量;
            uiLabel5.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel5.Location = new Point(313, 12);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(187, 38);
            uiLabel5.TabIndex = 24;
            uiLabel5.Text = "不良计数";
            uiLabel5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_ProducteCount
            // 
            lbl_ProducteCount.BackColor = Color.Transparent;
            lbl_ProducteCount.Font = new Font("宋体", 14.875F, FontStyle.Bold);
            lbl_ProducteCount.ForeColor = Color.DeepSkyBlue;
            lbl_ProducteCount.Location = new Point(201, 12);
            lbl_ProducteCount.Name = "lbl_ProducteCount";
            lbl_ProducteCount.Size = new Size(121, 50);
            lbl_ProducteCount.TabIndex = 23;
            lbl_ProducteCount.TagString = "生产计数";
            lbl_ProducteCount.Text = "5000";
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.Transparent;
            uiLabel3.Font = new Font("宋体", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Image = Properties.Resources.产量;
            uiLabel3.ImageAlign = ContentAlignment.MiddleLeft;
            uiLabel3.Location = new Point(13, 15);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(187, 38);
            uiLabel3.TabIndex = 22;
            uiLabel3.Text = "生产计数";
            uiLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmMain
            // 
            AllowShowTitle = false;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1800, 1080);
            CloseAskString = "是否关闭系统";
            EscClose = true;
            Name = "FrmMain";
            Padding = new Padding(0);
            ShowTitle = false;
            Text = "Form1";
            ZoomScaleRect = new Rectangle(30, 30, 800, 450);
            FormClosed += FrmMain_FormClosed;
            Footer.ResumeLayout(false);
            Header.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            uiPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private PictureBox pictureBox1;
        private Sunny.UI.UILabel lbl_Title;
        private Sunny.UI.UILabel uiLabel1;
        private PictureBox pictureBox2;
        private Sunny.UI.UILabel lbl_User;
        private Sunny.UI.UIScrollingText st_AlarmInfo;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel lbl_Temperature;
        private Sunny.UI.UILabel lbl_Humidness;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel lbl_Time;
        private Sunny.UI.UISymbolLabel lbl_Min;
        private Sunny.UI.UISymbolLabel lbl_Exit;
        private Sunny.UI.UILedBulb led_PlcState;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel lbl_CPUInformation;
        private Sunny.UI.UILabel lbl_MemoryInformation;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UILabel lbl_SoftwareVersion;
        private Sunny.UI.UILabel lbl_IsAuthorization;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UILabel lbl_Deadline;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UIStyleManager StyleManager;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UILedBulb led_ProducteState;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel lbl_TotalAlarm;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel lbl_Beat;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel lbl_BadCount;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel lbl_ProducteCount;
        private Sunny.UI.UILabel uiLabel3;
    }
}
