using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.ViewModels {
    public partial class ParamsViewModel : ObservableObject {
        [ObservableProperty]
        private  RootParam rootParam;

        public ParamsViewModel(IOptionsSnapshot<RootParam> optionsSnapshot) {
            RootParam = optionsSnapshot.Value;
        }


    }
}
