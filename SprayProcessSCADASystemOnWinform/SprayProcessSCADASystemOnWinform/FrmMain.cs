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
    //当你多次请求 SingletonService，它都会返回同一个实例：
    public partial class FrmMain : UIHeaderAsideMainFooterFrame {

        #region 成员变量
        private readonly ILogger<FrmMain> logger;
        private bool plcIsConnected = false;
        private CancellationTokenSource cts = new CancellationTokenSource();
        #endregion

        #region 初始化
        public FrmMain(ILogger<FrmMain> logger) {
            InitializeComponent();
            //用代码调试的方式创建一个config.ini文件，创建完成后就可以删掉
            // Globals.IniFile.Write("PLC参数", "变量地址表", Application.StartupPath + "\\PLC_Var_config.xlsx");
            this.logger = logger;
            Init();
            this.Closed += (s, e) => {
                Globals.SiemensClient.Close();
            };
           
        }
        public override void Init() {
            //初始化侧边栏
            InitAsideUI();
            //初始化头部菜单
            InitHeaderUI();
            //初始化INI配置文件
            InitConfig();
            //初始化PLC客户端
            InitPlcClient();
        }
        private void InitConfig() {
            //读取表格的路径
            Globals.PlcVarConfigPath = Globals.IniFile.ReadString("PLC参数", "变量表地址", Application.StartupPath + "\\PLC_Var_config.xlsx");
            Globals.IPAddress = Globals.IniFile.ReadString("PLC参数", "地址", "127.0.0.1");
            //读取端口号
            Globals.Port = Globals.IniFile.ReadInt("PLC参数", "端口", 102);
            //读取cpu类型
            Globals.CpuType = Enum.Parse<SiemensVersion>(Globals.IniFile.ReadString("PLC参数", "CPU类型", "S7_1200"));
            //读机架号
            Globals.Rack = Globals.IniFile.ReadByte("PLC参数", "机架号", 0);
            //读插槽号
            Globals.Slot = Globals.IniFile.ReadByte("PLC参数", "插槽号", 0);
            //读取plc连接超时时间
            Globals.ConnectTimeOut = Globals.IniFile.ReadInt("PLC参数", "超时时间", 3000);
            //读取plc数据读取循环时间
            Globals.ReadTimeInterval = Globals.IniFile.ReadInt("PLC参数", "读取时间间隔", 500);
            //读取plc重连超时时间
            Globals.ReConnectTimeInterval = Globals.IniFile.ReadInt("PLC参数", "重连时间间隔", 3000);

            logger.LogInformation("读取INI配置文件成功");
        }

        private void InitPlcClient() {

            //从Execel导入plc变量   MiniExcel.Query<T>(filePath) 是 MiniExcel 库提供的方法，用于从 Excel 读取数据并转换成对象列表。
            var plcVarList = MiniExcel.Query<PLCVarConfigModel>(Globals.PlcVarConfigPath).ToList();

            //初始化三个字典
            foreach (var item in plcVarList) {
                //初始化变量地址字典  地址-类型
                Globals.ReadDic.Add(item.PLC地址, Enum.Parse<DataTypeEnum>(item.变量类型, true));//忽略大小写
                //初始化变量值读取字典  名称-值
                Globals.DataDic.Add(item.名称, "NA");
                //初始化变量写入字典  名词-地址
                Globals.WriteDic.Add(item.名称, item.PLC地址);
            }
            //初始化PLC  西门子客户端
            Globals.SiemensClient = new IoTClient.Clients.PLC.SiemensClient(Globals.CpuType, Globals.IPAddress, Globals.Port, Globals.Slot, Globals.Rack, Globals.ConnectTimeOut);

            //第一次尝试连接plc
            var connectResult = Globals.SiemensClient.Open();
            if (connectResult.IsSucceed) {
                //连接成功 设置状态
                plcIsConnected = true;
                led_PlcState.On = true;
            } else {
                plcIsConnected = false;
                led_PlcState.On = false;
                return;
            }

            logger.LogInformation("初始化PLC客户端成功");
            try {

                Task.Run(async () => {
                    while (!cts.IsCancellationRequested) {
                        if (plcIsConnected) {

                            //批量读取，传入批量读取字典
                            //读取在plc内，ReadDic所有地址对应的值
                            var readResult = Globals.SiemensClient.BatchRead(Globals.ReadDic);
                            //readResult.Value 返回的是一个 字典 { PLC地址 -> 变量值 }。
                            if (readResult.IsSucceed) {
                                //赋值
                                //把地址-值 的字典中的值赋值给 名称-值 字典中的值,就得到了plc的值
                                foreach (var item in plcVarList) {
                                    Globals.DataDic[item.名称] = readResult.Value[item.PLC地址];
                                }
                            } else {
                                Globals.SiemensClient.Close();
                                plcIsConnected = false;
                                this.Invoke(() => {  //跨线程更新ui
                                    this.plcIsConnected = false;
                                });
                            }
                            //异步等待循环读取
                            await Task.Delay(Globals.ReadTimeInterval);

                        } else {

                            //如果没连上，那就重连plc
                            var reConnectResult = Globals.SiemensClient.Open();
                            if (reConnectResult.IsSucceed) {
                                plcIsConnected = true;
                                this.Invoke(() => { led_PlcState.On = true; });
                            } else {
                                plcIsConnected = false;
                                this.Invoke(() => { led_PlcState.On = false; });
                                //等待一段时间再次重连
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
            //设置关联
            Aside.TabControl = MainTabControl;

            //设置初始页面索引（关联页面，唯一不重复即可）
            int pageIndex = 1000;
            TreeNode parent0 = Aside.CreateNode("控制模块", 361461, 34, pageIndex);
            Aside.CreateChildNode(parent0, AddPage(Globals.ServiceProvider.GetRequiredService<PageTotalEquipmentControl>(), ++pageIndex));

            TreeNode parent1 = Aside.CreateNode("用户模块", 61447, 34, pageIndex);
            Aside.CreateChildNode(parent1, AddPage(Globals.ServiceProvider.GetRequiredService<PageUserManage>(), ++pageIndex));
            Aside.CreateChildNode(parent1, AddPage(Globals.ServiceProvider.GetRequiredService<PageAuthManage>(), ++pageIndex));

            TreeNode parent2 = Aside.CreateNode("监控模块", 560066, 34, pageIndex);
            Aside.CreateChildNode(parent2, AddPage(Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor>(), ++pageIndex));
            Aside.CreateChildNode(parent2, AddPage(Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor2>(), ++pageIndex));
            Aside.CreateChildNode(parent2, AddPage(Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor3>(), ++pageIndex));

            TreeNode parent3 = Aside.CreateNode("配方模块", 162677, 34, pageIndex);
            Aside.CreateChildNode(parent3, AddPage(Globals.ServiceProvider.GetRequiredService<PageRecipeManage>(), ++pageIndex));

            TreeNode parent4 = Aside.CreateNode("日志模块", 57557, 34, pageIndex);
            Aside.CreateChildNode(parent4, AddPage(Globals.ServiceProvider.GetRequiredService<PageLogManage>(), ++pageIndex));

            TreeNode parent5 = Aside.CreateNode("报表模块", 57586, 34, pageIndex);
            Aside.CreateChildNode(parent5, AddPage(Globals.ServiceProvider.GetRequiredService<PageReportManage>(), ++pageIndex));

            TreeNode parent6 = Aside.CreateNode("图表模块", 61950, 34, pageIndex);
            Aside.CreateChildNode(parent6, AddPage(Globals.ServiceProvider.GetRequiredService<PageChartManage>(), ++pageIndex));

            TreeNode parent7 = Aside.CreateNode("参数模块", 559576, 34, pageIndex);
            Aside.CreateChildNode(parent7, AddPage(Globals.ServiceProvider.GetRequiredService<PageSystemParameterSet>(), ++pageIndex));

            logger.LogInformation("初始化侧边栏菜单成功");
        }
        private void InitHeaderUI() {
            //设置关联
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

            //获取枚举FontsType的所有字体名称
            for (int i = 0; i < Enum.GetValues(typeof(SystemEnums.FontsType)).Length; i++) {
                Header.CreateChildNode(Header.Nodes[1], Enum.GetName(typeof(SystemEnums.FontsType), i), i + 1);
            }

            //获取枚举FontSize的所有字体大小  75-125的范围 75 80 85 90 95 100 105 110 115 120 125
            for (int i = 75; i <= 125; i += 5) {
                Header.CreateChildNode(Header.Nodes[2], i.ToString(), i);
            }

            logger.LogInformation("初始化顶部菜单栏成功");
        }
        #endregion

        #region 主题管理
        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex) {
            //0 主题切换，1字体样式 ，2字体大小
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

        #region 关闭和最小化


        private void lbl_Exit_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void lbl_Min_Click(object sender, EventArgs e) {

            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 移动窗口
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
