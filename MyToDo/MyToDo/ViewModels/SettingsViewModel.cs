using System;
using MyToDo.Extensins;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Commands;
using MyToDo.Common.Models;
using System.Collections.ObjectModel;
namespace MyToDo.ViewModels {
    public class SettingsViewModel:BindableBase{

        //区域管理器
        private IRegionManager regionManager;

        //对话框服务
        private IRegionNavigationJournal journal;

        private ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }
        //启用导航命令    
        public DelegateCommand<MenuBar> NavigateCommand { get; set; }


        public SettingsViewModel(IRegionManager regionManager) {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();

        }

        private void Navigate(MenuBar obj) {
            if(obj == null || string.IsNullOrWhiteSpace(obj.NameSpace)) {
                return;
            }
            regionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(obj.NameSpace);
        }
        void CreateMenuBar() {

            MenuBars.Add(new MenuBar() { Icon = "Palette", Title = "个性化", NameSpace = "SkinView" });
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "系统设置", NameSpace = "" });
            MenuBars.Add(new MenuBar() { Icon = "Information", Title = "关于更多", NameSpace = "AboutView" });

        }
    }
}
