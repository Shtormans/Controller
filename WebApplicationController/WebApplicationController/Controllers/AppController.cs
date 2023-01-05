using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using WebApplicationController;
using WebApplicationController.Model;
using WebApplicationController.Repositories;

namespace WebPhoneController.Controllers
{
    public enum Commands
    {
        Forward,
        CancelForward,
        Back,
        CancelBack,
        Empty
    }

    [ApiController]
    [Route("AppController")]
    public class AppController : BaseController
    {
        private readonly IRepository _repository;

        public AppController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            return Ok("test");
        }

        [HttpPost]
        [Route("CreateRoom")]
        public IActionResult CreateRoom([FromBody] string password)
        {
            var newId = _repository.CreateRoom(password);
            return CreateOKResponse(newId);
        }

        [HttpPost]
        [Route("TryConnect/{id:int}")]
        public IActionResult TryConnect([FromRoute] int id, [FromBody] string password)
        {
            var room = _repository.GetRoom(id);
            if (room == null)
            {
                return CreateErrorResponse<bool>("Incorrect address");
            }
            if (room.Password != password)
            {
                return CreateErrorResponse<bool>("Incorrect password");
            }

            return CreateOKResponse(true);
        }

        [HttpGet]
        [Route("GetAxe/{id:int}")]
        public IActionResult GetAxe(int id)
        {
            var room = _repository.GetRoom(id);
            if (room == null)
            {
                return CreateErrorResponse<bool>("Incorrect address");
            }

            return CreateOKResponse(room.Axe);
        }

        [HttpGet]
        [Route("GetCommand/{id:int}")]
        public IActionResult GetCommand(int id)
        {
            var room = _repository.GetRoom(id);
            if (room == null)
            {
                return CreateErrorResponse<bool>("Incorrect address");
            }

            return CreateOKResponse(room.Command);
        }

        [HttpPost]
        [Route("SetAxe/{id:int}")]
        public IActionResult SetAxe([FromRoute] int id, [FromBody] double axe)
        {
            var room = _repository.GetRoom(id);
            if (room == null)
            {
                return CreateErrorResponse<bool>("Incorrect address");
            }

            room.Axe = axe;
            return CreateOKResponse(true);
        }

        [HttpPost]
        [Route("SetCommand/{id:int}")]
        public IActionResult SetCommand([FromRoute] int id, [FromBody] Commands command)
        {
            var room = _repository.GetRoom(id);
            if (room == null)
            {
                return CreateErrorResponse<bool>("Incorrect address");
            }

            room.Command = command;
            return CreateOKResponse(true);
        }
    }
}