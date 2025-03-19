using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Helper {
    public class BaseResult {
        public BaseResult(bool status,string message) {
            Status = status;
            Message = message;
        }
        public BaseResult() {
                    
        }
        public BaseResult(string message) {
            this.Message = message;
                
        }

        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
    public class BaseResult<T> : BaseResult {
        public BaseResult(bool status, string message,List<T> datas) : base(status, message) {
            Data = datas;
        }
        public BaseResult() {
                
        }

        public List<T> Data { get; set; }
    }

}
