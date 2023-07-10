using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils
{
    public class APIResponse
    {
        public StatusCode Status { get; set; }
        public dynamic Data { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public APIResponse(Utils.StatusCode status, dynamic data, int code, string message)
        {
            Status = status;
            Data = data;
            Code = code;
            Message = message;
        }
    }

    public class APIResponse<T> : APIResponse
    {
        public new T Data { get; set; }

        public APIResponse(Utils.StatusCode status, T data, int code, string message) : base(status, data, code, message)
        {
            Status = status;
            Data = data;
            Code = code;
            Message = message;
        }
    }

    public enum StatusCode
    {
        Success = 1,
        Error = 0
    }
}
