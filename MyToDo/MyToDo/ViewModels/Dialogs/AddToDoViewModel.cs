using MaterialDesignThemes.Wpf;
using MyToDo.Common;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;  
namespace MyToDo.ViewModels.Dialogs {
    public class AddToDoViewModel :BindableBase, IDialogHostAware {
        public AddToDoViewModel() {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private ToDoDto model;

        public ToDoDto Model {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }

        private void Cancel() {
            if(DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));


        }

        //确定
        private void Save() {
            if (string.IsNullOrWhiteSpace(Model.Title) || string.IsNullOrWhiteSpace(Model.Content)) {
                return;
            }
            if (DialogHost.IsDialogOpen(DialogHostName)) {
                DialogParameters param = new DialogParameters();
                param.Add("Value",Model);
                DialogHost.Close(DialogHostName,new DialogResult(ButtonResult.OK,param));
            }

        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        //窗口打开时调用的方法
        public void OnDialogOpend(IDialogParameters parameters) {
            if (parameters.ContainsKey("Value")) {
                Model = parameters.GetValue<ToDoDto>("Value");
            }else {
                Model = new ToDoDto();
            }
        }

    }
}
