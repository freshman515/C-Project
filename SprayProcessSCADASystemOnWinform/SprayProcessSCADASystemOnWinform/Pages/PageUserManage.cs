using BLL;
using Helper;
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
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
namespace SprayProcessSCADASystemOnWinform {
    public partial class PageUserManage : UIPage {
        private readonly UserManager _userManager;

        public PageUserManage(UserManager userManager) {
            InitializeComponent();
            this._userManager = userManager;
            this.cb_Auth.Items.AddRange(Enum.GetNames(typeof(SystemEnums.UserRole)));
            this.cb_Auth.SelectedIndex = -1;
            InitDgvUse();
        }

        private async void InitDgvUse() {
            //刷新dgv
            var res = await _userManager.GetUserListAsync();
            if (res.Status == SystemEnums.Result.Success) {
                this.dgv_User.DataSource = res.Data;
                this.dgv_User.Refresh();
            } else {
                UIMessageTip.ShowError("添加到DataGridView失败");
                LogExtension.ShowMessage?.Invoke("添加DataGridView失败", LogLevel.Error);
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_AddUser_Click(object sender, EventArgs e) {
            //校验
            if (!ValidInput()) {
                return;
            }
            UserAddDto addDto = new UserAddDto() {
                UserName = this.txt_UserName.Text,
                UserPassword = this.txt_Password.Text,
                Role = this.cb_Auth.SelectedItem.ToString()
            };
            BaseResult result = await _userManager.AddUserAsync(addDto);
            if (result.Status == SystemEnums.Result.Success) {
                UIMessageTip.ShowOk("添加成功");
                LogExtension.ShowMessage?.Invoke("添加用户成功", LogLevel.Information);
                InitDgvUse();
            } else {
                UIMessageTip.ShowError("添加失败");
                LogExtension.ShowMessage?.Invoke("添加用户失败", LogLevel.Error);

            }

        }
        private bool ValidInput() {
            if (string.IsNullOrWhiteSpace(txt_UserName.Text)) {
                UIMessageTip.Show("用户名不能为空");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_Password.Text)) {
                UIMessageTip.Show("密码不能为空");
                return false;
            }
            if (cb_Auth.SelectedIndex == -1) {
                UIMessageTip.Show("请选择权限");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_EnterPassword.Text)) {
                UIMessageTip.Show("确认密码不能为空");
                return false;
            }
            if (txt_EnterPassword.Text != txt_Password.Text) {
                UIMessageTip.Show("两次密码输入不一致！");

            }
            return true;

        }
    }
}
