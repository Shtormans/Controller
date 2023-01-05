using WebApplicationController.Model;
using WebPhoneController.Controllers;

namespace WebApplicationController.Repositories
{
    public interface IRepository
    {
        public RoomModel? GetRoom(int id);
        public int CreateRoom(string password);
    }
}
