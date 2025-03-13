using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Mvvm;
using System.Threading.Tasks;
using Prism.Services.Dialogs;
using Prism.Commands;
using MyToDo.Service;
using MyToDo.Shared.Dtos;
using Prism.Events;
using MyToDo.Extensins;
using MyToDo.Common;

namespace MyToDo.ViewModels {
    public class LoginViewModel : BindableBase, IDialogAware {
        public LoginViewModel(ILoginService service,IEventAggregator aggregator) {
            ExecuteCommand = new DelegateCommand<string>(Execute);
            UserDto = new RegisterUserDto();
            LoginUserDto = new UserDto();
            this.aggregator =  aggregator;
            Service = service;
        }
    
        private void Execute(string obj) {
            switch (obj) {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
                case "Go": SelectedIndex = 1; break; //跳转注册页面
                case "Register": Register(); break;
                case "Return": SelectedIndex = 0; break; //返回登录页面
            }
        }

        private async void Register() {
            
            if (string.IsNullOrWhiteSpace(UserDto.Account)||
                string.IsNullOrEmpty(UserDto.Password)||
                string.IsNullOrWhiteSpace(UserDto.Name)||
                string.IsNullOrWhiteSpace(UserDto.NewPassword)) {
                aggregator.SendMessage("信息请输入完整","Login");

                return;
            }
            if (UserDto.Password != UserDto.NewPassword) {
                //验证失败提示
                aggregator.SendMessage("两次输入的密码不一致,请检查","Login");
                return;
            }
            var registerResult = await Service.RegisterAsync(new Shared.Dtos.UserDto() {
                Account = UserDto.Account,
                Password = UserDto.Password,
                Name = UserDto.Name,
            });
            if (registerResult!=null && registerResult.Status) {
                //注册成功
                aggregator.SendMessage("注册成功!", "Login"); 
                SelectedIndex = 0;
                return;
            }
            //注册失败提示
            aggregator.SendMessage(registerResult.Message);
        }



        private void LoginOut() {
                RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        private async void Login() {
            if (string.IsNullOrWhiteSpace(LoginUserDto.Account)||
                string.IsNullOrWhiteSpace(LoginUserDto.Password)) {
                aggregator.SendMessage("请输入账号和密码", "Login");

                return; 
            }
            var loginResult = await Service.LoginAsync(LoginUserDto);
            if (loginResult.Status) {
                var user = loginResult.Result;
                AppSession.UserName = user.Name;
                aggregator.SendUserName(user.Name);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            } else {
                aggregator.SendMessage("账号或密码错误，请重新输入", "Login");
                LoginUserDto.Account = "";
                LoginUserDto.Password = "";

                //RequestClose?.Invoke(new DialogResult(ButtonResult.No));
            }
        }

        public string Title { get; set; } = "ToDo";
        private int selectedIndex;

        public int SelectedIndex {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }
        IEventAggregator aggregator;
        private RegisterUserDto userDto;

        public RegisterUserDto UserDto {
            get { return userDto; }
            set { userDto = value; RaisePropertyChanged(); }
        }

        private UserDto loginuserDto;

        public UserDto LoginUserDto {
            get { return loginuserDto; }
            set { loginuserDto = value; RaisePropertyChanged(); }
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() {
            return true;
        }

        public void OnDialogClosed() {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters) {
        }

        public DelegateCommand<string> ExecuteCommand { get; set; }

        private string account;

        public string Account {
            get { return account; }
            set { account = value; RaisePropertyChanged(); }
        }

        private string passWord;

        public string PassWord {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        public ILoginService Service { get; }
    }
}
