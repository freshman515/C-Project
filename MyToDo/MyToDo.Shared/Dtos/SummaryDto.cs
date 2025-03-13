using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToDo.Shared.Dtos;

namespace MyToDo.Shared.Dtos{
    /// <summary>
    /// 汇总
    /// </summary>
    public class SummaryDto : BaseDto {
        private int sum;
        private int completed;
        private int memoCount;
        private string completedRatio;

        private ObservableCollection<ToDoDto> toDoList;
        private ObservableCollection<MemoDto> memoList;




        /// <summary>
        /// 待办事项列表
        /// </summary>
        public ObservableCollection<ToDoDto> ToDoList {
            get { return toDoList; }
            set { toDoList = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// 备忘录列表
        /// </summary>
        public ObservableCollection<MemoDto> MemoList {
            get { return memoList; }
            set { memoList = value; OnPropertyChanged(); }
        }

        public int Sum { get => sum; set { sum = value;OnPropertyChanged(); } }
        public int Completed { get => completed; set { completed = value; OnPropertyChanged(); } }
        public int MemoCount { get => memoCount; set { memoCount = value; OnPropertyChanged(); } }
        public string CompletedRatio { get => completedRatio; set { completedRatio = value; OnPropertyChanged(); } }
    }
}
