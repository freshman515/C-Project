using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Common.Events {
    public class MessageModel {
        public string Filter { get; set; } //过滤器
        public string Message { get; set; }
    }
    //消息事件模型
    public class MessageEvent :PubSubEvent<MessageModel> {
        
    }
}
