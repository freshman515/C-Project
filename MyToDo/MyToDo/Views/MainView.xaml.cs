using MyToDo.Common;
using MyToDo.Extensins;
using MyToDo.ViewModels;
using Prism.Events;
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

namespace MyToDo.Views {
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window {
        private readonly IDialogHostService dialogHost;

        public MainView(IEventAggregator aggregator, IDialogHostService dialogHost,MainViewModel model) {
            InitializeComponent();
            //订阅事件
            aggregator.Register(arg => {
                DialogHost.IsOpen = arg.IsOpen;
                if (DialogHost.IsOpen) {
                    DialogHost.DialogContent = new ProgressView();
                }
            });

            

            //注册提示消息
            aggregator.RegisterMessage(arg => {
                Snackbar.MessageQueue.Enqueue(arg);
            });

            btnMin.Click += (s, e) => { WindowState = WindowState.Minimized; };

            btnMax.Click += (s, e) => {
                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Maximized;
            };

            btnClose.Click += async (s, e) => {

                var result = await dialogHost.Question("温馨提示", "确认退出系统");
                if (result.Result != Prism.Services.Dialogs.ButtonResult.OK) {
                    return;
                }
                Close();
            };

            colorZone.MouseMove += (s, e) => {
                if (e.LeftButton == MouseButtonState.Pressed) {
                    DragMove();
                }
            };

            colorZone.MouseDoubleClick += (s, e) => {
                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;
                else
                    WindowState = WindowState.Maximized;
            };
            menuBar.SelectionChanged += (s, e) => {
                drawerHost.IsLeftDrawerOpen = false;
            };
            this.dialogHost = dialogHost;
        }

    }
}
