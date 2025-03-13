using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToDo.Common.Models;
using MyToDo.Extensins;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using MyToDo.Common;
using Prism.Ioc;
using Prism.Events;
namespace MyToDo.ViewModels {
    public class MainViewModel : BindableBase, IConfigureService {

        private string userName;

        public string UserName {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }


        //ObservableCollection实现了 INotifyCollectionChanged 接口，使得该集合在数据发生变化时能够自动通知 UI 更新。
        private ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        private readonly IRegionManager region;
        private readonly IContainerProvider container;
        private readonly IEventAggregator aggregator;
        private IRegionNavigationJournal journal;

        //导航命令
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }

        public DelegateCommand LoginOutCommand { get; private set; }
        public MainViewModel(IRegionManager regionManager, IContainerProvider container, IEventAggregator aggregator) {
            MenuBars = new ObservableCollection<MenuBar>();
            region = regionManager;
            this.container = container;
            this.aggregator = aggregator;
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            GoBackCommand = new DelegateCommand(() => {
                if (journal != null && journal.CanGoBack) {
                    journal.GoBack();
                }
            });
            GoForwardCommand = new DelegateCommand(() => {
                if (journal != null && journal.CanGoForward) {
                    journal.GoForward();
                }
            });
            LoginOutCommand = new DelegateCommand(() => {
                App.LoginOut(container);
            });
            aggregator.RegisterUserName(arg => {
                UserName = arg;
            });
        }


        private void Navigate(MenuBar bar) {//页面导航
            if (bar == null || string.IsNullOrWhiteSpace(bar.NameSpace)) {
                return;
            }
            region.Regions[PrismManager.MainViewRegionName].RequestNavigate(bar.NameSpace, callback => {
                journal = callback.Context.NavigationService.Journal;
            });
        }
        MenuBar homePage = new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "IndexView" };
        void CreateMenuBar() {

            MenuBars.Add(homePage);
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });

        }

        public void Configure() {
            CreateMenuBar();
            Navigate(homePage);
            region.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
        }
    }
}
