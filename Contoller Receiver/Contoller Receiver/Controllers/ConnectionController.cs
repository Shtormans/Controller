using Contoller_Receiver.Connectors;
using Contoller_Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Controllers
{
    internal class ConnectionController : IConnectionController
    {
        private readonly IConnector _connector;
        private readonly ILogger _logger;

        public ConnectionController(IConnector connector, ILogger logger)
        {
            _connector = connector;
            _logger = logger;
        }

        public async Task<int> CreateRoom(string password = "")
        {
            ResponseModel<int> response;
            try
            {
                response = await _connector.CreateRoom(password);
            }
            catch (Exception)
            {
                _logger.LogError("Server Error");
                return -1;
            }

            if (!response.Success)
            {
                _logger.LogError(response.Error);
            }

            _logger.LogInfo($"Success connection. Room: {response.Data}");
            return response.Data;
        }

        public async Task<bool> TryConnect(int roomId, string password = "")
        {
            ResponseModel<bool> response;
            try
            {
                response = await _connector.TryConnect(roomId, password);
            }
            catch (Exception)
            {
                _logger.LogError("Server Error");
                return false;
            }

            if (!response.Success)
            {
                _logger.LogError(response.Error);
                return false;
            }

            _logger.LogInfo($"Success connection");
            return response.Success;
        }
    }
}
