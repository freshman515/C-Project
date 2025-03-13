using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;
using MyToDo.Api.Service;
using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Controllers {
    /// <summary>
    /// 待办事项控制器
    /// </summary>


    //ToDoController 是 ASP.NET Core Web API 控制器，负责处理 HTTP 请求。它通过依赖注入调用 IToDoService 来执行与 ToDo 相关的业务逻辑。

    //ToDoController.cs 的作用：
    //处理前端或客户端发来的 HTTP 请求。
    //调用 IToDoService 中的方法来获取或更新数据。
    //将结果返回给客户端。
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : Controller {
        public ToDoController(IToDoService service) {
            Service = service;
        }

        public IToDoService Service { get; }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await Service.GetSingleAsync(id);
        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] ToDoParameter parameter) => await Service.GetAllAsync(parameter);

        //FromBody:在Action方法传入参数后添加[frombody]属性，参数将以一个整体的josn对象的形式传递。
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] ToDoDto model) => await Service.AddAsync(model);

        [HttpPost]
        public async Task<ApiResponse> UpDate([FromBody] ToDoDto model) => await Service.UpdateAsync(model);
        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await Service.DeleteAsync(id);

        [HttpGet]
        public async Task<ApiResponse> Summary() => await Service.Summary();

    }
}
