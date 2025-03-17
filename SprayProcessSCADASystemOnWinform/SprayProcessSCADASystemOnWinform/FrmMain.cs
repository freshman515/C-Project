using BLL;
using Castle.Components.DictionaryAdapter;
using Helper;
using HZY.Framework.DependencyInjection;
using IoTClient.Common.Enums;
using IoTClient.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniExcelLibs;
using Model;
using SprayProcessSCADASystemOnWinform.UserControls;
using Sunny.UI;
using Yale.SprayProcessSCADASystem;
using Timer = System.Timers.Timer;
namespace SprayProcessSCADASystemOnWinform {
    //���������� SingletonService�������᷵��ͬһ��ʵ����
    public partial class FrmMain : UIHeaderAsideMainFooterFrame {

        #region ��Ա����
        private readonly ILogger<FrmMain> logger;
        private readonly UserManager userManager;
        private readonly AuthManager authManager;
        private readonly DataManager dataManager;
        private bool isFirst = true;
        private bool isConnectFirst = true;
        private bool plcIsConnected = false;
        private Timer timer = new Timer();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Dictionary<string, Control> pageControls = new Dictionary<string, Control>() {
            {"����ģ��",Globals.ServiceProvider.GetRequiredService<PageTotalEquipmentControl>() },
            {"�û�ģ��",Globals.ServiceProvider.GetRequiredService<PageUserManage>() },
            {"Ȩ��ģ��",Globals.ServiceProvider.GetRequiredService<PageAuthManage>() },
            {"���ģ��",Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor>() },
            {"���ģ��2",Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor2>() },
            {"���ģ��3",Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor3>() },
            {"�䷽ģ��",Globals.ServiceProvider.GetRequiredService<PageRecipeManage>() },
            {"��־ģ��",Globals.ServiceProvider.GetRequiredService<PageLogManage>() },
            {"����ģ��",Globals.ServiceProvider.GetRequiredService<PageReportManage>() },
            {"ͼ��ģ��",Globals.ServiceProvider.GetRequiredService<PageChartManage>() },
            {"����ģ��",Globals.ServiceProvider.GetRequiredService<PageSystemParameterSet>() }
        };
        private List<string> alarmList = new List<string>();
        #endregion

        #region ��ʼ��
        public FrmMain(ILogger<FrmMain> logger, UserManager userManager, AuthManager authManager, DataManager dataManager) {
            InitializeComponent();
            //�ô�����Եķ�ʽ����һ��config.ini�ļ���������ɺ�Ϳ���ɾ��
            // Globals.IniFile.Write("PLC����", "������ַ��", Application.StartupPath + "\\PLC_Var_config.xlsx");
            this.logger = logger;
            this.userManager = userManager;
            this.authManager = authManager;
            this.dataManager = dataManager;
            this.lbl_User.Text = "�ÿ�";
            //Init();
            this.Closed += (s, e) => {
                Globals.SiemensClient.Close();
            };

        }
        private void FrmMain_Shown(object sender, EventArgs e) {
            Globals.ServiceProvider.GetRequiredService<FromStartLoad>().OpenFormThread();
            Init();


        }
        public override void Init() {
            //��ʼ�������
            InitAsideUI();
            //��ʼ��ͷ���˵�
            InitHeaderUI();
            //��ʼ��INI�����ļ�
            InitConfig();
            //��ʼ��PLC�ͻ���
            InitPlcClient();
            InitOther();
        }

