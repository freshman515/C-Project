using MaterialDesignThemes.Wpf;
using MyToDo.Common;
using MyToDo.Common.Models;
using MyToDo.Extensins;
using MyToDo.Service;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels {
    public class MemoViewModel : NavigationViewModel {
        public MemoViewModel(IMemoService service, IContainerProvider container) : base(container) {
            MemoDtos = new ObservableCollection<MemoDto>();
            this.service = service;
            AddCommand = new DelegateCommand(Add);
            SelectedCommand = new DelegateCommand<MemoDto>(Selected);
            ExecuteCommand = new DelegateCommand<string>(Execute);
            DeletedCommand = new DelegateCommand<MemoDto>(Delete);
            dialogHost = container.Resolve<IDialogHostService>();
        }

        
        private void Execute(string obj) {
            switch (obj) {
                case "新增": Add(); break;
                case "保存": Save(); break;
                case "查询": GetDataAsync(); break;
            }

        }
        private readonly IDialogHostService dialogHost;
       
        private async void Delete(MemoDto dto) {
            try {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除备忘录：{dto.Title}?");
                if (dialogResult.Result != ButtonResult.OK) {
                    return;
                }
                UpdateLoading(true);
                var result = await service.DeleteAsync(dto.Id);
                if (result.Status) {
                    var memo = MemoDtos.FirstOrDefault(i => dto.Id == i.Id);
                    if (memo != null) {
                        MemoDtos.Remove(memo);
                    }
                }

                   
            } catch (Exception) {

                throw;
            } finally {
                UpdateLoading(false);
            }
        }

        private async void Save() {
            try {
                UpdateLoading(true);
                if (CurrentDto.Id > 0) {  //更新
                    var result = await service.UpdateAsync(CurrentDto);
                    if (result.Status) {
                        var memo = MemoDtos.FirstOrDefault(i => i.Id == result.Result.Id);
                        if (memo != null) {
                            memo.Title = result.Result.Title;
                            memo.Content = result.Result.Content;
                            IsRightDrawerOpen = false;
                        }
                    }
                } else { //新增
                    var result = await service.AddAsync(CurrentDto);
                    if (result.Status) {
                        MemoDtos.Add(result.Result);
                        isRightDrawerOpen = false;
                    }
                }
            } catch (Exception) {

                throw;
            } finally {
                UpdateLoading(false);
            }
        }

        private async void Selected(MemoDto dto) {
            try {
                UpdateLoading(true);
                var result = await service.GetByIdAsync(dto.Id);
                if (result.Status) {
                    CurrentDto = result.Result;
                    IsRightDrawerOpen = true;
                }

            } catch (Exception) {
                throw;
            } finally {
                UpdateLoading(false);
            }
        }

        private string searchText;

        /// <summary>
        /// 查找文本
        /// </summary>
        public string SearchText {
            get { return searchText; }
            set { searchText = value; }
        }

        private bool isRightDrawerOpen;
        /// <summary>
        /// 右侧抽屉是否打开
        /// </summary>
        public bool IsRightDrawerOpen {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        private void Add() {
            CurrentDto = new MemoDto();
            IsRightDrawerOpen = true;
        }

        /// <summary>
        /// 添加待办
        /// </summary>
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand<string> ExecuteCommand { get; set; }
        public DelegateCommand<MemoDto> SelectedCommand { get; set; }
        public DelegateCommand<MemoDto> DeletedCommand { get; set; }
        private ObservableCollection<MemoDto> memoDtos;
        private readonly IMemoService service;

        private MemoDto currentDto;

        public MemoDto CurrentDto {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }


        public ObservableCollection<MemoDto> MemoDtos {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }
        async void GetDataAsync() {
            UpdateLoading(true);
            var memoResult = await service.GetAllAsync(new Shared.Parameters.QueryParameter() {
                PageIndex = 0,
                PageSize = 20,
                Search = SearchText

            });

            if (memoResult.Status) {
                MemoDtos.Clear();
                foreach (var item in memoResult.Result.Items) {
                    MemoDtos.Add(item);
                }
            }
            UpdateLoading(false);
        }
        public override void OnNavigatedTo(NavigationContext navigationContext) {
            base.OnNavigatedTo(navigationContext);
            GetDataAsync();
        }
    }
}
