using MyToDo.Shared.Contact;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Service {
    /// <summary>
    ///本类是用来构建基础的BaseRequest，提供基础的 API 服务操作，包括执行添加、删除、更新和获取数据的请求。  
    /// 该类依赖于HttpRestClient类来构建真正的RestRequest请求，并发送
    /// serviceName：服务名称，用于拼接请求的路由 ，是在在构建ToDoViewModel时，需要一个IToDoService，然后通过DI 自动生成了ToDoService，然后传入serviceName为“ToDo” 给BaseService，
    ///泛型参数 TEntity 表示数据模型类型，所有操作都基于该类型进行请求和响应处理。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        public BaseService(HttpRestClient client, string serviceName) {
            this.client = client;
            this.serviceName = serviceName;
        }
        /// <summary>
        /// 执行添加操作，构建请求并通过HttpRestClient类来进构建并发送Post请求，
        /// 这里我只需要把BaseRequest构建好，包括我要请求的方法是post还是get之类的
        /// 包括请求的api是Add还是Delete，然后服务名是ToDo还是Memo，这都是一个api的服务
        /// 包括我在请求时携带的参数，也就是请求体，post请求可以携带请求体，Get不行
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ApiResponse<TEntity>> AddAsync(TEntity entity) {
            //构建一个添加请求
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Add";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(request);
        }

        /// <summary>
        /// 构建删除请求，准备路由地址，请求方法，最后再传入HttpRestClient的方法里面，
        ///HttpRestClient里面的ExecuteAsync 这个方法是来真正构建请求的 ，包括空构建请求，设置请求头，请求体，请求参数等
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteAsync(int id) {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Delete;
            request.Route = $"api/{serviceName}/Delete?id={id}";
            return await client.ExecuteAsync(request) ?? new ApiResponse("Failed to get a valid response");
        }

        public async Task<ApiResponse<PagedList<TEntity>>> GetAllAsync(QueryParameter parameter) {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/GetAll?" +
                $"PageIndex={parameter.PageIndex}" +
                $"&PageSize={parameter.PageSize}" +
                $"&Search={parameter.Search}";
            request.Parameter = parameter;
            return await client.ExecuteAsync<PagedList<TEntity>>(request);
        }

        public async Task<ApiResponse<TEntity>> GetByIdAsync(int id) {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/Get?id={Uri.EscapeDataString(id.ToString())}"; 
            return await client.ExecuteAsync<TEntity>(request);
        }

        public async Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity) {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Update";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(request);

        }
    }
}
