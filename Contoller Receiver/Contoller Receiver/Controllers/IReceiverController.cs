using Contoller_Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Controllers
{
    internal interface IReceiverController
    {
        public Task<double> GetAxe();
        public Task<Commands> GetCommand();
    }
}