        private void InitOther() {
            if (Globals.SaveDay != "������") {
                DelFile.DeleteFolder(Globals.DelFilePath, Globals.SaveDay.ToInt());
            }
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) {
            if (!plcIsConnected) {
                Globals.ServiceProvider.GetRequiredService<FromStartLoad>().CloseFormThread();

                return;
            }
            //InvokeRequired �����ж� ��ǰ�����Ƿ������� UI �̡߳���� true��˵����ǰ�����ڷ� UI �߳����У���Ҫ�� Invoke �л� UI �߳�
            if (this.InvokeRequired) {
                //�� UI �߳�ִ�д���
                this.Invoke(async () => {

                    this.lbl_ProducteCount.Text = Globals.DataDic[lbl_ProducteCount.TagString].ToString();
                    this.lbl_BadCount.Text = Globals.DataDic[lbl_BadCount.TagString].ToString();
                    this.lbl_Beat.Text = Globals.DataDic[lbl_Beat.TagString].ToString() + "S";
                    this.lbl_TotalAlarm.Text = Globals.DataDic[lbl_TotalAlarm.TagString].ToString();
                    this.lbl_Temperature.Text = Globals.DataDic[lbl_Temperature.TagString].ToString() + "��C";
                    this.lbl_Humidness.Text = Globals.DataDic[lbl_Humidness.TagString].ToString() + "%";

                    //CPU���ڴ�
                    string CPUstr = RuntimeStatusHelper.DataManager.GetCpuUtilization();
                    string MemoryStr = RuntimeStatusHelper.DataManager.GetMemoryUtilization().Replace("G", "");
                    string NeiResult = (double.Parse(MemoryStr.Split('/')[0]) / double.Parse(MemoryStr.Split('/')[1]) * 100).ToString("f1") + "%";
                    this.lbl_CPUInformation.Text = double.Parse(CPUstr).ToString("f1") + "%";
                    this.lbl_MemoryInformation.Text = NeiResult;

                    //ʱ��
                    this.lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    List<string> alarmInfos = CheckAlarms(alarmList);
                    this.lbl_TotalAlarm.Text = alarmInfos.Count.ToString();
                    string alarms = string.Join(",", alarmInfos);
                    if (alarms.IsNullOrEmpty()) {
                        this.st_AlarmInfo.Text = "ϵͳ����";
                        this.st_AlarmInfo.ForeColor = Color.LightGreen;
                        this.led_ProducteState.Color = Color.LightGreen;
                        this.led_ProducteState.On = true;
                        this.led_ProducteState.Blink = false;
                    } else {
                        this.st_AlarmInfo.Text = alarms;
                        this.st_AlarmInfo.ForeColor = Color.Red;
                        this.led_ProducteState.Color = Color.Red;

                        this.led_ProducteState.BlinkInterval = 500;
                        this.led_ProducteState.Blink = true;

                    }
                    AddDataDto addDataDto = new AddDataDto();
                    addDataDto.InsertTime = DateTime.Now;
                    //ͨ��������˺��������
                    foreach (var item in Globals.SelfList) {
                        var type = typeof(AddDataDto).GetProperty(item).PropertyType.Name;
                        if (type == "String") {
                            addDataDto.GetType().GetProperty(item).SetValue(addDataDto, Globals.DataDic[item].ToString());
                        }

                    }
                    var res = await dataManager.AddDataAsync(addDataDto);
                    if (res.Status == SystemEnums.Result.Fail) {
                        LogExtension.ShowMessage?.Invoke(res.Message, Microsoft.Extensions.Logging.LogLevel.Error);
                    }
                    if (isFirst) {
                        Globals.ServiceProvider.GetRequiredService<FromStartLoad>().CloseFormThread();
                        isFirst = false;
                    }

                });

            } else {
                this.lbl_ProducteCount.Text = Globals.DataDic[lbl_ProducteCount.TagString].ToString();
                this.lbl_BadCount.Text = Globals.DataDic[lbl_BadCount.TagString].ToString();
                this.lbl_Beat.Text = Globals.DataDic[lbl_Beat.TagString].ToString();
                this.lbl_TotalAlarm.Text = Globals.DataDic[lbl_TotalAlarm.TagString].ToString();

            }



        }
        private List<string> CheckAlarms(List<string> alarmList) {
            List<string> alarmInfos = new List<string>();
            foreach (var alarm in alarmList) {
                if (Globals.DataDic[alarm].ToString() == "1") {
                    alarmInfos.Add(alarm);
                }
            }
            return alarmInfos;
        }
        private void InitConfig() {
            //��ȡ����·��
            Globals.PlcVarConfigPath = Globals.IniFile.ReadString("PLC����", "�������ַ", Application.StartupPath + "\\PLC_Var_config.xlsx");
            Globals.IPAddress = Globals.IniFile.ReadString("PLC����", "��ַ", "127.0.0.1");
            //��ȡ�˿ں�
            Globals.Port = Globals.IniFile.ReadInt("PLC����", "�˿�", 102);
            //��ȡcpu����
            Globals.CpuType = Enum.Parse<SiemensVersion>(Globals.IniFile.ReadString("PLC����", "CPU����", "S7_1200"));
            //�����ܺ�
            Globals.Rack = Globals.IniFile.ReadByte("PLC����", "���ܺ�", 0);
            //����ۺ�
            Globals.Slot = Globals.IniFile.ReadByte("PLC����", "��ۺ�", 0);
            //��ȡplc���ӳ�ʱʱ��
            Globals.ConnectTimeOut = Globals.IniFile.ReadInt("PLC����", "��ʱʱ��", 3000);
            //��ȡplc���ݶ�ȡѭ��ʱ��
            Globals.ReadTimeInterval = Globals.IniFile.ReadInt("PLC����", "��ȡʱ����", 500);
            //��ȡplc������ʱʱ��
            Globals.ReConnectTimeInterval = Globals.IniFile.ReadInt("PLC����", "����ʱ����", 3000);
            //ɾ���ļ���
            Globals.DelFilePath = Globals.IniFile.ReadString("ϵͳ����", "ɾ���ļ���·��", Path.Combine(Application.StartupPath, "Logs"));
            Globals.SaveDay = Globals.IniFile.ReadString("ϵͳ����", "�����ļ�������", "7��");
            Globals.SoftwareVersion = Globals.IniFile.ReadString("�������", "����汾", "V1.0");
            Globals.SoftTime = Globals.IniFile.ReadString("�������", "����ʱ��", "100");
            logger.LogInformation("��ȡINI�����ļ��ɹ�");
        }

