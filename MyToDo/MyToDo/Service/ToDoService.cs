using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Service {
    /// <summary>
    /// ToDo服务类，负责调用ToDo Api 接口
    /// 继承自BaseService<ToDoDto> ，因此具备发送api请求的能力，并且针对ToDoDto进行操作
    /// 实现IToDoService，允许通过依赖注入使用该服务，
    /// 不用在此实现接口中的方法，因为所继承的BaseService 以及提供了通用的实现
    /// </summary>
    public class ToDoService : BaseService<ToDoDto>, IToDoService {
        private readonly HttpRestClient client;

        public ToDoService(HttpRestClient client) : base(client, "ToDo") {
            this.client = client;
        }

        public async Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter) {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/ToDo/GetAll?pageIndex={parameter.PageIndex}" +
               $"&pageSize={parameter.PageSize}" +
               $"&search={parameter.Search}" +
               $"&status={parameter.Status}";
            request.Parameter = parameter;
            return await client.ExecuteAsync<PagedList<ToDoDto>>(request);
        }

        public async Task<ApiResponse<SummaryDto>> SummaryAsync() {
            BaseRequest request = new BaseRequest();
           // request.Method = RestSharp.Method.Get;  可以写method，因为默认就是Get
            request.Route = "api/ToDo/Summary";

            return await client.ExecuteAsync<SummaryDto>(request);
        }
    }
}
