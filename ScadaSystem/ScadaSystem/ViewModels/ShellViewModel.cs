using CommunityToolkit.Mvvm.ComponentModel;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.ViewModels {
    public class ShellViewModel : ObservableObject, IInjectable {
        public ShellViewModel() {
            InitDate();
        }

        /// <summary>
        /// 初始化数据库 codefirst 创建表及初始数据
        /// </summary>
        private void InitDate() {
            if (false) {
                //建库
                // SqlSugarHelper.Db.DbMaintenance.CreateDatabase();
                //建表
                //SqlSugarHelper.Db.CodeFirst.InitTables<UserEntity>();
                //SqlSugarHelper.Db.CodeFirst.InitTables<MenuEntity>();
                SqlSugarHelper.Db.CodeFirst.InitTables<ScadaReadDataEntity>();
            }
            //插入一些用户表数据
            if (false) {
                var UserList = new List<UserEntity>();
                UserList.Add(new UserEntity { Username = "root", Password = "root", Role = 0 });
                UserList.Add(new UserEntity { Username = "test", Password = "test", Role = 1 });
                UserList.Add(new UserEntity { Username = "test123", Password = "test123", Role = 1 });
                SqlSugarHelper.Db.Insertable(UserList).ExecuteCommand();
            }
            if (false) {
                var menuList = new List<MenuEntity>();
                menuList.Add(new MenuEntity { MenuName = " 首页 ", Icon = "Home", View = "IndexView", Sort = 1 });
                menuList.Add(new MenuEntity { MenuName = "设备总控", Icon = "Devices", View = "DeviceView", Sort = 2 });
                menuList.Add(new MenuEntity { MenuName = "配方管理", Icon = "AirFilter", View = "FormulaView", Sort = 3 });
                menuList.Add(new MenuEntity { MenuName = "参数管理", Icon = "AlphabetCBoxOutline", View = "ParamsView", Sort = 4 });
                menuList.Add(new MenuEntity { MenuName = "数据查询", Icon = "DataUsage", View = "DataQueryView", Sort = 5 });
                menuList.Add(new MenuEntity { MenuName = "数据趋势", Icon = "ChartFinance", View = "ChartView", Sort = 6 });
                menuList.Add(new MenuEntity { MenuName = "报表管理", Icon = "FileReport", View = "ReportView", Sort = 7 });
                menuList.Add(new MenuEntity { MenuName = "日志管理", Icon = "NotebookOutline", View = "LogView", Sort = 8 });
                menuList.Add(new MenuEntity { MenuName = "用户管理", Icon = "UserMultipleOutline", View = "UserView", Sort = 9 });
                SqlSugarHelper.Db.Insertable(menuList).ExecuteCommand();
            }
            if (false) {
                var scadaReadDataList = new List<ScadaReadDataEntity>();
                for (int i = 0; i < 100; i++) {
                    var scadaReadData = new ScadaReadDataEntity() {
                        DegreasingSprayPumpPressure = GetRandomFloat(0.5f, 5.0f),
                        DegreasingPhValue = GetRandomFloat(6.0f, 9.0f),
                        RoughWashSprayPumpPressure = GetRandomFloat(1.0f, 4.0f),
                        PhosphatingSprayPumpPressure = GetRandomFloat(0.8f, 3.5f),
                        PhosphatingPhValue = GetRandomFloat(4.0f, 7.0f),
                        FineWashSprayPumpPressure = GetRandomFloat(1.2f, 4.5f),
                        MoistureFurnaceTemperature = GetRandomFloat(40.0f, 80.0f),
                        CuringFurnaceTemperature = GetRandomFloat(120.0f, 200.0f),
                        FactoryTemperature = GetRandomFloat(15.0f, 35.0f),
                        FactoryHumidity = GetRandomFloat(30.0f, 80.0f),
                        ProductionCount = GetRandomFloat(0, 1000),
                        DefectiveCount = GetRandomFloat(0, 50),
                        ProductionPace = GetRandomFloat(0.5f, 2.0f),
                        AccumulatedAlarms = GetRandomFloat(0, 20),
                        CreateTime = DateTime.Now.AddDays(GetRandomFloat(1f, 10f)),
                        UpdateTime = DateTime.Now.AddDays(GetRandomFloat(1f, 10f))
                    };
                    scadaReadDataList.Add(scadaReadData);
                }
                SqlSugarHelper.Db.Insertable(scadaReadDataList).ExecuteCommand();
            }
        }
        private float GetRandomFloat(float min, float max) { 
            return (float)(new Random().NextDouble() * (max - min)+min);
        }
    }
}
