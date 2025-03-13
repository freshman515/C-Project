using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    //传输层数据， 属性名必须和实体层的Model的属性名一致
    public class UserLoginDto {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
