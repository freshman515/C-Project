﻿namespace SprayProcessSCADASystemOnWinform {
    partial class UserDeviceUnitControl {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            lbl_DeviceName = new Sunny.UI.UILabel();
            sw_Device = new Sunny.UI.UISwitch();
            uiTableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 2;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            uiTableLayoutPanel1.Controls.Add(lbl_DeviceName, 0, 0);
            uiTableLayoutPanel1.Controls.Add(sw_Device, 1, 0);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Font = new Font("微软雅黑", 12F);
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 1;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Size = new Size(360, 90);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
            // 
            // lbl_DeviceName
            // 
            lbl_DeviceName.BackColor = Color.Transparent;
            lbl_DeviceName.Dock = DockStyle.Fill;
            lbl_DeviceName.Font = new Font("微软雅黑", 12F);
            lbl_DeviceName.ForeColor = Color.FromArgb(48, 48, 48);
            lbl_DeviceName.Location = new Point(3, 0);
            lbl_DeviceName.Name = "lbl_DeviceName";
            lbl_DeviceName.Size = new Size(174, 90);
            lbl_DeviceName.TabIndex = 0;
            lbl_DeviceName.Text = "工位名称";
            lbl_DeviceName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sw_Device
            // 
            sw_Device.Dock = DockStyle.Fill;
            sw_Device.Font = new Font("微软雅黑", 12F);
            sw_Device.Location = new Point(183, 3);
            sw_Device.MinimumSize = new Size(1, 1);
            sw_Device.Name = "sw_Device";
            sw_Device.Size = new Size(174, 84);
            sw_Device.TabIndex = 1;
            sw_Device.Text = "uiSwitch1";
            sw_Device.Click += sw_Device_Click;
            // 
            // UserDeviceUnitControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(uiTableLayoutPanel1);
            Name = "UserDeviceUnitControl";
            RectColor = Color.Transparent;
            Size = new Size(360, 90);
            uiTableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel lbl_DeviceName;
        private Sunny.UI.UISwitch sw_Device;
    }
}
