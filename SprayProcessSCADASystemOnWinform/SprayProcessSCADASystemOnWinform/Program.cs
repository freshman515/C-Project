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
            //��������
            var service = new ServiceCollection();
            //ע�����
            ConfigureService(service);
            //���������ṩ��
            var serviceProvider = service.BuildServiceProvider();
            Globals.ServiceProvider = serviceProvider;
            ApplicationConfiguration.Initialize();

            var frmMain = serviceProvider.GetRequiredService<FrmMain>();

            var db=Globals.ServiceProvider.GetRequiredService<ISqlSugarClient>();
#if DEBUG   //ֻ����debugģʽ�²����ã���Ϊ�������ʵ��ı��ṹ
            //db.CodeFirst���� SqlSugar ORM �е� Code First���������ȣ�ģʽ��������ͨ�� C# ���Զ��������ݿ��������Ҫ�ֶ�д SQL��
            //SetStringDefaultLength(200)�������ݿ��� �ַ������ͣ�string����Ĭ�ϳ���Ϊ 200
            //InitTables(typeof(AuthEntity), typeof(UserEntity), ...) �������ݿ����������ڣ������Զ�����.������Ѿ����ڣ�������ɾ�������ǶԱ�ṹ�����޸ģ���������ֶΣ�
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


            //ע��json����
            IConfigurationBuilder cfgBuilder = new ConfigurationBuilder().
                SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json");

            //��������
            IConfiguration configuration = cfgBuilder.Build();

            //ע��һ��json��������
            service.AddSingleton<IConfiguration>(configuration)
                .AddLogging(loggerBuilder => {
                    loggerBuilder.ClearProviders();//���������־�ṩ�ߣ�
                    loggerBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggerBuilder.AddNLog();

                });

            //��json�����ļ��еõ����ݿ�����
            DbType dbType = Enum.Parse<DbType>(configuration["DbContexts:DbType"]);
            string connectionString = configuration[$"DbContexts:{dbType}:ConnectionString"];
            //ע��sqlsugar
            service.AddSqlSugarSetUp(dbType, connectionString);

            //��ȡNLog������Ϣ 
            var nlogConfig = configuration.GetSection("NLog");
            //����NLog����
            LogManager.Configuration = new NLogLoggingConfiguration(nlogConfig);



        }
    }
}