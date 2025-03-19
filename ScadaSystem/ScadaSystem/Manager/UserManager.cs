using Mapster;
using ScadaSystem.Helper;
using ScadaSystem.Helper.Dtos;
using ScadaSystem.Models;
using ScadaSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaSystem.Manager {
    public class UserManager {
        public UserManager(UserService userService) {
            this.userService = userService;
        }
        private UserService userService;


        public async Task<BaseResult> AddUserAsync(UserAddDto userAddDto) {
            var entity = userAddDto.Adapt<UserEntity>();
            var isExist = await userService.IsExistAsync(i => i.Username == userAddDto.Username);
            if (isExist) {
                return new BaseResult(false, "该用户已经存在");
            }
            var res = await userService.AddAsync(entity);
            if (res <= 0) {
                return new BaseResult(false, "添加用户错误");
            }
            return new BaseResult();
        }
        public async Task<BaseResult> UpdateUserAsync(UserUpdateDto request) {
            var entity = request.Adapt<UserEntity>();
            var isExist = await userService.IsExistAsync(i => i.Username == entity.Username && i.Id != entity.Id);
            if (isExist) {
                return new BaseResult(false, "修改的用户名以存在");
            }
            var res = await userService.UpdateAsync(entity);
            if (!res) {
                return new BaseResult(false, $"更改用户{entity.Username}失败");
            }
            return new BaseResult();
        }
        public async Task<BaseResult> DeleteUserAsync(UserDeleteDto request) {
            var entity = request.Adapt<UserEntity>();
            var res = await userService.DeleteAsync(entity);
            if (!res) {
                return new BaseResult(false, $"删除用户{entity.Username}失败");
            }
            return new BaseResult();
        }
        //查询所有用户
        public async Task<BaseResult<QueryUserResultDto>> GetUserListAsync() {
            var res = await userService.GetListAsync(c => true);
            var dtos = res.Adapt<List<QueryUserResultDto>>();
            return new BaseResult<QueryUserResultDto> { Status = true, Data = dtos };
        }

        public async Task<BaseResult<QueryUserResultDto>> GetByUserRoleAsync(UserQueryRoleDto request) {
            var entity = request.Adapt<UserEntity>();
            var isExist = await userService.IsExistAsync(i => i.Username == entity.Username);
            if (!isExist) {
                return new BaseResult<QueryUserResultDto>() { Status = false,Message="用户不存在"};
            }
            var res = await userService.GetByOneAsync(i => i.Username == entity.Username);
            return new BaseResult<QueryUserResultDto> { Data = new List<QueryUserResultDto> { res.Adapt<QueryUserResultDto>() } };
        }

    }
}
