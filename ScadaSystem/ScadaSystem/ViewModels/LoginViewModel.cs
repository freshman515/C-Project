using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using ScadaSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using ScadaSystem.Messages;

namespace ScadaSystem.ViewModels {
    public partial class LoginViewModel : ObservableObject, IInjectable {
        [ObservableProperty]
        private string _username = "test";

        [ObservableProperty]
        private string _password = "test";

        public LoginViewModel(UserSession userSession) {
            UserSession = userSession;
        }

        public UserSession UserSession { get; }

        [RelayCommand]
        void Login() {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) {
                UserSession.ShowMessage("用户名或密码为空",MessageBoxButton.OK);
                return;
            }
            var user = SqlSugarHelper.Db.Queryable<UserEntity>().
                Where(x => x.Username == Username && x.Password == Password).ToList().SingleOrDefault();
            if(user!=null) {
                
                //对当前用户进行缓存
                UserSession.CurrentUser = user;
                UserSession.ShowMessage("登录成功");

                //进行跳转到主界面 消息通知
                WeakReferenceMessenger.Default.Send(new LoginMessage(user));
                
            } else {
                UserSession.ShowMessage("用户名或密码错误");
            }

        }


    }
}