        private void InitPlcClient() {

            //��Execel����plc����   MiniExcel.Query<T>(filePath) �� MiniExcel ���ṩ�ķ��������ڴ� Excel ��ȡ���ݲ�ת���ɶ����б�
            var plcVarList = MiniExcel.Query<PLCVarConfigModel>(Globals.PlcVarConfigPath).ToList();

            //��ʼ�������ֵ�
            foreach (var item in plcVarList) {
                //��ʼ��������ַ�ֵ�  ��ַ-����
                Globals.ReadDic.Add(item.PLC��ַ, Enum.Parse<DataTypeEnum>(item.��������, true));//���Դ�Сд
                //��ʼ������ֵ��ȡ�ֵ�  ����-ֵ
                Globals.DataDic.Add(item.����, "NA");
                //��ʼ������д���ֵ�  ����-��ַ
                Globals.WriteDic.Add(item.����, item.PLC��ַ);
                //��ʼ����Ҫ����ı���
                if (item.�Ƿ񱣴�.ToLower() == "true") {
                    Globals.SelfList.Add(item.����);
                }
                //��ӱ�������
                if (item.����.EndsWith("����") && !item.����.Equals("�ۼƱ���")) {
                    alarmList.Add(item.����);
                }




            }
            //��ʼ��PLC  �����ӿͻ���
            Globals.SiemensClient = new IoTClient.Clients.PLC.SiemensClient(Globals.CpuType, Globals.IPAddress, Globals.Port, Globals.Slot, Globals.Rack, Globals.ConnectTimeOut);

            //��һ�γ�������plc
            var connectResult = Globals.SiemensClient.Open();
            if (connectResult.IsSucceed) {
                //���ӳɹ� ����״̬
                plcIsConnected = true;
                led_PlcState.On = true;
            } else {
                plcIsConnected = false;
                led_PlcState.On = false;
            }

            logger.LogInformation("��ʼ��PLC�ͻ��˳ɹ�");
            try {

                Task.Run(async () => {
                    while (!cts.IsCancellationRequested) {
                        if (plcIsConnected) {

                            //������ȡ������������ȡ�ֵ�
                            //��ȡ��plc�ڣ�ReadDic���е�ַ��Ӧ��ֵ
                            var readResult = Globals.SiemensClient.BatchRead(Globals.ReadDic);
                            //readResult.Value ���ص���һ�� �ֵ� { PLC��ַ -> ����ֵ }��
                            if (readResult.IsSucceed) {
                                //��ֵ
                                //�ѵ�ַ-ֵ ���ֵ��е�ֵ��ֵ�� ����-ֵ �ֵ��е�ֵ,�͵õ���plc��ֵ
                                //���ֵΪ��1����true 0����false
                                foreach (var item in plcVarList) {
                                    Globals.DataDic[item.����] = readResult.Value[item.PLC��ַ];
                                }
                            } else {
                                Globals.SiemensClient.Close();
                                plcIsConnected = false;
                                this.Invoke(() => {  //���̸߳���ui
                                    this.plcIsConnected = false;
                                });
                            }
                            //�첽�ȴ�ѭ����ȡ
                            await Task.Delay(Globals.ReadTimeInterval);

                        } else {
                            if (isConnectFirst) {
                                isConnectFirst = false;
                                Globals.ServiceProvider.GetRequiredService<FromStartLoad>().CloseFormThread();
                            }
                            //���û���ϣ��Ǿ�����plc
                            var reConnectResult = Globals.SiemensClient.Open();
                            if (reConnectResult.IsSucceed) {
                                plcIsConnected = true;
                                this.Invoke(() => { led_PlcState.On = true; });
                            } else {
                                plcIsConnected = false;
                                this.Invoke(() => { led_PlcState.On = false; });
                                //�ȴ�һ��ʱ���ٴ�����
                                await Task.Delay(Globals.ReConnectTimeInterval);
                            }
                        }
                    }
                });
            } catch (Exception) {
                throw;
            }
        }


