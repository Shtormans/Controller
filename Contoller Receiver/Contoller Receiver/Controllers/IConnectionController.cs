using Contoller_Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Controllers
{
    internal interface IConnectionController
    {
        public Task<bool> TryConnect(int roomId, string password = "");
        public Task<int> CreateRoom(string password = "");
    }
}
