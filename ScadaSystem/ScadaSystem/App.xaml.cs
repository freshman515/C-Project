using ControlzEx.Theming;
using MahApps.Metro.Controls;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using ScadaSystem.Services;
using ScadaSystem.ViewModels;
using ScadaSystem.Views;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ScadaSystem {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public new static App Current => (App)Application.Current;
        public static IServiceProvider Services { get; private set; }
        public App() {
            Services = ConfigureService();
        }


        //启动ShellView窗体的方法
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            //切换主题为白色
            ThemeManager.Current.ChangeTheme(this, ThemeManager.Current.AddTheme(
                RuntimeThemeGenerator.Current.GenerateRuntimeTheme("Light", Colors.AliceBlue)
                ));
            Services.GetService<ShellView>()?.Show();
        }

        /// <summary>
        /// 依赖注入的实现
        /// </summary>
        /// <returns></returns>
        private IServiceProvider? ConfigureService() {
            var service = new ServiceCollection();

            var assembly = typeof(App).Assembly;

            //通过实现接口的方式依赖注入
            //foreach ( var type in assembly.GetTypes()) {
            //    if (typeof(IInjectable).IsAssignableFrom(type) && !type.IsInterface) {
            //        service.AddSingleton(type);
            //    }
            //}

            //配置类注入
            ConfigureJsonByBinder(service);

            //注入GlobalConfig
            service.AddSingleton<GlobalConfig>();

            //依赖注入ViewModel和View
            foreach (var type in assembly.GetTypes()) {
                if (typeof(UserControl).IsAssignableFrom(type) || typeof(MetroWindow).IsAssignableFrom(type)) {
                    service.AddSingleton(type);
                }
                if ((type.Name.EndsWith("ViewModel") || type.Name.EndsWith("Session"))|| type.Name.EndsWith("Service")||type.Name.EndsWith("Manager") && !type.IsAbstract) {
                    service.AddSingleton(type);
                }
            }

            

            return service.BuildServiceProvider();
        }

        //将json文件的参数映射到RootParam类上
        private void ConfigureJsonByBinder(ServiceCollection service) {
            var cfgBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory + "\\Configs")
                .AddJsonFile("appsettings.json", false, true);

            var configuration = cfgBuilder.Build();



            // 1、注入日志类 ILogger<T> 
            service.AddSingleton<IConfiguration>(configuration).AddLogging(log => {
                log.ClearProviders();
                log.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                log.AddNLog();
            });
            var nLogConfig = configuration.GetSection("Nlog");
            LogManager.Configuration = new NLogLoggingConfiguration(nLogConfig);

            //改造SQLSugarHelper
            var parseResult = Enum.TryParse<SqlSugar.DbType>(configuration["SqlParam:DbType"],out var dbType);
            var connectionString = configuration["SqlParam:ConnectionString"];
            if (parseResult == true) { 
                SqlSugarHelper.AddSqlSugarSetup(dbType, connectionString);
            }

            //3、参数配置及映射 IOptionsSnapshot<RootParam>
            service.AddOptions()
                .Configure<RootParam>(e => configuration.Bind(e))
                .Configure<SqlParam>(e => configuration.GetSection("SqlParam").Bind(e))
                .Configure<SystemParam>(e => configuration.GetSection("SystemParam").Bind(e))
                .Configure<PlcParam>(e => configuration.GetSection("PlcParam").Bind(e));
           
        }
    }

}
