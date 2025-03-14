using BLL;
using HZY.Framework.DependencyInjection;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprayProcessSCADASystemOnWinform {
    public partial class FrmLogin : UILoginForm, IScopedSelfDependency {
        private readonly UserManager _userManager;

        public FrmLogin(UserManager userManager) {
            InitializeComponent();
            this._userManager = userManager;
        }

        private async void FrmLogin_ButtonLoginClick(object sender, EventArgs e) {
            UserLoginDto userLoginDto = new UserLoginDto() {
                UserName = UserName,
                UserPassword = Password,
            };
            var res =  await _userManager.LoginAsync(userLoginDto);
            if (res.Status == Helper.SystemEnums.Result.Success) {
                IsLogin = true;
                this.ShowSuccessTip("登录成功");
                Close();
            } else {
                this.ShowErrorTip(res.Message);

            }
        }
    }
}
