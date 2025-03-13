using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared.Dtos {
    /// <summary>
    /// 备忘录数据传输对象
    /// </summary>
    public class MemoDto :BaseDto {
        private string title;
        private string content;

        
        public string Title { get => title; set { title = value; OnPropertyChanged(); } }
        public string Content { get => content; set { content = value; OnPropertyChanged(); } }
    }
}
