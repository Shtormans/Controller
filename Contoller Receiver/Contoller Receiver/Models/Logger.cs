using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoller_Receiver.Models
{
    internal class Logger : ILogger
    {
        private readonly IOptions<ProjectSettings> _options;
        public Logger(IOptions<ProjectSettings> options)
        {
            _options = options;
        }

        public void LogError(string message)
        {
            _options.Value.CurrentForm.Invoke(() => _options.Value.CurrentForm.LogError(message));
        }

        public void LogInfo(string message)
        {
            _options.Value.CurrentForm.Invoke(() => _options.Value.CurrentForm.LogInfo(message));
        }
    }
}
