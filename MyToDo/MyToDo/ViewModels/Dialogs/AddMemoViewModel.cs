using MaterialDesignThemes.Wpf;
using MyToDo.Common;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using Prism.Mvvm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToDo.Shared.Dtos;

namespace MyToDo.ViewModels.Dialogs {
    class AddMemoViewModel:BindableBase,IDialogHostAware {
        public AddMemoViewModel() {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private MemoDto model; 

        public MemoDto Model {
            get { return model; }
            set { model = value; }
        }

        private void Cancel() {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));


        }

        private void Save() {
            if (string.IsNullOrWhiteSpace(Model.Title) || string.IsNullOrWhiteSpace(Model.Content)) {
                return;
            }
            if (DialogHost.IsDialogOpen(DialogHostName)) {
                DialogParameters param = new DialogParameters();
                param.Add("Value", Model);
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }

        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public void OnDialogOpend(IDialogParameters parameters) {
            if (parameters.ContainsKey("Value")) {
                Model = parameters.GetValue<MemoDto>("Value");
            } else {
                Model = new MemoDto();
            }

        }
    }
}
