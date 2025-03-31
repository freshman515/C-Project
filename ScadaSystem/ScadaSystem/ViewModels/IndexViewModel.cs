using CommunityToolkit.Mvvm.ComponentModel;
using FastReport;
using Microsoft.Extensions.Options;
using ScadaSystem.Helper;
using ScadaSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.ViewModels {
    public partial class IndexViewModel : ObservableObject, IInjectable {
        private readonly GlobalConfig global;
        private CancellationTokenSource cts = new();
        private readonly RootParam root;

        [ObservableProperty]
        ScadaReadDataEntity scadaReadDataProp = new ScadaReadDataEntity();
        public IndexViewModel(GlobalConfig global, IOptionsSnapshot<RootParam> optinos) {
            this.global = global;
            root = optinos.Value;
            StartCollection();
            InitReadData2ScadaEntity();
        }
        public void StartCollection() {
            global.InitPlcServer();
            if (root.PlcParam.AutoCollect) {
                global.StartCollectionAsync();
            }
        }

        private void InitReadData2ScadaEntity() {

            Task.Run(() => {
                //反射  得到ScadaReadDataEntity的所有属性，然后进行过滤，对类型=float和bool的进行过滤
                var properties = typeof(ScadaReadDataEntity).GetProperties()
                .Where(p => p.PropertyType == typeof(float) || p.PropertyType == typeof(bool));

                while (!cts.IsCancellationRequested) {
                    foreach (var property in properties) {
                        try {
                            //如果属性的类型==float ，就取出属性的名称当做key传给Global的ReadDic中获取对应的value，
                            //再给ScadaReadDataProp 当前的属性的值设置为获取到的value;
                            if (property.PropertyType == typeof(float)) {
                                var value = global.GetValue<float>(property.Name);
                                property.SetValue(ScadaReadDataProp, value);
                            } else if (property.PropertyType == typeof(bool)) {
                                var value = global.GetValue<bool>(property.Name);
                                property.SetValue(ScadaReadDataProp, value);
                            }
                        } catch (Exception e) {
                            Debug.WriteLine(e);
                        }
                    }

                }
                Task.Delay(100);
            });
        }
    }
}
