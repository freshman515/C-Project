using Castle.Components.DictionaryAdapter;
using Helper;
using HZY.Framework.DependencyInjection;
using IoTClient.Common.Enums;
using IoTClient.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniExcelLibs;
using Model;
using Sunny.UI;

namespace SprayProcessSCADASystemOnWinform {
    //���������� SingletonService�������᷵��ͬһ��ʵ����
    public partial class FrmMain : UIHeaderAsideMainFooterFrame {

        #region ��Ա����
        private readonly ILogger<FrmMain> logger;
        private bool plcIsConnected = false;
        private CancellationTokenSource cts = new CancellationTokenSource();
        #endregion

        #region ��ʼ��
        public FrmMain(ILogger<FrmMain> logger) {
            InitializeComponent();
            //�ô�����Եķ�ʽ����һ��config.ini�ļ���������ɺ�Ϳ���ɾ��
            // Globals.IniFile.Write("PLC����", "������ַ��", Application.StartupPath + "\\PLC_Var_config.xlsx");
            this.logger = logger;
            Init();
            this.Closed += (s, e) => {
                Globals.SiemensClient.Close();
            };
           
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
                return;
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

    }

}
