using Contoller_Receiver.Connectors;
using Contoller_Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Controllers
{
    internal class ReceiverController : IReceiverController
    {
        private readonly IConnector _connector;
        private readonly ILogger _logger;

        public ReceiverController(IConnector connector, ILogger logger)
        {
            _connector = connector;
            _logger = logger;
        }

        public async Task<double> GetAxe()
        {
            ResponseModel<double> response;
            try
            {
                response = await _connector.GetAxe();
            }
            catch (Exception)
            {
                _logger.LogError("Server Error");
                return 0;
            }

            if (!response.Success)
            {
                _logger.LogError(response.Error);
            }
            return response.Data;
        }

        public async Task<Commands> GetCommand()
        {
            ResponseModel<Commands> response;
            try
            {
                response = await _connector.GetCommand();
            }
            catch (Exception)
            {
                _logger.LogError("Server Error");
                return Commands.Empty;
            }

            if (!response.Success)
            {
                _logger.LogError(response.Error);
            }

            return response.Data;
        }
    }
}
