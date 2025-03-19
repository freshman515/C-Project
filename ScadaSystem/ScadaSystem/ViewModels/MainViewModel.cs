using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ScadaSystem.Helper;
using ScadaSystem.Messages;
using ScadaSystem.Models;
using ScadaSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.ViewModels {
    public partial class MainViewModel : ObservableObject, IInjectable {
        public UserSession UserSessionProp { get; }

        public MainViewModel(UserSession userSessionProp) {
            UserSessionProp = userSessionProp;
            InitData();
        }

        public List<MenuEntity> MenuEntities { get; set; } = new();
        
        [RelayCommand]
        void Navigation(MenuEntity menu) {
            //导航页面
            WeakReferenceMessenger.Default.Send(menu);
        }

        [RelayCommand]
        void ChangeUser() {
            WeakReferenceMessenger.Default.Send(new ChangeUserMessage(UserSessionProp.CurrentUser));

        }
        private void InitData() {
            MenuEntities = SqlSugarHelper.Db.Queryable<MenuEntity>().ToList();
        }
    }
}
