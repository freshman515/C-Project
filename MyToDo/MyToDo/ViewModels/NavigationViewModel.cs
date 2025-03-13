using MyToDo.Extensins;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MyToDo.ViewModels {
    /// <summary>
    /// 该类是作为一个基类存在
    /// 作用1：提供BindableBase基类，负责消息通知
    /// 作用2：导航事件管理，这里的作用是负责提供事件聚合器，通过事件聚合器，得到UpdateLoadingEvent事件
    /// 然后发布出去，IsOpen=true;
    /// </summary>
    public class NavigationViewModel : BindableBase, INavigationAware {
        private readonly IContainerProvider container;
        public readonly IEventAggregator aggregator; //事件聚合器

        /// <summary>
        /// 在这里，container会通过其他地方，传入，比如在ToDoVieModel中，需要创建实例时
        /// 会注入一个IContainerProvider的实例，然后传入到该类的构造函数中，赋值给container
        /// </summary>
        /// <param name="container"></param>
        public NavigationViewModel(IContainerProvider container) {
            this.container = container;
            aggregator = container.Resolve<IEventAggregator>(); //通过容器拿到事件聚合器实例
        }
        /// <summary>
        /// 是否能够导航到此viewModel中
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext) {
            return true;
        }

        /// <summary>
        /// 当导航离开当前 ViewModel 时，这个方法会被调用。可以在此方法中清理资源或保存状态。
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext) {
        }

        /// <summary>
        /// 当导航到当前 ViewModel 时，这个方法会被调用。可以在此方法中执行初始化操作，如加载数据等。
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext) {
        }

        /// <summary>
        /// 接收一个参数，用于发布事件
        /// 当其它地方调用这个方法，传入一个true，就表示它发布了一个事件广播
        /// </summary>
        /// <param name="isOpen">事件模型的一个参数</param>
        public void UpdateLoading(bool isOpen) {
            aggregator.UpdateLoading(new Common.Events.UpdateModel() {
                IsOpen = isOpen
            });
        }
        public void PushMessage(string message) { 
            aggregator.SendMessage(message);
        }
    }
}
