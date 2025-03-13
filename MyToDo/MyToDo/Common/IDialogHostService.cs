using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common {
    public interface IDialogHostService :IDialogService{
            /// <summary>
            /// 异步显示对话框。
            /// </summary>
            /// <param name="name">对话框的名称。该名称通常用于标识对话框，可以根据需要动态传入不同的对话框。</param>
            /// <param name="parameters">对话框的参数。这些参数可以用于传递给对话框的数据。</param>
            /// <param name="dialogHostName">指定要显示对话框的对话框主机的名称。默认为 "Root"，表示根级对话框主机。</param>
            /// <returns>返回一个任务，表示对话框的显示结果。`IDialogResult` 包含对话框的返回数据和状态。</returns>
            Task<IDialogResult> ShowDialog(string name,IDialogParameters parameters,string dialogHostName="Root");

    }
}
