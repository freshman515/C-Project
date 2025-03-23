using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastReport;
using FastReport.Export.Pdf;
using Mapster;
using MiniExcelLibs;
using ScadaSystem.Helper;
using ScadaSystem.Helper.Dtos;
using ScadaSystem.Manager;
using ScadaSystem.Models;
using ScadaSystem.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScadaSystem.ViewModels {
    public partial class DataQueryViewModel : ObservableObject {

        [ObservableProperty]
        List<ScadaReadDataEntity> scadaReadDataList;

        [ObservableProperty]
        DateTime startTime = DateTime.Now.AddDays(-5);

        [ObservableProperty]
        DateTime endTime = DateTime.Now.AddDays(30);

        #region 分页实现
        [ObservableProperty]
        int pageSize = 20;

        [ObservableProperty]
        int currentPage = 1;

        //值改变触发的方法
        partial void OnCurrentPageChanged(int value) {
            Search();
        }

        [ObservableProperty]
        int totalPages = 1;
        private readonly UserSession userSession;

        [RelayCommand]
        void GoToFirstPage() {
            CurrentPage = 1;
        }
        [RelayCommand]
        void GoToNextPage() {
            if (CurrentPage < TotalPages) {
                CurrentPage++;
            }
        }
        [RelayCommand]
        void GoToPreviousPage() {
            if (CurrentPage > 1) {
                CurrentPage--;
            }
        }
        [RelayCommand]
        void GoToLastPage() {
            CurrentPage = totalPages;
        }



        #endregion

        public DataQueryViewModel(ScadaReadDataManager scadaReadDataManager, UserSession userSession) {
            ScadaReadDataManager = scadaReadDataManager;
            this.userSession = userSession;
        }

        public ScadaReadDataManager ScadaReadDataManager { get; }

        [RelayCommand]
        async void Load() {
            Search();
        }

        [RelayCommand]
        async void Search() {
            StartTime = DateTime.Now.AddDays(3);
            EndTime = DateTime.Now.AddYears(6);
            //int totalNumber = 1;
            //ScadaReadDataList = SqlSugarHelper.Db.Queryable<ScadaReadDataEntity>()
            //    .ToPageList(CurrentPage, PageSize, ref totalNumber);
            //TotalPages = (int)Math.Ceiling((double)totalNumber/PageSize);
            var dto = new QueryReadDataByDateDto() {
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                PageSize = this.PageSize,
                TotalPages = this.CurrentPage // 当前页数
            };

            var res = await ScadaReadDataManager.GetListByPagingAsync(dto);

            if (res.Status) {
                ScadaReadDataList = res.Data.Adapt<List<ScadaReadDataEntity>>(); // 赋值查询数据
                TotalPages = res.TotalPages; // 赋值总页数
            } else {
                userSession.ShowMessage(res.Message);
            }
        }
        [RelayCommand]
        async void ResetSearch() {
            StartTime = DateTime.Now.AddDays(3);
            EndTime = DateTime.Now.AddYears(6);
            Search();
        }

        [RelayCommand]
        void OutPage() {
            SaveByMiniExcel<ReadDataAddDto>(ScadaReadDataList.Adapt<List<ReadDataAddDto>>());
        }
        [RelayCommand]
        async void OutAll() {
            var res = await ScadaReadDataManager.GetReadDataListAsync();
            if (res.Status) {
                SaveByMiniExcel(res.Data);
            }
        }
        [RelayCommand]
        void OutputReport() {

        }
        [RelayCommand]
        void PreviewReport() {
            //try {
            //    var dataSet = ScadaReadDataList.ConvertToDataSet();
            //    // 检查 DataSet 是否有表
            //    if (dataSet.Tables.Count == 0) {
            //        Console.WriteLine("❌ 错误：DataSet 为空，未包含任何表！");
            //        return;
            //    }
            //    dataSet.Tables[0].TableName = "ScadaReadData";
            //    var report = new Report();
            //    var path = $@"{Environment.CurrentDirectory}\Configs\report.frx";
            //    report.Load(path);
            //    report.RegisterData(dataSet);
            //    report.Prepare();
            //    report.Show();
            //    report.Dispose();
            //} catch (Exception) {

            //    throw;
            //}
        }

        [RelayCommand]
        void DesignReport() {
            try {
                var report = new Report();
                //加载报表设计文件
                var path = $@"{Environment.CurrentDirectory}\Configs\report.frx";
                report.Load(path);
                report.Design();
                //导出PDF
                var pdfExport = new PDFExport();
                pdfExport.Export(report);
                report.Dispose();
            } catch (Exception e) {
                userSession.ShowMessage(e.Message);
                throw;
            }
        }

        private void SaveByMiniExcel<T>(List<T> list) {
            if (list.Count < 1) {
                return;
            }
            //根目录
            var rootPath = AppDomain.CurrentDomain.BaseDirectory + "\\Excels\\";
            if (!Directory.Exists(rootPath)) {
                Directory.CreateDirectory(rootPath);
            }

            //文件路径
            var path = rootPath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            try {
                MiniExcel.SaveAs(path, list);
                userSession.ShowMessage($"导出成功{path}");
            } catch (Exception ex) {
                userSession.ShowMessage($"导出异常{ex.Message}");
                throw;
            }

        }

    }
}
