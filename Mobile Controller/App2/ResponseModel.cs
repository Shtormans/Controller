using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    internal class ResponseModel<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
