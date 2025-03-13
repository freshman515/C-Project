using MyToDo.Shared.Contact;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Service {
    /// <summary>
    /// 主要就是对RestClient的封装，用于对api进行交互，通过传入BaseRequest对象，执行请求，返回ApiResponse对象    
    /// </summary>
    public class HttpRestClient {
        private readonly string apiUrl;
        /// <summary>
        ///  RestClient:  http客户端
        ///  用于对api进行交互，简化了http请求和响应的处理，支持多种请求方式，如GET、POST、PUT、DELETE等
        /// 提供对json 和 xml 的序列化和反序列化
        /// </summary>
        protected readonly RestClient Client;

        //api: 基础URL ，如：http://localhost:5000   该参数会通过依赖注入传入，和后面的请求路径拼接成完整的请求URL
        public HttpRestClient(string apiUrl) { //在App.xaml.cs 中注入构造函数默认参数
            this.apiUrl = apiUrl;

            Client = new RestClient(apiUrl); // 创建 RestClient 实例
        }

        /// <summary>
        /// 执行请求 返回 ApiResponse 
        /// </summary>
        /// <param name="baseRequest">包含请求信息的baseRequest对象，包含请求方法，请求头，请求体，参数等</param>
        /// <returns>返回一个api响应ApiResponse对象，如果成功，返回的对象包括响应内容。如果失败，返回一个表示失败的ApiRespnose对象</returns>
        public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest) {

            //RestRequest: 用于构建请求，设置请求头，请求体，请求参数等
            var request = new RestRequest(baseRequest.Route, baseRequest.Method);

            //设置请求头
            request.AddHeader("Content-Type", baseRequest.ContentType);


            if (baseRequest.Parameter != null) {
                // 使用 JsonConvert 将请求参数序列化为 JSON 字符串
                // "param" 是请求体中的字段名称，ParameterType.RequestBody 表示这是请求的正文
                request.AddJsonBody(baseRequest.Parameter);
            }
            var requestUrl = new Uri(new Uri(apiUrl.TrimEnd('/')), baseRequest.Route.TrimStart('/'));  // 拼接完整的 URL

            // 执行请求并获取响应  ：这里是真正的请求发送，返回一个IRestResponse对象
            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            } else {
                return new ApiResponse() {
                    Status = false,
                    Result = null,
                    Message = response.ErrorMessage
                };
            }

        }


        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest) {
         
            // 创建请求，并设置请求方法和路径
            var request = new RestRequest(baseRequest.Route, baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);

            // 如果有请求参数，序列化并添加到请求体中
            if (baseRequest.Parameter != null) {
                request.AddJsonBody(baseRequest.Parameter);
            }

            // 拼接完整的请求 URL
            var requestUrl = new Uri(new Uri(apiUrl.TrimEnd('/')), baseRequest.Route.TrimStart('/'));  // 拼接完整的 URL

            // 执行请求并获取响应
            var response = await Client.ExecuteAsync(request);

            // 如果响应内容为空，返回一个默认的 ApiResponse<T> 错误结果
            if (response.Content == null) {
                return new ApiResponse<T> { Status = false, Message = "No content" };
            }

            try {
                // 尝试反序列化响应内容到 ApiResponse<T>
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
                return apiResponse ?? new ApiResponse<T> { Status = false, Message = "Deserialization failed" };
            } catch (Exception ex) {
                // 如果反序列化失败，返回一个带有错误消息的 ApiResponse<T>
                return new ApiResponse<T> { Status = false, Message = $"Deserialization exception: {ex.Message}" };
            }
        }



    }
}
