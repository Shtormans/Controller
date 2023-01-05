using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationController.Model
{
    internal class BaseResponse<T>
    {
        public BaseResponse()
        {
            Data = default(T);
        }

        public BaseResponse(T value)
        {
            Data = value;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
