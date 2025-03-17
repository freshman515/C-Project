using BLL;
using Mapster;
using MiniExcelLibs;
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
            this.dgv_Recipe.AutoGenerateColumns = false;
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
            // 点击添加配方按钮时触发的方法
            if (this.txt_ProductType.Text.IsNullOrEmpty()) {
                UIMessageTip.Show("请输入产品型号");
                return;
            }
            AddRecipeDto addRecipeDto = new AddRecipeDto() {
                产品类型 = this.txt_ProductType.Text
            };
            // 遍历uiTitlePanel1中的所有控件，将UserSetValue控件的值设置到addRecipeDto对象中
            foreach (var item in this.uiTitlePanel1.Controls) {
                if (item is UserSetValue usv) {
                    addRecipeDto.GetType() //得到它的类型
                        .GetProperty(usv.VariableName) //得到类型中所有的属性，如果赋值，就是指定获得某个属性的信息 ,比如"温度",就是要获得温度这个属性的信息
                        .SetValue(addRecipeDto, usv.VarValue); //对某个对象的某个属性赋值，相当于addRecipeDto.VariableName = usv.VarValue;
                }
            }
            // 异步调用recipeManager的AddRecipeAsync方法添加配方
            var res = await recipeManager.AddRecipeAsync(addRecipeDto);
            // 根据添加结果的状态显示相应的消息，并决定是否重新加载配方列表
            if (res.Status == Helper.SystemEnums.Result.Success) {
                UIMessageTip.Show("添加成功");
                await LoadRecipeAsync();
            } else {
                UIMessageTip.Show("添加配方失败");
                LogExtension.ShowMessage?.Invoke(res.Message, LogLevel.Error);
            }
        }

        private async void btn_DelRecipe_Click(object sender, EventArgs e) {
            if (dgv_Recipe.CurrentRow == null) {
                UIMessageTip.Show("请选择一行");
                return;
            }
            int id = (int)dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Id"].Value;
            var res = await recipeManager.DeleteRecipeAsync(new DeleteRecipeDto { Id = id });

            if (res.Status == Helper.SystemEnums.Result.Success) {
                UIMessageTip.Show($"删除配方{this.txt_ProductType.Text}成功");
                await LoadRecipeAsync();
            } else {
                UIMessageTip.Show($"删除配方{this.txt_ProductType.Text}失败，配方不存在");
            }

        }

        private async void dgv_Recipe_SelectIndexChange(object sender, int index) {
            // 根据选中的索引获取食谱信息
            var res = await recipeManager.GetRecipeByIdAsync(new GetRecipeByIdDto() {
                Id = (int)this.dgv_Recipe.Rows[index].Cells["Id"].Value
            });
            if (res.Status == Helper.SystemEnums.Result.Success) {
                // 将获取到的食谱数据加载到UI控件中
                foreach (var item in this.uiTitlePanel1.Controls) {
                    if (item is UserSetValue usv) {
                        var value = res.Data[0].GetType().GetProperty(usv.VariableName).GetValue(res.Data[0]);
                        usv.VarValue = value.ToString();
                    }
                }
                this.txt_ProductType.Text = res.Data[0].产品类型;
            }
        }


        private async void btn_UpdateRecipe_Click(object sender, EventArgs e) {
            if (dgv_Recipe.CurrentRow == null) {
                UIMessageTip.Show("请选择一行");
                return;
            }
            UpdateRecipeDto dto = new UpdateRecipeDto();
            foreach (var item in this.uiTitlePanel1.Controls) {
                if (item is UserSetValue usv) {
                    dto.GetType().GetProperty(usv.VariableName).SetValue(dto, usv.VarValue);
                }
            }
            dto.Id = (int)dgv_Recipe.Rows[dgv_Recipe.CurrentRow.Index].Cells["Id"].Value;
            var currentIndex = dgv_Recipe.CurrentRow.Index;
            dto.产品类型 = txt_ProductType.Text;
            var res = await recipeManager.UpdateRecipeAsync(dto);
            if (res.Status == Helper.SystemEnums.Result.Success) {
                UIMessageTip.ShowOk($"更新配方{this.txt_ProductType.Text}成功");
                await LoadRecipeAsync();
                dgv_Recipe.SelectedIndex = currentIndex;
            } else {
                UIMessageTip.ShowError($"更新配方{this.txt_ProductType.Text}失败:" + res.Message);
                LogExtension.ShowMessage?.Invoke(res.Message, LogLevel.Error);
            }
        }

        private async void btn_QueryRecipe_Click(object sender, EventArgs e) {
            await LoadRecipeAsync();
        }

        private async void btn_ImportRecipe_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var filePath = openFileDialog.FileName;
                    var rows = MiniExcel.Query<QueryRecipeResultDto>(filePath).ToList();
                    //查询数据的配方数据，如果没有，就添加，如果有就更新
                    var res = await recipeManager.GetRecipeListAsync();
                    if (res.Status == Helper.SystemEnums.Result.Success) {
                        var dbRows = res.Data;
                        foreach (var row in rows) {
                            var dbRow = dbRows.FirstOrDefault(i => i.Id == row.Id);
                            if (dbRow != null) {
                                var UpdateDto = row.Adapt<UpdateRecipeDto>();
                                var updateRes = await recipeManager.UpdateRecipeAsync(UpdateDto);
                                if (updateRes.Status == Helper.SystemEnums.Result.Fail) {
                                    LogExtension.ShowMessage?.Invoke(updateRes.Message, LogLevel.Error);
                                }
                            } else {
                                var addDto = row.Adapt<AddRecipeDto>();
                                var updateRes = await recipeManager.AddRecipeAsync(addDto);
                                if (updateRes.Status == Helper.SystemEnums.Result.Fail) {
                                    LogExtension.ShowMessage?.Invoke(updateRes.Message, LogLevel.Error);
                                }
                            }
                        }
                    } else {
                        UIMessageTip.ShowError("导入失败");
                        return;
                    }
                    this.dgv_Recipe.DataSource = rows;
                    await LoadRecipeAsync();
                    UIMessageTip.ShowOk("导入配方成功");
                } catch (Exception ex) {
                    UIMessageTip.ShowError(ex.Message);
                    LogExtension.ShowMessage?.Invoke(ex.Message, LogLevel.Error);
                    throw;
                }
            }
        }

        private void btn_ExportRecipe_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Text files(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var row = this.dgv_Recipe.DataSource as List<QueryRecipeResultDto>;
                    if (row == null || row.Count == 0) {
                        UIMessageTip.ShowError("没有可导出的数据！");
                        return;
                    }
                    var filePath = saveFileDialog.FileName;
                    if (filePath.EndsWith(".xlsx")) {
                        MiniExcel.SaveAs(filePath, row, excelType: ExcelType.XLSX);
                    } else if (filePath.EndsWith(".txt")) {
                        SaveAsTextFile(filePath, row);
                    }
                } catch (Exception ex) {
                    UIMessageTip.ShowError("导出失败");
                    LogExtension.ShowMessage?.Invoke(ex.Message, LogLevel.Error);
                    throw;
                }
            }
        }
        private void SaveAsTextFile(string filePath, List<QueryRecipeResultDto> data) {
            try {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8)) {
                    // 获取类的所有属性（标题行）
                    var properties = typeof(QueryRecipeResultDto).GetProperties();
                    writer.WriteLine(string.Join("\t", properties.Select(p => p.Name))); // 使用制表符分隔
                    // 遍历数据列表，写入每一行
                    foreach (var item in data) {
                        var values = properties.Select(p => p.GetValue(item)?.ToString() ?? "");
                        writer.WriteLine(string.Join("\t", values));
                    }
                }
                UIMessageTip.ShowOk("文本文件保存成功！");
            } catch (Exception ex) {
                UIMessageTip.ShowError("导出文本失败：" + ex.Message);
            }
        }

        private void btn_DownloadRecipe_Click(object sender, EventArgs e) {
            if (!Globals.SiemensClient.Connected) {
                UIMessageTip.Show("请先连接PLC");
                return;
            }
            var res = UIMessageBox.ShowAsk("是否要下载到PLC");
            if (res) {
                foreach (var item in uiTitlePanel1.Controls) {
                    if (item is UserSetValue usv) {
                        if (usv.VarValue == string.Empty) {
                            usv.VarValue = "0";
                        }
                        if (!Globals.PlcWrite(usv.VariableName, usv.VarValue, IoTClient.Enums.DataTypeEnum.Float)) {
                            new UIMessageForm().ShowErrorDialog($"{usv.VariableName}下载失败");
                            return;
                        }
                    }
                }
                UIMessageTip.Show("下载成功");
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
