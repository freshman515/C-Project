using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Models {
    [SugarTable("user")]
    public class UserEntity :BaseEntity{
	private string username;
	public string Username {
	    get => username;
	    set { SetProperty(ref username, value); }
	}
        private string password;
        public string Password {
            get => password;
            set { SetProperty(ref password, value); }
        }

        /// <summary>
        /// 0代表管理员 1代表普通用户
        /// </summary>
        private int role;
        public int Role {
            get => role;
            set { SetProperty(ref role, value); }
        }
    }
}
