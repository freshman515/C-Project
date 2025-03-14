using BLL;
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
    public partial class PageRecipeManage : UIPage {
        private readonly RecipeManager recipeManager;

        public PageRecipeManage(RecipeManager recipeManager) {
            InitializeComponent();
            this.recipeManager = recipeManager;
            Load += PageRecipeManage_Load;
        }

        private async void PageRecipeManage_Load(object? sender, EventArgs e) {
            await LoadRecipeAsync();
        }

        private async Task LoadRecipeAsync() {
            var res = await recipeManager.GetRecipeListAsync();
            if (res.Status == Helper.SystemEnums.Result.Success) {
                this.dgv_Recipe.DataSource = null;
                this.dgv_Recipe.DataSource = res.Data;
            } else {
                LogExtension.ShowMessage?.Invoke(res.Message, LogLevel.Error);
            }
        }

        private async void btn_AddRecipe_Click(object sender, EventArgs e) {
            if (this.txt_ProductType.Text.IsNullOrEmpty()) {
                UIMessageTip.Show("请输入产品型号");
                return;
            }
            AddRecipeDto addRecipeDto = new AddRecipeDto() {
                产品类型 = this.txt_ProductType.Text
            };
            foreach (var item in this.uiTitlePanel1.Controls) {
                if(item is UserSetValue usv) {
                    var v = usv.VarValue;
                    addRecipeDto.GetType() //得到它的类型
                        .GetProperty(usv.VariableName) //得到类型中所有的属性，如果赋值，就是指定获得某个属性的信息 ,比如"温度",就是要获得温度这个属性的信息
                        .SetValue(addRecipeDto, usv.VarValue); //对某个对象的某个属性赋值，相当于addRecipeDto.VariableName = usv.VarValue;
                }
            }
            var res = await recipeManager.AddRecipeAsync(addRecipeDto);
            if(res.Status == Helper.SystemEnums.Result.Success) {
                UIMessageTip.Show("添加成功");
                await LoadRecipeAsync();
            } else {
                UIMessageTip.Show("添加配方失败");
                LogExtension.ShowMessage?.Invoke(res.Message, LogLevel.Error);
            }



        }
    }
}
