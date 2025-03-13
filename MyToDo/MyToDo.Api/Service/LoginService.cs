using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Extensions;

namespace MyToDo.Api.Service {
    public class LoginService : ILoginService {
        public LoginService(IUnitOfWork work, IMapper mapper) {
            Work = work;
            Mapper = mapper;
        }

        public IUnitOfWork Work { get; }
        public IMapper Mapper { get; }

        public async Task<ApiResponse> Login(string account, string password) {
            try {
                password =  password.GetMD5();
                var model = await Work.GetRepository<User>().GetFirstOrDefaultAsync(predicate: i => i.Account.Equals(account) && i.Password.Equals(password));
                if(model == null) {
                    return new ApiResponse("账号或密码错误");
                }
                return new ApiResponse(true, model);
            } catch (Exception ex) {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> Register(UserDto user) {
            try {
                var model = Mapper.Map<User>(user);
                var repository = Work.GetRepository<User>();
                var userModel = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(model.Account));

                if (userModel != null)
                    return new ApiResponse($"当前账号:{model.Account}已存在,请重新注册！");

                model.CreateDate = DateTime.Now;
                model.Password = model.Password.GetMD5();
                await repository.InsertAsync(model);

                if (await Work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, model);

                return new ApiResponse("注册失败,请稍后重试！");
            } catch (Exception ex) {
                return new ApiResponse("注册账号失败！");
            }
        }
    }
}
