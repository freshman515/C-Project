using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.ViewModels {
    public partial class ParamsViewModel : ObservableObject {
        private readonly GlobalConfig _global;
        [ObservableProperty]
        private RootParam _rootParam;

        CancellationTokenSource _cts;

        public ParamsViewModel(IOptionsSnapshot<RootParam> optionsSnapshot, GlobalConfig global) {
            RootParam = optionsSnapshot.Value;
            this._global = global;
        }

        [RelayCommand]
        void ToggleCollection() {
            if (RootParam.PlcParam.AutoCollect) {
                _global.StartCollectionAsync();
            }
            else{
                _global.StopCollection();
            }
        }

        [RelayCommand]
        void ToggleMock() {
            if (RootParam.PlcParam.AutoMock) {
                StartMock();
            } else {
                StopMock();

            }
        }

        private void StartMock() {
            _cts = new CancellationTokenSource();
            Task.Run(async () => {
                var scadaReadData = new ScadaReadDataEntity();
                var floatProperties = typeof(ScadaReadDataEntity).GetProperties()
                          .Where(i => i.PropertyType == typeof(float));
                var boolProperties = typeof(ScadaReadDataEntity).GetProperties()
                                    .Where(i => i.PropertyType == typeof(bool));

                var random = new Random();

                while (!_cts.Token.IsCancellationRequested) {
                    foreach (var property in floatProperties) {
                        var value = (float)random.NextDouble() * 4 + 1;  // 生成 1~5 的随机 float 值
                        var address = _global.ReadEntites.FirstOrDefault(x => x.En == property.Name)?.Address;

                        if (!string.IsNullOrEmpty(address)) {
                            await _global.Plc.WriteAsync(address, value);
                        }
                    }
                    foreach (var property in boolProperties) {
                        var value = random.Next(0, 2) == 0;  // 随机生成 true 或 false
                        var address = _global.ReadEntites.FirstOrDefault(x => x.En == property.Name)?.Address;

                        if (!string.IsNullOrEmpty(address)) {
                            await _global.Plc.WriteAsync(address, value);
                        }
                    }

                    await Task.Delay(1000);
                }

            });

        }

        private void StopMock() {
            if (_cts != null) {
                _cts.Cancel();
            }

        }
    }
}
