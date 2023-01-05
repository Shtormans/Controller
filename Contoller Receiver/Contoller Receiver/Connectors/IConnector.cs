using Contoller_Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Connectors
{
    internal interface IConnector
    {
        public Task<ResponseModel<bool>> TryConnect(int roomId, string password = "");
        public Task<ResponseModel<int>> CreateRoom(string password = "");
        public Task<ResponseModel<double>> GetAxe();
        public Task<ResponseModel<Commands>> GetCommand();
        public Task<ResponseModel<bool>> SetAxe(double axe);
        public Task<ResponseModel<bool>> SetCommand(Commands command);
    }
}
