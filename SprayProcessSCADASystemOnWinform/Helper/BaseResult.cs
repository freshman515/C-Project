using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helper.SystemEnums;

namespace Helper {
    public class BaseResult {
        //返回状态
        public Result Status { get; set; } = Result.Success;
        //错误信息
        public string Message { get; set; } = string.Empty;
    }
    public class BaseResult<T> :BaseResult{

        public List<T> Data { get; set; }
    }
}
