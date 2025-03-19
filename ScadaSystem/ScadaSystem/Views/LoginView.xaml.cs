﻿using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using ScadaSystem.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScadaSystem.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : UserControl, IInjectable {
        public LoginView()
        {
            InitializeComponent();
            InitData();
            InitRegisterMessage();
        }

        private void InitRegisterMessage() {
        }

        private void InitData() {
            DataContext = App.Services?.GetService<LoginViewModel>();
        }
    }
}
