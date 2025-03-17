namespace SprayProcessSCADASystemOnWinform {
    partial class PageRecipeManage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            dgv_Recipe = new Sunny.UI.UIDataGridView();
            产品类型 = new DataGridViewTextBoxColumn();
            脱脂设定压力上限值 = new DataGridViewTextBoxColumn();
            脱脂设定压力下限值 = new DataGridViewTextBoxColumn();
            粗洗喷淋泵过载上限值 = new DataGridViewTextBoxColumn();
            粗洗液液位下限值 = new DataGridViewTextBoxColumn();
            陶化喷淋泵过载上限值 = new DataGridViewTextBoxColumn();
            精洗喷淋泵过载上限值 = new DataGridViewTextBoxColumn();
            精洗液液位下限值 = new DataGridViewTextBoxColumn();
            水分炉温度上限值 = new DataGridViewTextBoxColumn();
            水分炉温度下限值 = new DataGridViewTextBoxColumn();
            冷却室离心风机过载上限值 = new DataGridViewTextBoxColumn();
            固化炉温度上限值 = new DataGridViewTextBoxColumn();
            固化炉温度下限值 = new DataGridViewTextBoxColumn();
            输送机设定速度 = new DataGridViewTextBoxColumn();
            输送机设定频率 = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            btn_DownloadRecipe = new Sunny.UI.UISymbolButton();
            btn_ExportRecipe = new Sunny.UI.UISymbolButton();
            btn_QueryRecipe = new Sunny.UI.UISymbolButton();
            btn_DelRecipe = new Sunny.UI.UISymbolButton();
            btn_ImportRecipe = new Sunny.UI.UISymbolButton();
            btn_UpdateRecipe = new Sunny.UI.UISymbolButton();
            btn_AddRecipe = new Sunny.UI.UISymbolButton();
            txt_ProductType = new Sunny.UI.UITextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            userSetValue1 = new UserSetValue();
            userSetValue2 = new UserSetValue();
            userSetValue3 = new UserSetValue();
            userSetValue4 = new UserSetValue();
            userSetValue7 = new UserSetValue();
            userSetValue8 = new UserSetValue();
            userSetValue9 = new UserSetValue();
            userSetValue10 = new UserSetValue();
            userSetValue11 = new UserSetValue();
            userSetValue12 = new UserSetValue();
            userSetValue13 = new UserSetValue();
            userSetValue14 = new UserSetValue();
            userSetValue15 = new UserSetValue();
            userSetValue16 = new UserSetValue();
            uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            uiTitlePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Recipe).BeginInit();
            uiTitlePanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiTitlePanel2
            // 
            uiTitlePanel2.Controls.Add(dgv_Recipe);
            uiTitlePanel2.Controls.Add(btn_DownloadRecipe);
            uiTitlePanel2.Controls.Add(btn_ExportRecipe);
            uiTitlePanel2.Controls.Add(btn_QueryRecipe);
            uiTitlePanel2.Controls.Add(btn_DelRecipe);
            uiTitlePanel2.Controls.Add(btn_ImportRecipe);
            uiTitlePanel2.Controls.Add(btn_UpdateRecipe);
            uiTitlePanel2.Controls.Add(btn_AddRecipe);
            uiTitlePanel2.Controls.Add(txt_ProductType);
            uiTitlePanel2.Controls.Add(uiLabel1);
            uiTitlePanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel2.Location = new Point(1063, 4);
            uiTitlePanel2.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel2.MinimumSize = new Size(1, 1);
            uiTitlePanel2.Name = "uiTitlePanel2";
            uiTitlePanel2.Padding = new Padding(1, 35, 1, 1);
            uiTitlePanel2.ShowText = false;
            uiTitlePanel2.Size = new Size(443, 829);
            uiTitlePanel2.TabIndex = 1;
            uiTitlePanel2.Text = "配方控制台";
            uiTitlePanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // dgv_Recipe
            // 
            dgv_Recipe.AllowUserToAddRows = false;
            dgv_Recipe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgv_Recipe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Recipe.BackgroundColor = Color.White;
            dgv_Recipe.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Recipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Recipe.ColumnHeadersHeight = 32;
            dgv_Recipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_Recipe.Columns.AddRange(new DataGridViewColumn[] { 产品类型, 脱脂设定压力上限值, 脱脂设定压力下限值, 粗洗喷淋泵过载上限值, 粗洗液液位下限值, 陶化喷淋泵过载上限值, 精洗喷淋泵过载上限值, 精洗液液位下限值, 水分炉温度上限值, 水分炉温度下限值, 冷却室离心风机过载上限值, 固化炉温度上限值, 固化炉温度下限值, 输送机设定速度, 输送机设定频率, Id });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_Recipe.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_Recipe.EnableHeadersVisualStyles = false;
            dgv_Recipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_Recipe.GridColor = Color.FromArgb(80, 160, 255);
            dgv_Recipe.Location = new Point(10, 510);
            dgv_Recipe.Name = "dgv_Recipe";
            dgv_Recipe.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_Recipe.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_Recipe.RowHeadersWidth = 82;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgv_Recipe.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv_Recipe.SelectedIndex = -1;
            dgv_Recipe.Size = new Size(418, 315);
            dgv_Recipe.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_Recipe.TabIndex = 4;
            dgv_Recipe.SelectIndexChange += dgv_Recipe_SelectIndexChange;
            // 
            // 产品类型
            // 
            产品类型.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            产品类型.DataPropertyName = "产品类型";
            产品类型.HeaderText = "产品类型";
            产品类型.MinimumWidth = 10;
            产品类型.Name = "产品类型";
            产品类型.ReadOnly = true;
            产品类型.Width = 340;
            // 
            // 脱脂设定压力上限值
            // 
            脱脂设定压力上限值.DataPropertyName = "脱脂设定压力上限值";
            脱脂设定压力上限值.HeaderText = "脱脂设定压力上限值";
            脱脂设定压力上限值.MinimumWidth = 10;
            脱脂设定压力上限值.Name = "脱脂设定压力上限值";
            脱脂设定压力上限值.ReadOnly = true;
            脱脂设定压力上限值.Visible = false;
            脱脂设定压力上限值.Width = 200;
            // 
            // 脱脂设定压力下限值
            // 
            脱脂设定压力下限值.DataPropertyName = "脱脂设定压力下限值";
            脱脂设定压力下限值.HeaderText = "脱脂设定压力下限值";
            脱脂设定压力下限值.MinimumWidth = 10;
            脱脂设定压力下限值.Name = "脱脂设定压力下限值";
            脱脂设定压力下限值.ReadOnly = true;
            脱脂设定压力下限值.Visible = false;
            脱脂设定压力下限值.Width = 200;
            // 
            // 粗洗喷淋泵过载上限值
            // 
            粗洗喷淋泵过载上限值.DataPropertyName = "粗洗喷淋泵过载上限值";
            粗洗喷淋泵过载上限值.HeaderText = "粗洗喷淋泵过载上限值";
            粗洗喷淋泵过载上限值.MinimumWidth = 10;
            粗洗喷淋泵过载上限值.Name = "粗洗喷淋泵过载上限值";
            粗洗喷淋泵过载上限值.ReadOnly = true;
            粗洗喷淋泵过载上限值.Visible = false;
            粗洗喷淋泵过载上限值.Width = 200;
            // 
            // 粗洗液液位下限值
            // 
            粗洗液液位下限值.DataPropertyName = "粗洗液液位下限值";
            粗洗液液位下限值.HeaderText = "粗洗液液位下限值";
            粗洗液液位下限值.MinimumWidth = 10;
            粗洗液液位下限值.Name = "粗洗液液位下限值";
            粗洗液液位下限值.ReadOnly = true;
            粗洗液液位下限值.Visible = false;
            粗洗液液位下限值.Width = 200;
            // 
            // 陶化喷淋泵过载上限值
            // 
            陶化喷淋泵过载上限值.DataPropertyName = "陶化喷淋泵过载上限值";
            陶化喷淋泵过载上限值.HeaderText = "陶化喷淋泵过载上限值";
            陶化喷淋泵过载上限值.MinimumWidth = 10;
            陶化喷淋泵过载上限值.Name = "陶化喷淋泵过载上限值";
            陶化喷淋泵过载上限值.ReadOnly = true;
            陶化喷淋泵过载上限值.Visible = false;
            陶化喷淋泵过载上限值.Width = 200;
            // 
            // 精洗喷淋泵过载上限值
            // 
            精洗喷淋泵过载上限值.DataPropertyName = "精洗喷淋泵过载上限值";
            精洗喷淋泵过载上限值.HeaderText = "精洗喷淋泵过载上限值";
            精洗喷淋泵过载上限值.MinimumWidth = 10;
            精洗喷淋泵过载上限值.Name = "精洗喷淋泵过载上限值";
            精洗喷淋泵过载上限值.ReadOnly = true;
            精洗喷淋泵过载上限值.Visible = false;
            精洗喷淋泵过载上限值.Width = 200;
            // 
            // 精洗液液位下限值
            // 
            精洗液液位下限值.DataPropertyName = "精洗液液位下限值";
            精洗液液位下限值.HeaderText = "精洗液液位下限值";
            精洗液液位下限值.MinimumWidth = 10;
            精洗液液位下限值.Name = "精洗液液位下限值";
            精洗液液位下限值.ReadOnly = true;
            精洗液液位下限值.Visible = false;
            精洗液液位下限值.Width = 200;
            // 
            // 水分炉温度上限值
            // 
            水分炉温度上限值.DataPropertyName = "水分炉温度上限值";
            水分炉温度上限值.HeaderText = "水分炉温度上限值";
            水分炉温度上限值.MinimumWidth = 10;
            水分炉温度上限值.Name = "水分炉温度上限值";
            水分炉温度上限值.ReadOnly = true;
            水分炉温度上限值.Visible = false;
            水分炉温度上限值.Width = 200;
            // 
            // 水分炉温度下限值
            // 
            水分炉温度下限值.DataPropertyName = "水分炉温度下限值";
            水分炉温度下限值.HeaderText = "水分炉温度下限值";
            水分炉温度下限值.MinimumWidth = 10;
            水分炉温度下限值.Name = "水分炉温度下限值";
            水分炉温度下限值.ReadOnly = true;
            水分炉温度下限值.Visible = false;
            水分炉温度下限值.Width = 200;
            // 
            // 冷却室离心风机过载上限值
            // 
            冷却室离心风机过载上限值.DataPropertyName = "冷却室离心风机过载上限值";
            冷却室离心风机过载上限值.HeaderText = "冷却室离心风机过载上限值";
            冷却室离心风机过载上限值.MinimumWidth = 10;
            冷却室离心风机过载上限值.Name = "冷却室离心风机过载上限值";
            冷却室离心风机过载上限值.ReadOnly = true;
            冷却室离心风机过载上限值.Visible = false;
            冷却室离心风机过载上限值.Width = 200;
            // 
            // 固化炉温度上限值
            // 
            固化炉温度上限值.DataPropertyName = "固化炉温度上限值";
            固化炉温度上限值.HeaderText = "固化炉温度上限值";
            固化炉温度上限值.MinimumWidth = 10;
            固化炉温度上限值.Name = "固化炉温度上限值";
            固化炉温度上限值.ReadOnly = true;
            固化炉温度上限值.Visible = false;
            固化炉温度上限值.Width = 200;
            // 
            // 固化炉温度下限值
            // 
            固化炉温度下限值.DataPropertyName = "固化炉温度下限值";
            固化炉温度下限值.HeaderText = "固化炉温度下限值";
            固化炉温度下限值.MinimumWidth = 10;
            固化炉温度下限值.Name = "固化炉温度下限值";
            固化炉温度下限值.ReadOnly = true;
            固化炉温度下限值.Visible = false;
            固化炉温度下限值.Width = 200;
            // 
            // 输送机设定速度
            // 
            输送机设定速度.DataPropertyName = "输送机设定速度";
            输送机设定速度.HeaderText = "输送机设定速度";
            输送机设定速度.MinimumWidth = 10;
            输送机设定速度.Name = "输送机设定速度";
            输送机设定速度.ReadOnly = true;
            输送机设定速度.Visible = false;
            输送机设定速度.Width = 200;
            // 
            // 输送机设定频率
            // 
            输送机设定频率.DataPropertyName = "输送机设定频率";
            输送机设定频率.HeaderText = "输送机设定频率";
            输送机设定频率.MinimumWidth = 10;
            输送机设定频率.Name = "输送机设定频率";
            输送机设定频率.ReadOnly = true;
            输送机设定频率.Visible = false;
            输送机设定频率.Width = 200;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 10;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 200;
            // 
            // btn_DownloadRecipe
            // 
            btn_DownloadRecipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_DownloadRecipe.Location = new Point(8, 408);
            btn_DownloadRecipe.MinimumSize = new Size(1, 1);
            btn_DownloadRecipe.Name = "btn_DownloadRecipe";
            btn_DownloadRecipe.Size = new Size(418, 90);
            btn_DownloadRecipe.Symbol = 61465;
            btn_DownloadRecipe.TabIndex = 3;
            btn_DownloadRecipe.Text = "下载配方";
            btn_DownloadRecipe.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_DownloadRecipe.Click += btn_DownloadRecipe_Click;
            // 
            // btn_ExportRecipe
            // 
            btn_ExportRecipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_ExportRecipe.Location = new Point(228, 318);
            btn_ExportRecipe.MinimumSize = new Size(1, 1);
            btn_ExportRecipe.Name = "btn_ExportRecipe";
            btn_ExportRecipe.Size = new Size(200, 70);
            btn_ExportRecipe.Symbol = 362831;
            btn_ExportRecipe.TabIndex = 2;
            btn_ExportRecipe.Text = "导出配方";
            btn_ExportRecipe.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_ExportRecipe.Click += btn_ExportRecipe_Click;
            // 
            // btn_QueryRecipe
            // 
            btn_QueryRecipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_QueryRecipe.Location = new Point(228, 230);
            btn_QueryRecipe.MinimumSize = new Size(1, 1);
            btn_QueryRecipe.Name = "btn_QueryRecipe";
            btn_QueryRecipe.Size = new Size(200, 70);
            btn_QueryRecipe.Symbol = 559520;
            btn_QueryRecipe.TabIndex = 2;
            btn_QueryRecipe.Text = "查询配方";
            btn_QueryRecipe.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_QueryRecipe.Click += btn_QueryRecipe_Click;
            // 
            // btn_DelRecipe
            // 
            btn_DelRecipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_DelRecipe.Location = new Point(228, 140);
            btn_DelRecipe.MinimumSize = new Size(1, 1);
            btn_DelRecipe.Name = "btn_DelRecipe";
            btn_DelRecipe.Size = new Size(200, 70);
            btn_DelRecipe.Symbol = 362810;
            btn_DelRecipe.TabIndex = 2;
            btn_DelRecipe.Text = "删除配方";
            btn_DelRecipe.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_DelRecipe.Click += btn_DelRecipe_Click;
            // 
            // btn_ImportRecipe
            // 
            btn_ImportRecipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_ImportRecipe.Location = new Point(8, 318);
            btn_ImportRecipe.MinimumSize = new Size(1, 1);
            btn_ImportRecipe.Name = "btn_ImportRecipe";
            btn_ImportRecipe.Size = new Size(200, 70);
            btn_ImportRecipe.Symbol = 362831;
            btn_ImportRecipe.TabIndex = 2;
            btn_ImportRecipe.Text = "导入配方";
            btn_ImportRecipe.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_ImportRecipe.Click += btn_ImportRecipe_Click;
            // 
            // btn_UpdateRecipe
            // 
            btn_UpdateRecipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_UpdateRecipe.Location = new Point(8, 227);
            btn_UpdateRecipe.MinimumSize = new Size(1, 1);
            btn_UpdateRecipe.Name = "btn_UpdateRecipe";
            btn_UpdateRecipe.Size = new Size(200, 70);
            btn_UpdateRecipe.Symbol = 558087;
            btn_UpdateRecipe.TabIndex = 2;
            btn_UpdateRecipe.Text = "修改配方";
            btn_UpdateRecipe.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_UpdateRecipe.Click += btn_UpdateRecipe_Click;
            // 
            // btn_AddRecipe
            // 
            btn_AddRecipe.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_AddRecipe.Location = new Point(8, 140);
            btn_AddRecipe.MinimumSize = new Size(1, 1);
            btn_AddRecipe.Name = "btn_AddRecipe";
            btn_AddRecipe.Size = new Size(200, 70);
            btn_AddRecipe.Symbol = 557670;
            btn_AddRecipe.TabIndex = 2;
            btn_AddRecipe.Text = "添加配方";
            btn_AddRecipe.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btn_AddRecipe.Click += btn_AddRecipe_Click;
            // 
            // txt_ProductType
            // 
            txt_ProductType.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txt_ProductType.Location = new Point(174, 69);
            txt_ProductType.Margin = new Padding(4, 5, 4, 5);
            txt_ProductType.MinimumSize = new Size(1, 16);
            txt_ProductType.Name = "txt_ProductType";
            txt_ProductType.Padding = new Padding(5);
            txt_ProductType.ShowText = false;
            txt_ProductType.Size = new Size(247, 60);
            txt_ProductType.TabIndex = 1;
            txt_ProductType.TextAlignment = ContentAlignment.MiddleLeft;
            txt_ProductType.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("宋体", 11F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(4, 69);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(167, 57);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "产品型号：";
            uiLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userSetValue1
            // 
            userSetValue1.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue1.DeviceVarName = "脱脂设定压力上限值";
            userSetValue1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue1.Location = new Point(22, 59);
            userSetValue1.MinimumSize = new Size(1, 1);
            userSetValue1.Name = "userSetValue1";
            userSetValue1.Size = new Size(517, 67);
            userSetValue1.TabIndex = 0;
            userSetValue1.Text = "userSetValue1";
            userSetValue1.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue1.Unit = "Mpa";
            userSetValue1.VariableName = "脱脂设定压力上限值";
            userSetValue1.VarValue = "";
            // 
            // userSetValue2
            // 
            userSetValue2.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue2.DeviceVarName = "水分炉温度上限值";
            userSetValue2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue2.Location = new Point(540, 59);
            userSetValue2.MinimumSize = new Size(1, 1);
            userSetValue2.Name = "userSetValue2";
            userSetValue2.Size = new Size(506, 67);
            userSetValue2.TabIndex = 0;
            userSetValue2.Text = "userSetValue1";
            userSetValue2.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue2.Unit = "℃";
            userSetValue2.VariableName = "水分炉温度上限值";
            userSetValue2.VarValue = "";
            // 
            // userSetValue3
            // 
            userSetValue3.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue3.DeviceVarName = "脱脂设定压力下限值";
            userSetValue3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue3.Location = new Point(23, 159);
            userSetValue3.MinimumSize = new Size(1, 1);
            userSetValue3.Name = "userSetValue3";
            userSetValue3.Size = new Size(517, 67);
            userSetValue3.TabIndex = 0;
            userSetValue3.Text = "userSetValue1";
            userSetValue3.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue3.Unit = "Mpa";
            userSetValue3.VariableName = "脱脂设定压力下限值";
            userSetValue3.VarValue = "";
            // 
            // userSetValue4
            // 
            userSetValue4.DataType = Sunny.UI.UITextBox.UIEditType.Integer;
            userSetValue4.DeviceVarName = "水分炉温度下限值";
            userSetValue4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue4.Location = new Point(547, 159);
            userSetValue4.MinimumSize = new Size(1, 1);
            userSetValue4.Name = "userSetValue4";
            userSetValue4.Size = new Size(498, 67);
            userSetValue4.TabIndex = 0;
            userSetValue4.Text = "userSetValue1";
            userSetValue4.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue4.Unit = "℃";
            userSetValue4.VariableName = "水分炉温度下限值";
            userSetValue4.VarValue = "";
            // 
            // userSetValue7
            // 
            userSetValue7.DataType = Sunny.UI.UITextBox.UIEditType.Integer;
            userSetValue7.DeviceVarName = "粗洗喷淋泵过载上限值";
            userSetValue7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue7.Location = new Point(-5, 259);
            userSetValue7.MinimumSize = new Size(1, 1);
            userSetValue7.Name = "userSetValue7";
            userSetValue7.Size = new Size(545, 67);
            userSetValue7.TabIndex = 0;
            userSetValue7.Text = "userSetValue1";
            userSetValue7.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue7.Unit = "KW";
            userSetValue7.VariableName = "粗洗喷淋泵过载上限值";
            userSetValue7.VarValue = "";
            // 
            // userSetValue8
            // 
            userSetValue8.DataType = Sunny.UI.UITextBox.UIEditType.Integer;
            userSetValue8.DeviceVarName = "离心风机过载上限值";
            userSetValue8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue8.Location = new Point(518, 259);
            userSetValue8.MinimumSize = new Size(1, 1);
            userSetValue8.Name = "userSetValue8";
            userSetValue8.Size = new Size(527, 67);
            userSetValue8.TabIndex = 0;
            userSetValue8.Text = "userSetValue1";
            userSetValue8.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue8.Unit = "KW";
            userSetValue8.VariableName = "冷却室离心风机过载上限值";
            userSetValue8.VarValue = "";
            // 
            // userSetValue9
            // 
            userSetValue9.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue9.DeviceVarName = "粗洗液位下限值";
            userSetValue9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue9.Location = new Point(78, 359);
            userSetValue9.MinimumSize = new Size(1, 1);
            userSetValue9.Name = "userSetValue9";
            userSetValue9.Size = new Size(463, 67);
            userSetValue9.TabIndex = 0;
            userSetValue9.Text = "userSetValue1";
            userSetValue9.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue9.Unit = "m³";
            userSetValue9.VariableName = "粗洗液液位下限值";
            userSetValue9.VarValue = "";
            // 
            // userSetValue10
            // 
            userSetValue10.DataType = Sunny.UI.UITextBox.UIEditType.Integer;
            userSetValue10.DeviceVarName = "固化炉温度上限值";
            userSetValue10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue10.Location = new Point(546, 359);
            userSetValue10.MinimumSize = new Size(1, 1);
            userSetValue10.Name = "userSetValue10";
            userSetValue10.Size = new Size(495, 67);
            userSetValue10.TabIndex = 0;
            userSetValue10.Text = "userSetValue1";
            userSetValue10.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue10.Unit = "℃";
            userSetValue10.VariableName = "固化炉温度上限值";
            userSetValue10.VarValue = "";
            // 
            // userSetValue11
            // 
            userSetValue11.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue11.DeviceVarName = "陶化喷淋泵过载上限值";
            userSetValue11.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue11.Location = new Point(-4, 459);
            userSetValue11.MinimumSize = new Size(1, 1);
            userSetValue11.Name = "userSetValue11";
            userSetValue11.Size = new Size(546, 67);
            userSetValue11.TabIndex = 0;
            userSetValue11.Text = "userSetValue1";
            userSetValue11.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue11.Unit = "Mpa";
            userSetValue11.VariableName = "陶化喷淋泵过载上限值";
            userSetValue11.VarValue = "";
            // 
            // userSetValue12
            // 
            userSetValue12.DataType = Sunny.UI.UITextBox.UIEditType.Integer;
            userSetValue12.DeviceVarName = "固化炉温度下限值";
            userSetValue12.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue12.Location = new Point(542, 459);
            userSetValue12.MinimumSize = new Size(1, 1);
            userSetValue12.Name = "userSetValue12";
            userSetValue12.Size = new Size(494, 67);
            userSetValue12.TabIndex = 0;
            userSetValue12.Text = "userSetValue1";
            userSetValue12.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue12.Unit = "℃";
            userSetValue12.VariableName = "固化炉温度下限值";
            userSetValue12.VarValue = "";
            // 
            // userSetValue13
            // 
            userSetValue13.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue13.DeviceVarName = "精洗喷淋泵过载上限值";
            userSetValue13.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue13.Location = new Point(-5, 559);
            userSetValue13.MinimumSize = new Size(1, 1);
            userSetValue13.Name = "userSetValue13";
            userSetValue13.Size = new Size(546, 67);
            userSetValue13.TabIndex = 0;
            userSetValue13.Text = "userSetValue1";
            userSetValue13.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue13.Unit = "KW";
            userSetValue13.VariableName = "精洗喷淋泵过载上限值";
            userSetValue13.VarValue = "";
            // 
            // userSetValue14
            // 
            userSetValue14.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue14.DeviceVarName = "输送机设定速度";
            userSetValue14.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue14.Location = new Point(572, 559);
            userSetValue14.MinimumSize = new Size(1, 1);
            userSetValue14.Name = "userSetValue14";
            userSetValue14.Size = new Size(463, 67);
            userSetValue14.TabIndex = 0;
            userSetValue14.Text = "userSetValue1";
            userSetValue14.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue14.Unit = "m/s";
            userSetValue14.VariableName = "输送机设定速度";
            userSetValue14.VarValue = "";
            // 
            // userSetValue15
            // 
            userSetValue15.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue15.DeviceVarName = "精洗液位下限值";
            userSetValue15.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue15.Location = new Point(74, 659);
            userSetValue15.MinimumSize = new Size(1, 1);
            userSetValue15.Name = "userSetValue15";
            userSetValue15.Size = new Size(463, 67);
            userSetValue15.TabIndex = 0;
            userSetValue15.Text = "userSetValue1";
            userSetValue15.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue15.Unit = "m³";
            userSetValue15.VariableName = "精洗液液位下限值";
            userSetValue15.VarValue = "";
            // 
            // userSetValue16
            // 
            userSetValue16.DataType = Sunny.UI.UITextBox.UIEditType.Double;
            userSetValue16.DeviceVarName = "输送机设定频率";
            userSetValue16.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userSetValue16.Location = new Point(553, 659);
            userSetValue16.MinimumSize = new Size(1, 1);
            userSetValue16.Name = "userSetValue16";
            userSetValue16.Size = new Size(481, 67);
            userSetValue16.TabIndex = 0;
            userSetValue16.Text = "userSetValue1";
            userSetValue16.TextAlignment = ContentAlignment.MiddleCenter;
            userSetValue16.Unit = "HZ";
            userSetValue16.VariableName = "输送机设定频率";
            userSetValue16.VarValue = "";
            // 
            // uiTitlePanel1
            // 
            uiTitlePanel1.Controls.Add(userSetValue16);
            uiTitlePanel1.Controls.Add(userSetValue15);
            uiTitlePanel1.Controls.Add(userSetValue14);
            uiTitlePanel1.Controls.Add(userSetValue13);
            uiTitlePanel1.Controls.Add(userSetValue12);
            uiTitlePanel1.Controls.Add(userSetValue11);
            uiTitlePanel1.Controls.Add(userSetValue10);
            uiTitlePanel1.Controls.Add(userSetValue9);
            uiTitlePanel1.Controls.Add(userSetValue8);
            uiTitlePanel1.Controls.Add(userSetValue7);
            uiTitlePanel1.Controls.Add(userSetValue4);
            uiTitlePanel1.Controls.Add(userSetValue3);
            uiTitlePanel1.Controls.Add(userSetValue2);
            uiTitlePanel1.Controls.Add(userSetValue1);
            uiTitlePanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTitlePanel1.Location = new Point(1, 4);
            uiTitlePanel1.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel1.MinimumSize = new Size(1, 1);
            uiTitlePanel1.Name = "uiTitlePanel1";
            uiTitlePanel1.Padding = new Padding(1, 35, 1, 1);
            uiTitlePanel1.ShowText = false;
            uiTitlePanel1.Size = new Size(1054, 837);
            uiTitlePanel1.TabIndex = 0;
            uiTitlePanel1.Text = "配方参数";
            uiTitlePanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // PageRecipeManage
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1508, 831);
            Controls.Add(uiTitlePanel2);
            Controls.Add(uiTitlePanel1);
            Name = "PageRecipeManage";
            Symbol = 162333;
            Text = "配方管理";
            uiTitlePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Recipe).EndInit();
            uiTitlePanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txt_ProductType;
        private Sunny.UI.UISymbolButton btn_AddRecipe;
        private Sunny.UI.UISymbolButton btn_DelRecipe;
        private Sunny.UI.UISymbolButton btn_ExportRecipe;
        private Sunny.UI.UISymbolButton btn_QueryRecipe;
        private Sunny.UI.UISymbolButton btn_ImportRecipe;
        private Sunny.UI.UISymbolButton btn_UpdateRecipe;
        private Sunny.UI.UISymbolButton btn_DownloadRecipe;
        private Sunny.UI.UIDataGridView dgv_Recipe;
        private DataGridViewTextBoxColumn 产品类型;
        private DataGridViewTextBoxColumn 脱脂设定压力上限值;
        private DataGridViewTextBoxColumn 脱脂设定压力下限值;
        private DataGridViewTextBoxColumn 粗洗喷淋泵过载上限值;
        private DataGridViewTextBoxColumn 粗洗液液位下限值;
        private DataGridViewTextBoxColumn 陶化喷淋泵过载上限值;
        private DataGridViewTextBoxColumn 精洗喷淋泵过载上限值;
        private DataGridViewTextBoxColumn 精洗液液位下限值;
        private DataGridViewTextBoxColumn 水分炉温度上限值;
        private DataGridViewTextBoxColumn 水分炉温度下限值;
        private DataGridViewTextBoxColumn 冷却室离心风机过载上限值;
        private DataGridViewTextBoxColumn 固化炉温度上限值;
        private DataGridViewTextBoxColumn 固化炉温度下限值;
        private DataGridViewTextBoxColumn 输送机设定速度;
        private DataGridViewTextBoxColumn 输送机设定频率;
        private DataGridViewTextBoxColumn Id;
        private UserSetValue userSetValue1;
        private UserSetValue userSetValue2;
        private UserSetValue userSetValue3;
        private UserSetValue userSetValue4;
        private UserSetValue userSetValue7;
        private UserSetValue userSetValue8;
        private UserSetValue userSetValue9;
        private UserSetValue userSetValue10;
        private UserSetValue userSetValue11;
        private UserSetValue userSetValue12;
        private UserSetValue userSetValue13;
        private UserSetValue userSetValue14;
        private UserSetValue userSetValue15;
        private UserSetValue userSetValue16;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
    }
}