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
    /// 特定的接口服务，表示我在实现或依赖注入此接口时，我传入的泛型都是ToDoDto
    /// </summary>
    public interface IToDoService : IBaseService<ToDoDto> {
        Task<ApiResponse<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter);
        Task<ApiResponse<SummaryDto>> SummaryAsync();
    }
}