        public void InitAsideUI() {
            //���ù���
            Aside.TabControl = MainTabControl;

            //���ó�ʼҳ������������ҳ�棬Ψһ���ظ����ɣ�
            int pageIndex = 1000;
            TreeNode parent0 = Aside.CreateNode("����ģ��", 361461, 34, pageIndex);
            Aside.CreateChildNode(parent0, AddPage(Globals.ServiceProvider.GetRequiredService<PageTotalEquipmentControl>(), ++pageIndex));

            TreeNode parent1 = Aside.CreateNode("�û�ģ��", 61447, 34, pageIndex);
            Aside.CreateChildNode(parent1, AddPage(Globals.ServiceProvider.GetRequiredService<PageUserManage>(), ++pageIndex));
            Aside.CreateChildNode(parent1, AddPage(Globals.ServiceProvider.GetRequiredService<PageAuthManage>(), ++pageIndex));

            TreeNode parent2 = Aside.CreateNode("���ģ��", 560066, 34, pageIndex);
            Aside.CreateChildNode(parent2, AddPage(Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor>(), ++pageIndex));
            Aside.CreateChildNode(parent2, AddPage(Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor2>(), ++pageIndex));
            Aside.CreateChildNode(parent2, AddPage(Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor3>(), ++pageIndex));

            TreeNode parent3 = Aside.CreateNode("�䷽ģ��", 162677, 34, pageIndex);
            Aside.CreateChildNode(parent3, AddPage(Globals.ServiceProvider.GetRequiredService<PageRecipeManage>(), ++pageIndex));

            TreeNode parent4 = Aside.CreateNode("��־ģ��", 57557, 34, pageIndex);
            Aside.CreateChildNode(parent4, AddPage(Globals.ServiceProvider.GetRequiredService<PageLogManage>(), ++pageIndex));

            TreeNode parent5 = Aside.CreateNode("����ģ��", 57586, 34, pageIndex);
            Aside.CreateChildNode(parent5, AddPage(Globals.ServiceProvider.GetRequiredService<PageReportManage>(), ++pageIndex));

            TreeNode parent6 = Aside.CreateNode("ͼ��ģ��", 61950, 34, pageIndex);
            Aside.CreateChildNode(parent6, AddPage(Globals.ServiceProvider.GetRequiredService<PageChartManage>(), ++pageIndex));

            TreeNode parent7 = Aside.CreateNode("����ģ��", 559576, 34, pageIndex);
            Aside.CreateChildNode(parent7, AddPage(Globals.ServiceProvider.GetRequiredService<PageSystemParameterSet>(), ++pageIndex));

            logger.LogInformation("��ʼ��������˵��ɹ�");
        }
        private void InitHeaderUI() {
            //���ù���
            Header.TabControl = MainTabControl;

            Header.Nodes.Add("");
            Header.Nodes.Add("");
            Header.Nodes.Add("");
            Header.SetNodeSymbol(Header.Nodes[0], 558295, 40);
            Header.SetNodeSymbol(Header.Nodes[1], 61489, 40);
            Header.SetNodeSymbol(Header.Nodes[2], 557925, 40);
            var styles = UIStyles.PopularStyles();
            foreach (UIStyle style in styles) {
                Header.CreateChildNode(Header.Nodes[0], style.DisplayText(), style.Value());
            }

            //��ȡö��FontsType��������������
            for (int i = 0; i < Enum.GetValues(typeof(SystemEnums.FontsType)).Length; i++) {
                Header.CreateChildNode(Header.Nodes[1], Enum.GetName(typeof(SystemEnums.FontsType), i), i + 1);
            }

            //��ȡö��FontSize�����������С  75-125�ķ�Χ 75 80 85 90 95 100 105 110 115 120 125
            for (int i = 75; i <= 125; i += 5) {
                Header.CreateChildNode(Header.Nodes[2], i.ToString(), i);
            }

            logger.LogInformation("��ʼ�������˵����ɹ�");
        }
        #endregion

