using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Models
{
    internal class ResponseModel<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
