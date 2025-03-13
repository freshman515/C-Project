namespace MyToDo.Shared.Contact{

    /// <summary>
    /// 通用的返回对象
    /// </summary>
    public class ApiResponse {
        public ApiResponse() {
                
        }
        public ApiResponse(string message,bool status=false) {
            this.Message = message;
            this.Status = status;
        }
        public ApiResponse(bool status,object result) {
            this.Result = result;
            this.Status = status;
        }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Result { get; set; }
    }

    public class ApiResponse<T> {
        public string Message { get; set; }
        public bool Status { get; set; }
        public T Result { get; set; }
    }
}
