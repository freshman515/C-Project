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

namespace SprayProcessSCADASystemOnWinform.UserControls {
    public partial class LoginForm : UIForm, IScopedSelfDependency {
        private readonly UserManager userManager;

        public bool IsLogin { get; set; } = false;
        private string userName;

        public string UserName {
            get { userName = txt_UserName.Text; return userName; }
            set {
                userName = value;
                txt_UserName.Text = value;
            }
        }
        private string password;

        public string Password {
            get { password = txt_Password.Text; return password; }
            set { password = value; txt_Password.Text = value; }
        }


        public LoginForm(UserManager userManager) {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void uiButton2_Click(object sender, EventArgs e) {
            Close();
        }

        private async void uiButton1_Click(object sender, EventArgs e) {
            UserLoginDto userLoginDto = new UserLoginDto() {
                UserName = UserName,
                UserPassword = Password,
            };
            var res = await userManager.LoginAsync(userLoginDto);
            if (res.Status == Helper.SystemEnums.Result.Success) {
                IsLogin = true;
                this.ShowSuccessTip("登录成功");
                Close();
            } else {
                this.ShowErrorTip(res.Message);
            }
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
    }
}
