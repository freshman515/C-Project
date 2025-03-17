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
    //当你多次请求 SingletonService，它都会返回同一个实例：
    public partial class FrmMain : UIHeaderAsideMainFooterFrame {

        #region 成员变量
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
            {"控制模块",Globals.ServiceProvider.GetRequiredService<PageTotalEquipmentControl>() },
            {"用户模块",Globals.ServiceProvider.GetRequiredService<PageUserManage>() },
            {"权限模块",Globals.ServiceProvider.GetRequiredService<PageAuthManage>() },
            {"监控模块",Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor>() },
            {"监控模块2",Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor2>() },
            {"监控模块3",Globals.ServiceProvider.GetRequiredService<PageEquipmentMonitor3>() },
            {"配方模块",Globals.ServiceProvider.GetRequiredService<PageRecipeManage>() },
            {"日志模块",Globals.ServiceProvider.GetRequiredService<PageLogManage>() },
            {"报表模块",Globals.ServiceProvider.GetRequiredService<PageReportManage>() },
            {"图表模块",Globals.ServiceProvider.GetRequiredService<PageChartManage>() },
            {"参数模块",Globals.ServiceProvider.GetRequiredService<PageSystemParameterSet>() }
        };
        private List<string> alarmList = new List<string>();
        #endregion

        #region 初始化
        public FrmMain(ILogger<FrmMain> logger, UserManager userManager, AuthManager authManager, DataManager dataManager) {
            InitializeComponent();
            //用代码调试的方式创建一个config.ini文件，创建完成后就可以删掉
            // Globals.IniFile.Write("PLC参数", "变量地址表", Application.StartupPath + "\\PLC_Var_config.xlsx");
            this.logger = logger;
            this.userManager = userManager;
            this.authManager = authManager;
            this.dataManager = dataManager;
            this.lbl_User.Text = "访客";
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
            //初始化侧边栏
            InitAsideUI();
            //初始化头部菜单
            InitHeaderUI();
            //初始化INI配置文件
            InitConfig();
            //初始化PLC客户端
            InitPlcClient();
            InitOther();
        }

        private void InitOther() {
            if (Globals.SaveDay != "不清理") {
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
            //InvokeRequired 用于判断 当前代码是否运行在 UI 线程。如果 true，说明当前代码在非 UI 线程运行，需要用 Invoke 切回 UI 线程
            if (this.InvokeRequired) {
                //让 UI 线程执行代码
                this.Invoke(async () => {

                    this.lbl_ProducteCount.Text = Globals.DataDic[lbl_ProducteCount.TagString].ToString();
                    this.lbl_BadCount.Text = Globals.DataDic[lbl_BadCount.TagString].ToString();
                    this.lbl_Beat.Text = Globals.DataDic[lbl_Beat.TagString].ToString() + "S";
                    this.lbl_TotalAlarm.Text = Globals.DataDic[lbl_TotalAlarm.TagString].ToString();
                    this.lbl_Temperature.Text = Globals.DataDic[lbl_Temperature.TagString].ToString() + "°C";
                    this.lbl_Humidness.Text = Globals.DataDic[lbl_Humidness.TagString].ToString() + "%";

                    //CPU和内存
                    string CPUstr = RuntimeStatusHelper.DataManager.GetCpuUtilization();
                    string MemoryStr = RuntimeStatusHelper.DataManager.GetMemoryUtilization().Replace("G", "");
                    string NeiResult = (double.Parse(MemoryStr.Split('/')[0]) / double.Parse(MemoryStr.Split('/')[1]) * 100).ToString("f1") + "%";
                    this.lbl_CPUInformation.Text = double.Parse(CPUstr).ToString("f1") + "%";
                    this.lbl_MemoryInformation.Text = NeiResult;

                    //时间
                    this.lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    List<string> alarmInfos = CheckAlarms(alarmList);
                    this.lbl_TotalAlarm.Text = alarmInfos.Count.ToString();
                    string alarms = string.Join(",", alarmInfos);
                    if (alarms.IsNullOrEmpty()) {
                        this.st_AlarmInfo.Text = "系统正常";
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
                    //通过反射过滤和添加数据
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
            //删除文件夹
            Globals.DelFilePath = Globals.IniFile.ReadString("系统参数", "删除文件夹路径", Path.Combine(Application.StartupPath, "Logs"));
            Globals.SaveDay = Globals.IniFile.ReadString("系统参数", "保存文件夹天数", "7天");
            Globals.SoftwareVersion = Globals.IniFile.ReadString("软件参数", "软件版本", "V1.0");
            Globals.SoftTime = Globals.IniFile.ReadString("软件参数", "试用时间", "100");
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
                //初始化需要保存的变量
                if (item.是否保存.ToLower() == "true") {
                    Globals.SelfList.Add(item.名称);
                }
                //添加报警集和
                if (item.名称.EndsWith("报警") && !item.名称.Equals("累计报警")) {
                    alarmList.Add(item.名称);
                }




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
                                //这个值为：1代表true 0代表false
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
                            if (isConnectFirst) {
                                isConnectFirst = false;
                                Globals.ServiceProvider.GetRequiredService<FromStartLoad>().CloseFormThread();
                            }
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

        private void pictureBox2_Click(object sender, EventArgs e) {
            //把Aside折叠起来
            Aside.CollapseAll();
            Aside.SelectFirst();
            var formLogion = Globals.ServiceProvider.GetRequiredService<LoginForm>();
            formLogion.ShowDialog();
            if (formLogion.IsLogin) {
                //更新登录信息
                this.lbl_User.Text = formLogion.UserName;
                //控制权限
                foreach (var control in pageControls.Values) {
                    control.Enabled = true;
                }

            }
        }


        /// <summary>
        /// 点击一次侧边栏模块，就查找该用户是否有这个模块的权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Aside_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            string modeName = e.Node.Text;//得到mode的名字
            string user = this.lbl_User.Text;

            //得到权限
            var roleRes = await userManager.GetByUserAuthAsync(new UserQueryAuthDto() { UserName = user });
            if (roleRes.Status == SystemEnums.Result.Success) {
                if (roleRes.Data[0].Role != "管理员") {
                    var authRes = await authManager.GetAuthAsync(new QueryAuthDto { Role = roleRes.Data[0].Role });
                    if (authRes.Status == SystemEnums.Result.Success) {
                        UpdateControlAccess(modeName, authRes.Data[0], pageControls);
                    }
                }
            }
        }

        private void UpdateControlAccess(string modeName, QueryAuthResultDto authDto, Dictionary<string, Control> pageControls) {
            switch (modeName) {
                case "控制模块":
                    pageControls["控制模块"].Enabled = authDto.ControlModule;
                    break;

                case "用户模块":
                    pageControls["用户模块"].Enabled = false;
                    pageControls["权限模块"].Enabled = false;
                    break;

                case "监控模块":
                    pageControls["监控模块"].Enabled = authDto.MonitorModule;
                    pageControls["监控模块2"].Enabled = authDto.MonitorModule;
                    pageControls["监控模块3"].Enabled = authDto.MonitorModule;
                    break;

                case "配方模块":
                    pageControls["配方模块"].Enabled = authDto.RecipeModule;
                    break;

                case "日志模块":
                    pageControls["日志模块"].Enabled = authDto.LogModule;
                    break;

                case "报表模块":
                    pageControls["报表模块"].Enabled = authDto.ReportModule;
                    break;

                case "图表模块":
                    pageControls["图表模块"].Enabled = authDto.ChartModule;
                    break;

                case "参数模块":
                    pageControls["参数模块"].Enabled = authDto.ParamModule;
                    break;
                default:
                    break;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e) {
            if (timer != null) {
                timer.Stop();
                timer.Dispose();  // 释放 Timer 资源
                timer = null;
            }
            //关闭plc连接
            if (Globals.SiemensClient != null) {
                Globals.SiemensClient.Close();
            }
            //关闭日志
            logger.LogInformation("关闭系统");
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
