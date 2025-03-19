using ControlzEx.Theming;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
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
    }

}
