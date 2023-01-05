using Contoller_Receiver.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Connectors
{
    internal class WebConnector : IConnector
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly IOptions<ProjectSettings> _options;

        public WebConnector(HttpClient client, IOptions<ProjectSettings> options)
        {
            _client = client;
            _options = options;
            _baseUrl = options.Value.ApiUrl;
        }

        public async Task<ResponseModel<int>> CreateRoom(string password = "")
        {
            var content = APIResponseConverter.SerializeResponse(password);
            var response = await _client.PostAsync($"{_baseUrl}/CreateRoom", content);
            var roomId = await APIResponseConverter.DeserializeResponse<ResponseModel<int>>(response);
            return roomId;
        }

        public async Task<ResponseModel<bool>> TryConnect(int roomId, string password = "")
        {
            var content = APIResponseConverter.SerializeResponse(password);
            var response = await _client.PostAsync($"{_baseUrl}/TryConnect/{roomId}", content);
            var result = await APIResponseConverter.DeserializeResponse<ResponseModel<bool>>(response);
            return result;
        }

        public async Task<ResponseModel<double>> GetAxe()
        {
            var response = await _client.GetAsync($"{_baseUrl}/GetAxe/{_options.Value.RoomId}");
            var axe = await APIResponseConverter.DeserializeResponse<ResponseModel<double>>(response);
            return axe;
        }

        public async Task<ResponseModel<Commands>> GetCommand()
        {
            var response = await _client.GetAsync($"{_baseUrl}/GetCommand/{_options.Value.RoomId}");
            var command = await APIResponseConverter.DeserializeResponse<ResponseModel<Commands>>(response);
            return command;
        }

        public async Task<ResponseModel<bool>> SetAxe(double axe)
        {
            var content = APIResponseConverter.SerializeResponse(axe);
            var response = await _client.PostAsync($"{_baseUrl}/SetAxe/{_options.Value.RoomId}", content);
            var result = await APIResponseConverter.DeserializeResponse<ResponseModel<bool>>(response);
            return result;
        }

        public async Task<ResponseModel<bool>> SetCommand(Commands command)
        {
            var content = APIResponseConverter.SerializeResponse(command);
            var response = await _client.PostAsync($"{_baseUrl}/SetCommand/{_options.Value.RoomId}", content);
            var result = await APIResponseConverter.DeserializeResponse<ResponseModel<bool>>(response);
            return result;
        }
    }
}
