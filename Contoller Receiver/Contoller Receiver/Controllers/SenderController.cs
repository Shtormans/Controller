using Contoller_Receiver.Connectors;
using Contoller_Receiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Controllers
{
    internal class SenderController : ISenderController
    {
        private readonly IConnector _connector;
        private readonly ILogger _logger;

        public SenderController(IConnector connector, ILogger logger)
        {
            _connector = connector;
            _logger = logger;
        }

        public async Task SetAxe(double axe)
        {
            ResponseModel<bool> response;
            try
            {
                response = await _connector.SetAxe(axe);
            }
            catch (Exception)
            {
                _logger.LogError("Server Error");
                return;
            }

            if (!response.Success)
            {
                _logger.LogError(response.Error);
            }
        }

        public async Task SetCommand(Commands command)
        {
            ResponseModel<bool> response;
            try
            {
                response = await _connector.SetCommand(command);
            }
            catch (Exception)
            {
                _logger.LogError("Server Error");
                return;
            }

            if (!response.Success)
            {
                _logger.LogError(response.Error);
            }
        }
    }
}
