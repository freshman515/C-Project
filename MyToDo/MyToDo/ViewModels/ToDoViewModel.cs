using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToDo.Common.Models;
using Prism.Mvvm;
using Prism.Commands;
using MyToDo.Service;
using MyToDo.Shared.Parameters;
using MyToDo.Shared.Dtos;
using Prism.Ioc;
using Prism.Regions;
using MyToDo.Shared.Contact;
using MyToDo.Common;
using MyToDo.Extensins;
using Prism.Services.Dialogs;
using Prism.Events;
namespace MyToDo.ViewModels {
    public class ToDoViewModel : NavigationViewModel {
        /// <summary>
        /// 都是依赖注入得到的参数
        /// </summary>
        /// <param name="service">用于调用api Todo的服务</param>
        /// <param name="container">用于传递给基类navigationViewModel构造函数的容器</param>
        public ToDoViewModel(IToDoService service, IContainerProvider container,IEventAggregator aggregator) : base(container) {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            this.service = service;
            this.aggregator = aggregator;
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<ToDoDto>(Selected);
            DeleteCommand = new DelegateCommand<ToDoDto>(Delete);
            DeleteAllCommand = new DelegateCommand(DeleteAll);
            dialogHost = container.Resolve<IDialogHostService>();
            
        }

        private async void DeleteAll() {

            try {
                if(ToDoDtos.Count == 0) {
                    aggregator.SendMessage("当前暂无待办事项，请添加","ToDo");
                    return;
                }
                var dialogResult = await dialogHost.Question("温馨提示", $"确认全部删除吗?");
                if (dialogResult.Result != ButtonResult.OK) {
                    return;
                }
                UpdateLoading(true);
                foreach (var v in ToDoDtos.ToList()) {
                    var deleteResult = await service.DeleteAsync(v.Id);
                    if (deleteResult.Status) {
                        var model = ToDoDtos.FirstOrDefault(i => i.Id == v.Id);
                        if (model != null) {
                            ToDoDtos.Remove(model);
                            aggregator.SendMessage("全部删除成功", "ToDo");
                        }
                    }
                }

            } catch (Exception) {

                throw;
            } finally {
                UpdateLoading(false);
            }
        }

        private readonly IDialogHostService dialogHost;

        private async void Delete(ToDoDto dto) {
            try {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除待办事项:{dto.Title}?");
                if (dialogResult.Result != ButtonResult.OK) {
                    return;
                }
                UpdateLoading(true);
                var dtoResult = await service.DeleteAsync(dto.Id);
                if (dtoResult.Status) {
                    var model = ToDoDtos.FirstOrDefault(i => i.Id == dto.Id);
                    if (model != null) {
                        ToDoDtos.Remove(model);
                        aggregator.SendMessage("删除成功", "ToDo");
                    }
                }

            } catch (Exception) {

                throw;
            } finally {
                UpdateLoading(false);
            }
        }

        private void Execute(string obj) {
            switch (obj) {
                case "新增": Add(); break;
                case "查询": GetDataAsync(); break;
                case "保存": Save(); break;
            }
        }

        private async void Save() {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title)
                || string.IsNullOrWhiteSpace(CurrentDto.Content)) return;

            try {
                UpdateLoading(true);
                if (CurrentDto.Id > 0) {
                    //此时数据库里面的内容以
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if (updateResult != null) {
                        var todo = ToDoDtos.FirstOrDefault(i => i.Id == currentDto.Id);
                        if (todo != null) {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                            todo.Status = CurrentDto.Status;
                            IsRightDrawerOpen = false;
                            aggregator.SendMessage("修改成功", "ToDo");
                        }
                    }
                } else {
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.Status) {
                        ToDoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                        aggregator.SendMessage("添加成功", "ToDo");
                    }
                }

            } catch (Exception) {

            } finally {
                UpdateLoading(false);
            }
        }

        private async void Selected(ToDoDto dto) {
            try {
                UpdateLoading(true);
                ApiResponse<ToDoDto> todo = await service.GetByIdAsync(dto.Id);
                if (todo.Status) {
                    CurrentDto = todo.Result;
                    IsRightDrawerOpen = true;
                }
            } catch (Exception) {
                throw;
            } finally {
                UpdateLoading(false);
            }

        }

        /// <summary>
        /// 编辑选中时，新增对象
        /// </summary>
        private ToDoDto currentDto;

        public ToDoDto CurrentDto {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }

        private string search;
        /// <summary>
        /// 搜索条件
        /// </summary>
        public string Search {
            get { return search; }
            set {
                search = value; RaisePropertyChanged();
            }
        }


        private int selectIndex;

        /// <summary>
        /// 下拉列表选中状态值
        /// </summary>
        public int SelectIndex {
            get { return selectIndex; }
            set {
                selectIndex = value;
                RaisePropertyChanged();
                UpdateLoading(true);
                GetDataAsync();
                UpdateLoading(false);
            }
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
            CurrentDto = new ToDoDto();
            IsRightDrawerOpen = true;
        }

        /// <summary>
        /// 添加待办
        /// </summary>
        public DelegateCommand<string> ExecuteCommand { get; set; }
        public DelegateCommand<ToDoDto> SelectedCommand { get; set; }
        public DelegateCommand<ToDoDto> DeleteCommand { get; set; }
        public DelegateCommand DeleteAllCommand { get; set; }

        private ObservableCollection<ToDoDto> toDoDtos;
        private readonly IToDoService service;
        private readonly IEventAggregator aggregator;

        public ObservableCollection<ToDoDto> ToDoDtos {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// 调用api 中的getall接口获得数据，同时发布一个UpdateLoading的事件，
        ///
        /// </summary>
        async void GetDataAsync() {
            //发布一个事件消息，参数为new UpdateModel(){IsOpen = true}MyProperty
            UpdateLoading(true);

            int? status = SelectIndex == 0 ? null : SelectIndex == 1 ? 1 : 0;
            var todoResult = await service.GetAllFilterAsync(new ToDoParameter() {
                PageIndex = 0,
                PageSize = 100,
                Search = this.Search,
                Status = status
            });


            if (todoResult.Status) {
                ToDoDtos.Clear();
                foreach (var item in todoResult.Result.Items) {
                    ToDoDtos.Add(item);
                }
            }
            //再次发送一个消息事件
            UpdateLoading(false);
        }
        /// <summary>
        /// 这个方法是 导航到该页面时自动调用 的方法。它调用了基类 NavigationViewModel 的 OnNavigatedTo 方法，并在此之后调用 GetDataAsync() 获取待办数据。
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext) {
            base.OnNavigatedTo(navigationContext);
            if (navigationContext.Parameters.ContainsKey("Value")) {
                //获取导航所传过来的参数
                SelectIndex = navigationContext.Parameters.GetValue<int>("Value");
            } else {
                SelectIndex = 0;
            }
            GetDataAsync();
        }
    }
}
