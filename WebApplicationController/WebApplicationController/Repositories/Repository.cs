using WebApplicationController.Model;
using WebPhoneController.Controllers;

namespace WebApplicationController.Repositories
{
    public class Repository : IRepository
    {
        private static List<RoomModel> _rooms = new List<RoomModel>();

        public int CreateRoom(string password)
        {
            var newId = _rooms.Count == 0 ? 0 : _rooms[^1].Id + 1;
            _rooms.Add(new RoomModel { Id = newId, Password = password, Command = Commands.Empty });
            return newId;
        }

        public RoomModel? GetRoom(int id)
        {
            return _rooms.FirstOrDefault(r => r.Id == id);
        }
    }
}
