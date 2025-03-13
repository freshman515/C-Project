using HZY.Framework.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;
using DAL;
using SqlSugar;
using Model;
using System.Windows.Forms;

namespace SprayProcessSCADASystemOnWinform {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //创建容器
            var service = new ServiceCollection();
            //注册服务
            ConfigureService(service);
            //构建服务提供者
            var serviceProvider = service.BuildServiceProvider();
            Globals.ServiceProvider = serviceProvider;
            ApplicationConfiguration.Initialize();

            var frmMain = serviceProvider.GetRequiredService<FrmMain>();

            var db=Globals.ServiceProvider.GetRequiredService<ISqlSugarClient>();
#if DEBUG   //只有在debug模式下才能用，因为它会根据实体改变表结构
            //db.CodeFirst这是 SqlSugar ORM 中的 Code First（代码优先）模式，允许你通过 C# 类自动创建数据库表，而不需要手动写 SQL。
            //SetStringDefaultLength(200)设置数据库中 字符串类型（string）的默认长度为 200
            //InitTables(typeof(AuthEntity), typeof(UserEntity), ...) 创建数据库表，如果表不存在，它会自动创建.如果表已经存在，它不会删除表，而是对表结构进行修改（比如添加字段）
            db.CodeFirst.SetStringDefaultLength(200)
                .InitTables(typeof(AuthEntity), typeof(UserEntity), typeof(DataEntity), typeof(RecipeEntity));
#endif
            Application.Run(frmMain);
        }

        private static void ConfigureService(ServiceCollection service) {
            // service.AddDependencyInjection(new List<Assembly>() { typeof(Program).Assembly,});
            service.AddSingleton<FrmMain>();
            service.AddSingleton<PageTotalEquipmentControl>();
            service.AddSingleton<PageUserManage>();
            service.AddSingleton<PageSystemParameterSet>();
            service.AddSingleton<PageEquipmentMonitor>();
            service.AddSingleton<PageEquipmentMonitor2>();
            service.AddSingleton<PageEquipmentMonitor3>();
            service.AddSingleton<PageAuthManage>();
            service.AddSingleton<PageChartManage>();
            service.AddSingleton<PageLogManage>();
            service.AddSingleton<PageRecipeManage>();
            service.AddSingleton<PageReportManage>();


            //注册json配置
            IConfigurationBuilder cfgBuilder = new ConfigurationBuilder().
                SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json");

            //构建配置
            IConfiguration configuration = cfgBuilder.Build();

            //注入一个json单例对象
            service.AddSingleton<IConfiguration>(configuration)
                .AddLogging(loggerBuilder => {
                    loggerBuilder.ClearProviders();//清除其它日志提供者；
                    loggerBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggerBuilder.AddNLog();

                });

            //从json配置文件中得到数据库配置
            DbType dbType = Enum.Parse<DbType>(configuration["DbContexts:DbType"]);
            string connectionString = configuration[$"DbContexts:{dbType}:ConnectionString"];
            //注入sqlsugar
            service.AddSqlSugarSetUp(dbType, connectionString);

            //获取NLog配置信息 
            var nlogConfig = configuration.GetSection("NLog");
            //设置NLog配置
            LogManager.Configuration = new NLogLoggingConfiguration(nlogConfig);



        }
    }
}