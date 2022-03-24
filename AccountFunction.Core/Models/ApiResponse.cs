using AccountFunction.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Models
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public string? Code { get; set; }

        public static ApiResponse<T> GetApiResult(T? model, string status = "", string message ="")
        {
            ApiResponse<T> response = new()
            {
                Data = model,
                Code = status,
                Message = message
            };
            return response;
        }
    }
}
