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
            this.Load += PageUserManage_Load;
        }

        private void PageUserManage_Load(object? sender, EventArgs e) {
            LoadDgvUse();
        }

        private async void LoadDgvUse() {
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
                LoadDgvUse();
            } else {
                UIMessageTip.ShowError(result.Message);
                LogExtension.ShowMessage?.Invoke(result.Message, LogLevel.Error);

            }

        }
        private async void btn_Update_Click(object sender, EventArgs e) {
            if (!ValidInput()) {
                return;
            }
            UserUpdateDto updateDto = new UserUpdateDto() {
                Id = int.Parse(dgv_User.CurrentRow.Cells["Id"].Value.ToString()),
                UserName = this.txt_UserName.Text,
                UserPassword = this.txt_Password.Text,
                Role = this.cb_Auth.SelectedItem.ToString()
            };
            var result = await _userManager.UpdateUserAsync(updateDto);
            if (result.Status == SystemEnums.Result.Success) {
                UIMessageTip.ShowOk("修改用户成功");
                LogExtension.ShowMessage?.Invoke("修改用户成功", LogLevel.Information);
                LoadDgvUse();
            } else {
                UIMessageTip.ShowError(result.Message);
                LogExtension.ShowMessage?.Invoke(result.Message, LogLevel.Error);

            }
        }
        private async void btn_Delete_Click(object sender, EventArgs e) {
            //判断是否选中
            if(this.dgv_User.CurrentRow == null) {
                UIMessageTip.Show("请先选择一行");
                return;
            }
            UserDeleteDto userDeleteDto = new UserDeleteDto() {
                Id = int.Parse(dgv_User.CurrentRow.Cells["Id"].Value.ToString()),
            };
            var result  =  await _userManager.DeleteUserAsync(userDeleteDto);
            if (result.Status == SystemEnums.Result.Success) {
                UIMessageTip.ShowOk("删除用户成功");
                LogExtension.ShowMessage?.Invoke("删除用户成功", LogLevel.Information);
                LoadDgvUse();
            } else {
                UIMessageTip.ShowError(result.Message);
                LogExtension.ShowMessage?.Invoke(result.Message, LogLevel.Error);
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
                return false;
            }
            return true;

        }

        private void dgv_User_SelectIndexChange(object sender, int index) {
            var row = dgv_User.Rows[index]; //拿到当前行
            this.txt_UserName.Text = row.Cells["UserName"].Value.ToString();
            this.txt_Password.Text = row.Cells["UserPassword"].Value.ToString();
            this.txt_EnterPassword.Text = row.Cells["UserPassword"].Value.ToString();
            this.cb_Auth.SelectedItem = row.Cells["Role"].Value.ToString();
        }

        private void dgv_User_DoubleClick(object sender, EventArgs e) {

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
