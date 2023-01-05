using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver
{
    internal class ProjectSettings
    {
        public string ApiUrl { get; set; }
        public int? RoomId { get; set; }
        public FormWithLogging CurrentForm { get; set; }
    }
}
