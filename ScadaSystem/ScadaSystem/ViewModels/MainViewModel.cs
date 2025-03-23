using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
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
        private readonly ILogger<MainViewModel> logger;
        private readonly RootParam rootParam;

        public UserSession UserSessionProp { get; }

        public MainViewModel(UserSession userSessionProp,ILogger<MainViewModel> logger,IOptionsSnapshot<RootParam> rootParam) {
            UserSessionProp = userSessionProp;
            this.logger = logger;
            this.rootParam = rootParam.Value;
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
            logger.LogInformation("测试日志");
            logger.LogInformation(rootParam.PlcParam.PlcIp);
            logger.LogInformation(rootParam.PlcParam.PlcPort.ToString());
        }
    }
}
