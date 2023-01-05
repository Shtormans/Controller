using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver
{
    internal class FormWithLogging : Form
    {
        public delegate void LogErrorDelegate(string message);
        public delegate void LogInfoDelegate(string message);

        public LogErrorDelegate LogError;
        public LogInfoDelegate LogInfo;
    }
}
