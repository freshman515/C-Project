using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;

namespace MyToDo.Api.Service {
    /// <summary>
    /// 登录服务接口
    /// </summary>
    public interface ILoginService {
        Task<ApiResponse> Login(string account, string password);
        Task<ApiResponse> Register(UserDto user);
    }

}
