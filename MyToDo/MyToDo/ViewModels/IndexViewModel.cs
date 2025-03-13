using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MyToDo.Common.Models;
using System.Collections.ObjectModel;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Services.Dialogs;
using MyToDo.Common;
using Prism.Ioc;
using MyToDo.Service;
using Prism.Regions;
using ImTools;
using MyToDo.Extensins;
using Prism.Events;

namespace MyToDo.ViewModels {
    public class IndexViewModel : NavigationViewModel {
        public IndexViewModel(IContainerProvider container, IDialogHostService dialog,
            IToDoService toDoService, IMemoService memoService,IRegionManager regionManager,IEventAggregator aggregator) : base(container) {
            CreateTaskBars();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            EditToDoCommand = new DelegateCommand<ToDoDto>(AddToDo);
            ToDoCompletedCommand = new DelegateCommand<ToDoDto>(Completed);
            NavigateCommand = new DelegateCommand<TaskBar>(Navigate);
            this.dialog = dialog;
            this.toDoService = toDoService;
            this.memoService = memoService;
            this.regionManager = regionManager;
            this.aggregator = aggregator;
            aggregator.RegisterUserName(arg => {
                UserName = arg;
                UpdateTitle();
            });
           
            Title = $"你好，{AppSession.UserName}，现在是{DateTime.Now.GetDateTimeFormats('D')[1].ToString()}";
            
           
        }
        public void UpdateTitle() {
            // 假设你在这里更新窗口的标题
            Title = $"你好，{UserName}，现在是{DateTime.Now.GetDateTimeFormats('D')[1]}";
        }
        private string userName;

        public string UserName {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }


        private void Navigate(TaskBar bar) {
            if (string.IsNullOrWhiteSpace(bar.Target)) {
                return;
            }
            NavigationParameters param = new NavigationParameters();
            if(bar.Title == "已完成") {
                param.Add("Value", 1); 
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(bar.Target, param);
        }

        private async void Completed(ToDoDto dto) {
            try {
                UpdateLoading(true);
                var updateResult = await toDoService.UpdateAsync(dto);
                if (updateResult.Status) {
                    var model = Summary.ToDoList.FirstOrDefault(i => i.Id == dto.Id);
                    if (model != null) {
                        model.Status = dto.Status; 
                        Update();
                    }
                    PushMessage("已完成!");
                }
            } catch (Exception) {
                
                throw;
            } finally {

                UpdateLoading(false);
            }
            
          
        }

        public void Execute(string obj) {
            switch (obj) {
                case "新增待办": AddToDo(null); break;
                case "新增备忘录": AddMemo(null); break;
            }
        }
        public async void AddToDo(ToDoDto model) {
                      DialogParameters param = new DialogParameters();
            if (model != null) {
                param.Add("Value", model);
            }
            IDialogResult dialogResult = await dialog.ShowDialog("AddToDoView", param);
         
            if (dialogResult.Result == ButtonResult.OK) {
                try {
                    UpdateLoading(true);
                    var todo = dialogResult.Parameters.GetValue<ToDoDto>("Value");
                    if (todo.Id > 0) {
                        var updateResult = await toDoService.UpdateAsync(todo);
                        if (updateResult.Status) {
                            var exitTodo = Summary.ToDoList.FirstOrDefault(i => i.Id == model.Id);
                            if (exitTodo != null) {
                                exitTodo.Title = model.Title;
                                exitTodo.Status = model.Status;
                                exitTodo.Content = model.Content;
                            }
                        }
                    } else {
                        var addResult = await toDoService.AddAsync(todo);
                        if (addResult.Status) {
                            Summary.ToDoList.Add(addResult.Result);
                            Summary.Sum += 1;
                            Update();
                        }
                    }
                } catch (Exception) {

                    throw;
                } finally {
                    UpdateLoading(false);
                }
               
            }
          
           

        }
        public async void AddMemo(MemoDto model) {
            DialogParameters param = new DialogParameters();
            if (model != null) {
                param.Add("Value", model);
            }
            IDialogResult dialogResult = await dialog.ShowDialog("AddMemoView", param);
            UpdateLoading(true);

            if (dialogResult.Result == ButtonResult.OK) {
                var memo = dialogResult.Parameters.GetValue<MemoDto>("Value");
                if (memo.Id > 0) {
                    var updateResult = await memoService.UpdateAsync(memo);
                    if (updateResult.Status) {
                        var exitmemo = Summary.MemoList.FirstOrDefault(i => i.Id == model.Id);
                        if (exitmemo != null) {
                            exitmemo.Title = model.Title;
                            exitmemo.Content = model.Content;
                        }
                    }
                } else {
                    var addResult = await memoService.AddAsync(memo);
                    if (addResult.Status) {
                        Summary.MemoList.Add(addResult.Result);

                    }
                }
            }
            UpdateLoading(false);

        }

        private readonly IDialogHostService dialog;

        #region
        private readonly IToDoService toDoService;
        private readonly IMemoService memoService;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator aggregator;

        public DelegateCommand<string> ExecuteCommand { get; set; }
        public DelegateCommand<TaskBar> NavigateCommand { get; set; }
        public DelegateCommand<ToDoDto> ToDoCompletedCommand { get; set; }
        public DelegateCommand<ToDoDto> EditToDoCommand { get; set; }
        public DelegateCommand<MemoDto> EditMemoCommand { get; set; }
        public DelegateCommand HelloCommand { get; set; }
        private ObservableCollection<TaskBar> taskBars;

        private string title;

        public string Title {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }
        
        public ObservableCollection<TaskBar> TaskBars {
            get => taskBars;
            set => SetProperty(ref taskBars, value);
        }
        private SummaryDto summary;

        public SummaryDto Summary {
            get => summary;
            set => SetProperty(ref summary, value);
        }
        #endregion

        void CreateTaskBars() {
            TaskBars = new ObservableCollection<TaskBar>();
            TaskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "待办汇总", Color = "#FF0CA0FF", Target = "ToDoView" });
            TaskBars.Add(new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Color = "#66a95b", Target = "ToDoView" });
            TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成比例", Color = "#FF02C6DC", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Color = "#FFFFA000", Target = "MemoView" });
        }

        void Refresh() {
            TaskBars[0].Content = Summary.Sum.ToString();
            TaskBars[1].Content = Summary.Completed.ToString();
            TaskBars[2].Content = Summary.CompletedRatio;
            TaskBars[3].Content = Summary.MemoCount.ToString();
        }
        async void Update() {
            var summaryResult = await toDoService.SummaryAsync();
            if (summaryResult.Status) {
                Summary = summaryResult.Result;
              
                if (summaryResult.Result.Sum == 0) {
                    Summary.CompletedRatio = "暂无";
                }
                Refresh();
            }
        }
        public async override void OnNavigatedTo(NavigationContext navigationContext) {
            var summaryResult = await toDoService.SummaryAsync();
            if (summaryResult.Status) {
                Summary = summaryResult.Result;
                if (summaryResult.Result.Sum == 0) {
                    Summary.CompletedRatio = "暂无";
                }
                Refresh();
            }
            base.OnNavigatedTo(navigationContext);
        }
    }
}
