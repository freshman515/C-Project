using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common.Events {
    /// <summary>
    /// 这个类的作用是承载传递的数据，以便在事件发布和订阅时传递信息。
    /// </summary>
    public class UpdateModel {
        public bool IsOpen  { get; set; }   
    }
    /// <summary>
    ///定义一个事件类型，用于在系统中发布或订阅特定的数据（这里是 UpdateModel）意味着该事件会携带 UpdateModel 类型的数据。。
    /// </summary>
    public class UpdateLoadingEvent :PubSubEvent<UpdateModel>{
         
    }
}
