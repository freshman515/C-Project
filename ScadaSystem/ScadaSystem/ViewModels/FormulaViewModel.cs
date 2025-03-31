using AngleSharp.Dom;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Masuit.Tools;
using MaterialDesignThemes.Wpf;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using ScadaSystem.Services;
using ScadaSystem.Usc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScadaSystem.ViewModels {
    public partial class FormulaViewModel : ObservableObject {
        public FormulaViewModel(UserSession userSession) {
            this.userSession = userSession;
        }
        [ObservableProperty]
        ObservableCollection<FormulaEntity> formulaList = new();
        [ObservableProperty]
        FormulaEntity selectFormula;
        [ObservableProperty]
        FormulaEntity currentFormula;
        private readonly UserSession userSession;

        [RelayCommand]
        void Selected(FormulaEntity entity) {
            FormulaList.ForEach(i => i.IsSelected = false);
            entity.IsSelected = !entity.IsSelected;
            this.SelectFormula = entity;
            CurrentFormula = entity.DeepClone();

        }
        [RelayCommand]
        void QueryFormula() {
            FormulaList.Clear();
            SqlSugarHelper.Db.Queryable<FormulaEntity>()
                 .OrderBy(i => i.CreateTime, SqlSugar.OrderByType.Desc)
                 .ToList().ForEach(i => FormulaList.Add(i));
        }
        [RelayCommand]
        void NewFormula() {
            SelectFormula = null;
            CurrentFormula = new FormulaEntity();
        }
        [RelayCommand]
        void SaveFormula() {
            try {
                //验证必填的字段
                if (CurrentFormula.Name.IsNullOrEmpty()) {
                    userSession.ShowMessage("名称不能为空");
                    return;
                }
                if (SelectFormula != null) {
                    //是现有配方
                    var index = FormulaList.IndexOf(SelectFormula);
                    if (index >= 0) {
                        CurrentFormula.UpdateTime = DateTime.Now;
                        
                        FormulaList[index] = CurrentFormula;
                    }
                    var rows = SqlSugarHelper.Db.Updateable<FormulaEntity>(FormulaList).ExecuteCommand();
                    if (rows > 0) {
                        userSession.ShowMessage("保存成功");
                    } else {
                        userSession.ShowMessage("保存失败");
                    }
                } else {
                    //如果是新配方
                    CurrentFormula.CreateTime = DateTime.Now;
                    CurrentFormula.UpdateTime = DateTime.Now;
                    FormulaList.Add(CurrentFormula);
                    FormulaList.ForEach(i => i.IsSelected = false);
                    CurrentFormula.IsSelected = true;
                    var rows = SqlSugarHelper.Db.Insertable<FormulaEntity>(FormulaList).ExecuteCommand();
                    if (rows > 0) {
                        userSession.ShowMessage("保存成功");
                    } else {
                        userSession.ShowMessage("保存失败");
                    }
                }
                //将所有配方插入数据库
            
            } catch (Exception e) {

                throw;
            }
        }
        [RelayCommand]
        async void DeleteFormula() {
            if (SelectFormula == null) {
                userSession.ShowMessage("请选择要删除的配方");
                return;
            }
            var result = (bool)await DialogHost.Show(new Dialog($"确认删除{SelectFormula.Name}吗", MessageBoxButton.YesNo), "ShellDialog");
            if (result) {
                FormulaList.Remove(SelectFormula);
                var rows = SqlSugarHelper.Db.Deleteable(SelectFormula).ExecuteCommand();
                if (rows > 0) {
                    userSession.ShowMessage("删除成功");
                    CurrentFormula = null;
                    SelectFormula = null;
                } else {
                    userSession.ShowMessage("删除失败");
                }
            }
        }
        [RelayCommand]
        void DownloadFormula() {

        }

    }
}
