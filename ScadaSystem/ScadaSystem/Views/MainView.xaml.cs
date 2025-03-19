using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using ScadaSystem.Messages;
using ScadaSystem.Models;
using ScadaSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScadaSystem.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl,IInjectable
    {
        public MainView()
        {
            InitializeComponent();
            InitData();
            InitRegisterMessage();
        }

        private void InitRegisterMessage() {
            Page.Content = App.Services.GetService<IndexView>();
            WeakReferenceMessenger.Default.Register<MenuEntity>(this, (sender, arg) => {
                 Assembly assembly = Assembly.GetExecutingAssembly();
                var type = assembly.GetType($"{assembly.GetName().Name}.Views.{arg.View}");
                if (type != null) { 
                    Page.Content = App.Services.GetService(type);
                }
            });
        }

        private void InitData() {
            DataContext = App.Services.GetService<MainViewModel>();
        }
    }
}