        #region �������
        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex) {
            //0 �����л���1������ʽ ��2�����С
            switch (menuIndex) {
                case 0:
                    UIStyle style = (UIStyle)pageIndex;
                    if (pageIndex < UIStyle.Colorful.Value()) {
                        StyleManager.Style = style;

                        if (UIExtension.SetStyleManager != null) {
                            UIExtension.SetStyleManager(StyleManager);
                        }
                    }
                    break;

                case 1:
                    UIStyles.DPIScale = true;
                    UIStyles.GlobalFont = true;
                    UIStyles.GlobalFontName = itemText;

                    UIStyles.GlobalFontScale = SystemConsts.DefaultFontScale;
                    UIStyles.SetDPIScale();
                    break;

                case 2:
                    UIStyles.GlobalFontScale = int.Parse(itemText);
                    UIStyles.SetDPIScale();
                    break;

                default:

                    break;
            }
        }
        #endregion

        #region �رպ���С��


        private void lbl_Exit_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void lbl_Min_Click(object sender, EventArgs e) {

            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region �ƶ�����
        private Point mPoint;


        private void Panel_MouseDown(object sender, MouseEventArgs e) {
            mPoint = new Point(e.X, e.Y);
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e) {
            //��Aside�۵�����
            Aside.CollapseAll();
            Aside.SelectFirst();
            var formLogion = Globals.ServiceProvider.GetRequiredService<LoginForm>();
            formLogion.ShowDialog();
            if (formLogion.IsLogin) {
                //���µ�¼��Ϣ
                this.lbl_User.Text = formLogion.UserName;
                //����Ȩ��
                foreach (var control in pageControls.Values) {
                    control.Enabled = true;
                }

            }
        }


        /// <summary>
        /// ���һ�β����ģ�飬�Ͳ��Ҹ��û��Ƿ������ģ���Ȩ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Aside_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            string modeName = e.Node.Text;//�õ�mode������
            string user = this.lbl_User.Text;

            //�õ�Ȩ��
            var roleRes = await userManager.GetByUserAuthAsync(new UserQueryAuthDto() { UserName = user });
            if (roleRes.Status == SystemEnums.Result.Success) {
                if (roleRes.Data[0].Role != "����Ա") {
                    var authRes = await authManager.GetAuthAsync(new QueryAuthDto { Role = roleRes.Data[0].Role });
                    if (authRes.Status == SystemEnums.Result.Success) {
                        UpdateControlAccess(modeName, authRes.Data[0], pageControls);
                    }
                }
            }
        }

        private void UpdateControlAccess(string modeName, QueryAuthResultDto authDto, Dictionary<string, Control> pageControls) {
            switch (modeName) {
                case "����ģ��":
                    pageControls["����ģ��"].Enabled = authDto.ControlModule;
                    break;

                case "�û�ģ��":
                    pageControls["�û�ģ��"].Enabled = false;
                    pageControls["Ȩ��ģ��"].Enabled = false;
                    break;

                case "���ģ��":
                    pageControls["���ģ��"].Enabled = authDto.MonitorModule;
                    pageControls["���ģ��2"].Enabled = authDto.MonitorModule;
                    pageControls["���ģ��3"].Enabled = authDto.MonitorModule;
                    break;

                case "�䷽ģ��":
                    pageControls["�䷽ģ��"].Enabled = authDto.RecipeModule;
                    break;

                case "��־ģ��":
                    pageControls["��־ģ��"].Enabled = authDto.LogModule;
                    break;

                case "����ģ��":
                    pageControls["����ģ��"].Enabled = authDto.ReportModule;
                    break;

                case "ͼ��ģ��":
                    pageControls["ͼ��ģ��"].Enabled = authDto.ChartModule;
                    break;

                case "����ģ��":
                    pageControls["����ģ��"].Enabled = authDto.ParamModule;
                    break;
                default:
                    break;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e) {
            if (timer != null) {
                timer.Stop();
                timer.Dispose();  // �ͷ� Timer ��Դ
                timer = null;
            }
            //�ر�plc����
            if (Globals.SiemensClient != null) {
                Globals.SiemensClient.Close();
            }
            //�ر���־
            logger.LogInformation("�ر�ϵͳ");
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

    }

}
