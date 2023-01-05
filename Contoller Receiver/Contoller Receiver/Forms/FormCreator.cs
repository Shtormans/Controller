using Contoller_Receiver.Controllers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Forms
{
    internal class FormCreator
    {
        private readonly Func<ControllerForm> _controllerFormFactory;
        private readonly Func<ReceiverForm> _receiverFormFactory;

        public FormCreator(Func<ControllerForm> controllerFormFactory, Func<ReceiverForm> receiverFormFactory)
        {
            _controllerFormFactory = controllerFormFactory;
            _receiverFormFactory = receiverFormFactory;
        }

        public ControllerForm CreateController()
        {
            return _controllerFormFactory();
        }

        public ReceiverForm CreateReceive()
        {
            return _receiverFormFactory();
        }
    }
}
