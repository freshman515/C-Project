using MyToDo.Service;
using MyToDo.ViewModels;
using DryIoc;
using MyToDo.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Configuration;
using System.Data;
using System.Windows;
using MyToDo.Common;
using MyToDo.ViewModels.Dialogs;
using MyToDo.Views.Dialogs;
using Prism.Services.Dialogs;

namespace MyToDo {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication {
        //该方法用于 创建并返回主窗口（Shell），Prism 框架会自动调用它
        protected override Window CreateShell() {
            return Container.Resolve<MainView>();
        }

        //首页隐藏，回到登录界面
        public static void LoginOut(IContainerProvider container) {
            Current.MainWindow.Hide();
            var dialog = container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback => {
                if (callback.Result != ButtonResult.OK) {
                    Environment.Exit(0);
                    return;
                    //Application.Current.Shutdown();
                }
                //var service = App.Current.MainWindow.DataContext as IConfigureService;
                //if (service != null) {
                //    service.Configure();
                //}
                Current.MainWindow.Show();
            });


        }

        //该方法 在应用程序初始化时 调用，用于执行额外的初始化逻辑。
        protected override void OnInitialized() {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback => {
                if (callback.Result != ButtonResult.OK) {
                    Environment.Exit(0);
                    return;
                }
                    //App.Current.MainWindow.DataContext：获取 主窗口的 DataContext，通常是 MainViewModel。
                var service = App.Current.MainWindow.DataContext as IConfigureService;
                if (service != null) {
                    service.Configure();
                }
                base.OnInitialized();
            });

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            // 注册HttpRestClient的实例, 并传入基础URL, 以便后续使用, 该实例会在整个应用程序中共享
            //这里主要是注册HttpRestClient，然后在依赖注入中，会返回默认的构造函数参数，这里是webUrl，webUrl会在后面的代码中注册为http://localhost:5000/
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            //把一个字符串 @"http://localhost:5000/" 注册到容器中，并用 "webUrl" 这个标识符来标记它。
            //这样，在程序的其他地方，容器可以通过 "webUrl" 这个标识符来访问到这个 URL 字符串。
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:38984/", serviceKey: "webUrl");

            //注册弹窗
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();

            // 注册IToDoService的实现类ToDoService
            containerRegistry.Register<IToDoService, ToDoService>();
            containerRegistry.Register<IMemoService, MemoService>();
            containerRegistry.Register<IDialogHostService, DialogHostService>();
            containerRegistry.Register<ILoginService, LoginService>();

            //注册弹窗
            containerRegistry.RegisterForNavigation<AddToDoView, AddToDoViewModel>();
            containerRegistry.RegisterForNavigation<AddMemoView, AddMemoViewModel>();
            containerRegistry.RegisterForNavigation<MsgView, MsgViewModel>();

            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();
            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();


        }
    }

}
