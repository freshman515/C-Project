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
    public partial class PageAuthManage : UIPage {
        private readonly AuthManager _authManager;

        public PageAuthManage(AuthManager authManager) {
            InitializeComponent();
            this._authManager = authManager;
            Load += PageAuthManage_Load;
        }

        private async void PageAuthManage_Load(object? sender, EventArgs e) {
            await LoadAuthAsync(SystemEnums.UserRole.工程师, this.cbg_Engineer);
            await LoadAuthAsync(SystemEnums.UserRole.操作员, this.cbg_Operator);
            await LoadAuthAsync(SystemEnums.UserRole.访客, this.cbg_Visitor);
        }
        private async Task LoadAuthAsync(SystemEnums.UserRole role, UICheckBoxGroup cbg) {

            var result = await _authManager.GetAuthAsync(new QueryAuthDto() { Role = role.ToString() });
            if (result.Status == SystemEnums.Result.Success) {
                var auth = result.Data[0];
                List<int> ints = new List<int>();
                var v = cbg.Items;
                if (auth.ControlModule) {
                    ints.Add(0);
                }
                if (auth.MonitorModule) {
                    ints.Add(1);
                }
                if (auth.RecipeModule) {
                    ints.Add(2);
                }
                if (auth.LogModule) {
                    ints.Add(3);
                }
                if (auth.ReportModule) {
                    ints.Add(4);
                }
                if (auth.ChartModule) {
                    ints.Add(5);

                }
                if (auth.ParamModule) {
                    ints.Add(6);
                }
                cbg.SelectedIndexes = ints;
                LogExtension.ShowMessage("加载权限成功", LogLevel.Information);


            } else {
                UIMessageTip.Show(result.Message);
                LogExtension.ShowMessage(result.Message, LogLevel.Error);
            }
        }

        private async void btn_UpdateEngAuth_Click(object sender, EventArgs e) {
            await UpdateAuth(SystemEnums.UserRole.工程师,1, this.cbg_Engineer);
        }

        private async void btn_UpdateOpAuth_Click(object sender, EventArgs e) {
            await UpdateAuth(SystemEnums.UserRole.操作员,2, this.cbg_Operator);
        }

        private async void btn_UpdateVisitorAuth_Click(object sender, EventArgs e) {
            await UpdateAuth(SystemEnums.UserRole.访客,3, this.cbg_Visitor);
        }
        private async Task UpdateAuth(SystemEnums.UserRole role, int id, UICheckBoxGroup cbg) {

            var authListInts = new List<int>();
            for (int i = 0; i < cbg.Items.Count; i++) {
                if (cbg.SelectedIndexes.Contains(i)) {
                    authListInts.Add(i);
                }
            }
            UpdateAuthDto updateAuthDto = new UpdateAuthDto() {
                Id = id,
                Role = role.ToString(),
                ControlModule = authListInts.Contains(0),
                MonitorModule = authListInts.Contains(1),
                RecipeModule = authListInts.Contains(2),
                LogModule = authListInts.Contains(3),
                ReportModule = authListInts.Contains(4),
                ChartModule = authListInts.Contains(5),
                ParamModule = authListInts.Contains(6),
            };
            var res = await _authManager.UpdateAuthAsync(updateAuthDto);
            if(res.Status == SystemEnums.Result.Success) {
                UIMessageTip.Show($"修改{role.ToString()}权限成功");
            } else {
                UIMessageTip.Show(res.Message);
                LogExtension.ShowMessage(res.Message, LogLevel.Information);
            }



        }
    }
}
