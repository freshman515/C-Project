using MyToDo.Common;
using MyToDo.Common.Events;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Extensins {
    /// <summary>
    /// 当你调用 UpdateLoading 时，发布一个事件（UpdateLoadingEvent），将数据（UpdateModel）传递给所有订阅者。
    /// 当你调用 Register 时，订阅一个事件（UpdateLoadingEvent），并提供一个回调函数。当事件发生时，回调函数会被执行，处理传递的 UpdateModel 数据，判断数据是否发生了变化，并做出相应的响应。
    /// </summary>
    public static class DialogExtensions {
        /// <summary>
        /// 公共询问窗口，
        /// </summary>
        /// <param name="dialogHost">指定DialogHost会话主机</param>
        /// <param name="Title">标题</param>
        /// <param name="Content">内容</param>
        /// <param name="dialogHostName">会话主机名称(唯一)</param>
        /// <returns></returns>
        public static async Task<IDialogResult> Question(this IDialogHostService dialogHost,
            string Title, string Content, string dialogHostName = "Root") {
            DialogParameters param = new DialogParameters();
            param.Add("Title", Title);
            param.Add("Content", Content);
            param.Add("dialogHostName", dialogHostName);

            var dialogResult = await dialogHost.ShowDialog("MsgView", param, dialogHostName);
            return dialogResult;

        }

        public static void RegisterUserName(this IEventAggregator aggregator, Action<string> model) {
            aggregator.GetEvent<UserNameChangedEvent>().Subscribe(model); //注册一个委托到事件中， 

        }
        public static void SendUserName(this IEventAggregator aggregator, string model) {
            aggregator.GetEvent<UserNameChangedEvent>().Publish(model);
        }



        /// <summary>
        /// 推送等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel model) {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
        }

        /// <summary>
        /// 注册等待消息
        /// 在其他类中，可能会有一些方法订阅这个事件。通过调用 Register 方法，将一个回调函数（比如 Action<UpdateModel>）与事件绑定起来。当事件发生时，回调函数会被触发，执行相应的操作。
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void Register(this IEventAggregator aggregator, Action<UpdateModel> model) {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(model); //注册一个委托到事件中， 
        }
        /// <summary>
        /// 注册消息事件
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="action">当事件被触发时，执行的委托。它是一个 Action<MessageModel>，即接收 MessageModel 类型的消息</param>
        /// <param name="filterName">用于过滤消息，默认值为 "Main"。该参数决定了只接收过滤条件匹配的消息</param>
        public static void RegisterMessage(this IEventAggregator aggregator, Action<MessageModel> action, string filterName = "Main ") {
            //GetEvent<MessageEvent>()用与得到MessageEvent事件
            //Subscribe()用与把事件和委托关联起来，事件触发时执行委托
            //ThreadOption.PublisherThread 表示订阅者会在发布消息的线程上执行。
            //true 表示消息的订阅是一次性的，即只要符合条件，订阅者会接收事件的消息。
            //(m) => m.Filter.Equals(filterName) 是一个过滤器，用于检查消息对象中的 Filter 属性是否与 filterName 匹配。只有 Filter 与 filterName 匹配的消息会被传递给订阅者。
            aggregator.GetEvent<MessageEvent>().Subscribe(action, ThreadOption.PublisherThread,
                true, (m) => {
                    return m.Filter.Equals(filterName);
                });
        }
        /// <summary>
        /// 发送提示消息事件
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="message"></param>
        public static void SendMessage(this IEventAggregator aggregator, string message, string filterName = "Main") {
            aggregator.GetEvent<MessageEvent>().Publish(new MessageModel() {
                Filter = filterName,
                Message = message
            });
        }
    }
}
