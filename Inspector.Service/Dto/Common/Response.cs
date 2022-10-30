using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto.Common
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
           
            Message = string.Empty;
            Data = data;
        }
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
