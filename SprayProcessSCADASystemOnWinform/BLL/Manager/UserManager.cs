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
    public class UserManager : IScopedSelfDependency {
        public readonly UserService _userService;
        public UserManager(UserService userManager) {
            _userService = userManager;
        }
        public async Task<BaseResult<UserEntity>> LoginAsync(UserLoginDto request) {
            var entity = request.Adapt<UserEntity>();  //映射到实体层  就是把request内的属性的值映射到UserEntity里面的值上
            var res = await _userService.LoginAsync(entity);
            if (res.Status == SystemEnums.Result.Fail) {
                return new BaseResult<UserEntity>() { Status = SystemEnums.Result.Fail, Message = res.Message };
            }
            return res;
        }

        public async Task<BaseResult> IsUserNameExistAsync(UserExistDto request) {
            var entity = request.Adapt<UserEntity>();//映射UserName
            var res = await _userService.IsExistAsync(i => i.UserName == entity.UserName);
            if (!res) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = "此用户不存在" };
            }
            return new BaseResult<UserEntity>();
        }

        public async Task<BaseResult> AddUserAsync(UserAddDto request) {
            var entity = request.Adapt<UserEntity>();
            var res = await _userService.InsertAsync(entity);
            if (res <= 0) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = $"新增用户{entity.UserName}失败" };
            }
            return new BaseResult();
        }

        public async Task<BaseResult> UpdateUserAsync(UserUpdateDto request) {
            var entity = request.Adapt<UserEntity>();
            var res = await _userService.UpdateAsync(entity);
            if (!res) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = $"更改用户{entity.UserName}失败" };
            }
            return new BaseResult();
        }

        public async Task<BaseResult> DeleteUserAsync(UserDeleteDto request) {
            var entity = request.Adapt<UserEntity>();
            var res = await _userService.DeleteAsync(entity);
            if (!res) {
                return new BaseResult() { Status = SystemEnums.Result.Fail, Message = $"删除用户{entity.UserName}失败" };
            }
            return new BaseResult();
        }

        //查询所有用户
        public async Task<BaseResult<QueryUserResultDto>> GetUserListAsync() {
            var res = await _userService.GetListAsync(c => true);
            var dtos = res.Adapt<List<QueryUserResultDto>>();
            return new BaseResult<QueryUserResultDto> { Status = SystemEnums.Result.Success, Data = dtos };
        }

        public async Task<BaseResult<QueryUserResultDto>> GetByUserAuthAsync(UserQueryAuthDto request) {
            var entity = request.Adapt<UserEntity>();
            var isExist = await _userService.IsExistAsync(i => i.UserName == entity.UserName);
            if (!isExist) {
                return new BaseResult<QueryUserResultDto> { Status = SystemEnums.Result.Fail, Message = "用户不存在" };
            }
            var res = await _userService.GetByOneAsync(i => i.UserName == entity.UserName);
            return new BaseResult<QueryUserResultDto> { Data = new List<QueryUserResultDto> { res.Adapt<QueryUserResultDto>() } };
        }


    }
}
