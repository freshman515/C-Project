using DAL;
using Helper;
using HZY.Framework.DependencyInjection;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helper.SystemEnums;

namespace DAL {
    public class UserService :BaseService<UserEntity>, IScopedSelfDependency {
        public async Task<BaseResult<UserEntity>> LoginAsync(UserEntity entity) {
            BaseResult<UserEntity> result = new BaseResult<UserEntity>();
            var res = await DB.SqlSugarClient.Queryable<UserEntity>().Where(e => e.UserName == entity.UserName && e.UserPassword == entity.UserPassword)
                .FirstAsync();
            if (res == null) {
                result.Status = Result.Fail;
                result.Message = "用户名或者密码错误";
                return result;
            } else {
                result.Data = new List<UserEntity>{ res };
                return result;
            }
        }

    }
}
