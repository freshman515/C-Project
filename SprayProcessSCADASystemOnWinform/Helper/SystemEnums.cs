﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper {
    public class SystemEnums {
        public enum FontsType {
            微软雅黑,
            新宋体,
            仿宋,
            宋体,
            楷体,
            黑体
        }
        public enum  UserRole {
            管理员,
            工程师,
            操作员,
            访客
        }
        public enum Result {
            Fail =0, Success =1,
        }

    }
}
