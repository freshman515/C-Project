using CommunityToolkit.Mvvm.Messaging;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using ScadaSystem.Messages;
using ScadaSystem.Models;
using ScadaSystem.Services;
using ScadaSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScadaSystem.Views {
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : MetroWindow, IInjectable {
        public UserSession UserSession { get; }

        public ShellView(UserSession userSession) {
            InitializeComponent();
            InitData();
            InitChangeLoginAndWindowView();
            UserSession = userSession;
        }

        private void InitChangeLoginAndWindowView() {
            Container.Content = App.Services?.GetService<LoginView>();

            //如果登录成功，则跳转到主界面（来自于LoginViewmodel 的消息注册）
            WeakReferenceMessenger.Default.Register<LoginMessage>(this, (sender, arg) => {
                Container.Content = App.Services.GetService<MainView>();
                //MessageBox.Show(Width + " " + Height);
                Width = 1200;
                Height = 800;
                //设置弹出的坐标位置
                SetWindowLocation();
            });

            //点击切换用户跳转的页面
            WeakReferenceMessenger.Default.Register<ChangeUserMessage>(this, (sender, arg) => {
                UserSession.CurrentUser = new UserEntity() {
                    Username = "test",
                    Password = "test",
                    Role = 1
                };
                Container.Content = App.Services.GetService<LoginView>();
                Width = 800;
                Height = 500;
                SetWindowLocation();
            });

        }

        private void SetWindowLocation() {
            Left = (SystemParameters.WorkArea.Width - Width) / 2;
            Top = (SystemParameters.WorkArea.Height - Height) / 2;
        }

        //绑定viewmodel
        private void InitData() {
            DataContext = App.Services?.GetService<ShellViewModel>();
        }
    }
}
