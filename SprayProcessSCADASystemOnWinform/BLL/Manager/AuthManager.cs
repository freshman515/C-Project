using DAL;
using Helper;
using HZY.Framework.DependencyInjection;
using Mapster;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class AuthManager : IScopedSelfDependency {
        private readonly AuthService _authService;

        public AuthManager(AuthService authService) {
            this._authService = authService;
        }
        public async Task<BaseResult> UpdateAuthAsync(UpdateAuthDto request) {
            var entity = request.Adapt<AuthEntity>();
            var res = await _authService.UpdateAsync(entity);
            if (!res) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = "更新权限失败" };
            }
            return new BaseResult();
        }
        public async Task<BaseResult<QueryAuthResultDto>> GetAuthAsync(QueryAuthDto request) { 
            var res = await _authService.GetByOneAsync(i=>i.Role== request.Role);
            if (res==null) {
                return new BaseResult<QueryAuthResultDto>() { Status = SystemEnums.Result.Fail, Message = "更新权限失败" };
            }
            return new BaseResult<QueryAuthResultDto>() {Data = new List<QueryAuthResultDto>() { res.Adapt<QueryAuthResultDto>() } };

        }
    }
}
