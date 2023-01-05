using WebPhoneController.Controllers;

namespace WebApplicationController.Model
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public double Axe { get; set; }
        public Commands Command { get; set; }
    }
}
