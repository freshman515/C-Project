using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Service;
using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;

namespace MyToDo.Api.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller {
        public LoginController(ILoginService service) {
            Service = service;
        }

        public ILoginService Service { get; }

        [HttpPost]
        public async Task<ApiResponse> Login([FromBody] UserDto user) => await Service.Login(user.Account,user.Password);


        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] UserDto user) => await Service.Register(user);
    }
}
