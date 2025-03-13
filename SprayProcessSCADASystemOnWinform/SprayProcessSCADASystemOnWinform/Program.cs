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
using BLL;
using Sunny.UI;

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

          

            var db=Globals.ServiceProvider.GetRequiredService<ISqlSugarClient>();
#if DEBUG   //ֻ����debugģʽ�²����ã���Ϊ�������ʵ��ı��ṹ
            //db.CodeFirst���� SqlSugar ORM �е� Code First���������ȣ�ģʽ��������ͨ�� C# ���Զ��������ݿ��������Ҫ�ֶ�д SQL��
            //SetStringDefaultLength(200)�������ݿ��� �ַ������ͣ�string����Ĭ�ϳ���Ϊ 200
            //InitTables(typeof(AuthEntity), typeof(UserEntity), ...) �������ݿ����������ڣ������Զ�����.������Ѿ����ڣ�������ɾ�������ǶԱ�ṹ�����޸ģ���������ֶΣ�
            db.CodeFirst.SetStringDefaultLength(200)
                .InitTables(typeof(AuthEntity), typeof(UserEntity), typeof(DataEntity), typeof(RecipeEntity));
#endif
            var frmMain = serviceProvider.GetRequiredService<FrmMain>();
            Application.Run(frmMain);
        }

        private static void ConfigureService(ServiceCollection service) {
            var temp = typeof(UserManager);//Ϊ��ȷ��bll.dll������
            // service.AddDependencyInjection(new List<Assembly>() { typeof(Program).Assembly,});

            //ע�����з���
            var assemblies = AppDomain.CurrentDomain.GetAssemblies(); // ��ȡ���м��صĳ���
            var types = assemblies
                .SelectMany(a => a.GetTypes()) // �������г���������� SelectMany() �������� �Ѷ�����򼯵����ͺϲ���һ�����б��У�
                .Where(t => typeof(IScopedSelfDependency).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            //typeof(IScopedSelfDependency).IsAssignableFrom(t)�����t�̳��˻�ʵ����IScopedSelfDependency�ͷ���true
            //t.IsInterface && !t.IsAbstract ���Ե��ӿںͳ�����
            foreach (var type in types) {
                service.AddScoped(type); // ȷ�������� AddScoped
            }

            //ע��Pageҳ��
            var types2 = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t=>typeof(UIPage).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface);
            foreach (var type in types2) {
                service.AddSingleton(type);
            }
            //ע��
            service.AddSingleton<FrmMain>();
                    
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