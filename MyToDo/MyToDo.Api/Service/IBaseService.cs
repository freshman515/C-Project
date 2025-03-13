using MyToDo.Shared.Contact;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Service {
    /// <summary>
    /// 通用的服务接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService <T>{
        Task<ApiResponse> GetAllAsync(QueryParameter query);
        Task<ApiResponse> GetSingleAsync(int id);
        Task<ApiResponse> AddAsync(T entity);
        Task<ApiResponse> UpdateAsync(T entity);
        Task<ApiResponse> DeleteAsync(int id);
    }
}
