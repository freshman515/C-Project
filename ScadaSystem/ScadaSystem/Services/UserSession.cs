using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;
using ScadaSystem.Models;
using ScadaSystem.Usc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScadaSystem.Services {
    public class UserSession : ObservableObject {
        private UserEntity user = new UserEntity { Username = "test", Password = "test", Role = 1 };

        public UserEntity CurrentUser {
            get => user;
            set { SetProperty(ref user, value); }
        }

        public void ShowMessage(string content, MessageBoxButton button = MessageBoxButton.OK) {
            App.Current.Dispatcher.Invoke(() => {
                DialogHost.Show(new Dialog(content, button), "ShellDialog");
            });
        }

    }
}
