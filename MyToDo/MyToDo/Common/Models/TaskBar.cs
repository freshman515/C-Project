using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
namespace MyToDo.Common.Models {
    /// <summary>
    /// 任务栏
    /// </summary>
    public class TaskBar :BindableBase {
        private string icon; //图标
        private string title;//标题
        private string content; //内容
        private string color; //颜色
        private string target;//目标

        public string Icon { get => icon; set => SetProperty(ref icon, value); }
        public string Title { get => title; set => SetProperty(ref title, value); }
        public string Content { get => content; set => SetProperty(ref content, value); }
        public string Color { get => color; set => SetProperty(ref color, value); }
        public string Target { get => target; set => SetProperty(ref target, value); }
    }
}
