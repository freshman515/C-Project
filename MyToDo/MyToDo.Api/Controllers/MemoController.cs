using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Service;
using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Controllers {
    /// <summary>
    /// 备忘录控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemoController : Controller {

        
        public MemoController(IMemoService memoService) {
            MemoService = memoService;
        }

        public IMemoService MemoService { get; }

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter parameter) => await MemoService.GetAllAsync(parameter);

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await MemoService.GetSingleAsync(id);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] MemoDto memoDto) => await MemoService.AddAsync(memoDto);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] MemoDto memoDto) => await MemoService.UpdateAsync(memoDto);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await MemoService.DeleteAsync(id);

    }
}
