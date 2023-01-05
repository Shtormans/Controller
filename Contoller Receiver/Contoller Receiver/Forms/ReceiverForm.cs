using Contoller_Receiver.Controllers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoller_Receiver
{
    internal partial class ReceiverForm : FormWithLogging
    {
        private readonly IReceiverController _controller;
        private readonly IOptions<ProjectSettings> _options;
        private readonly KeysEmulation _keysEmulation;
        private Commands? _lastCommand;
        private double? _lastAxe;
        private Action _showForm;

        public ReceiverForm(IReceiverController controller, IOptions<ProjectSettings> options, KeysEmulation keysEmulation)
        {
            _controller = controller;
            _options = options;
            _keysEmulation = keysEmulation;
            LogError = LogErrorMethod;
            LogInfo = LogInfoMethod;
            _lastCommand = null;
            _lastAxe = null;

            InitializeComponent();
            this.Show();
        }

        public void ShowPreviousFormAction(Action showForm)
        {
            _showForm = showForm;
        }

        public void LogErrorMethod(string message)
        {
            statusEntry.ForeColor = Color.Red;
            statusEntry.Text = message;
        }

        public void LogInfoMethod(string message)
        {
            statusEntry.ForeColor = SystemColors.WindowText;
            statusEntry.Text = message;
        }

        private void receiveButton_Click(object sender, EventArgs e)
        {
            if (receiveButton.Text == nameof(ButtonStatus.Start))
            {
                LogInfo("Started receving");
                receiveButton.Text = nameof(ButtonStatus.Stop);
                receiveTimer.Start();
            }
            else
            {
                LogInfo("Stoped receving");
                receiveButton.Text = nameof(ButtonStatus.Start);
                receiveTimer.Stop();
            }
        }

        private void receiveTimer_Tick(object sender, EventArgs e)
        {
            Task.Run(() => GetAxe());
            Task.Run(() => GetCommand());
        }

        private async Task GetAxe()
        {
            double axe = await _controller.GetAxe();
            if (axe == _lastAxe)
                return;

            _lastAxe = axe;
            Invoke(() => this.axeEntry.Text = _lastAxe.ToString());

            _keysEmulation.Rotate(axe);
        }

        private async Task GetCommand()
        {
            Commands command = await _controller.GetCommand();
            if (command == _lastCommand)
                return;
            
            _lastCommand = command;
            Invoke(() => this.commandEntry.Text = _lastCommand.ToString());

            switch (command)
            {
                case Commands.Forward:
                    _keysEmulation.KeyDown_W();
                    break;
                case Commands.CancelForward:
                    _keysEmulation.KeyUp_W();
                    break;
                case Commands.Back:
                    _keysEmulation.KeyDown_S();
                    break;
                case Commands.CancelBack:
                    _keysEmulation.KeyUp_S();
                    break;
                default:
                    break;
            }
        }

        private void ReceiverForm_Load(object sender, EventArgs e)
        {
            _options.Value.CurrentForm = this;
            addressEntry.Text = _options.Value.RoomId.ToString();
            receiveButton.Text = nameof(ButtonStatus.Start);
            LogInfo("Connected");
        }

        private void ReceiverForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _showForm();
        }
    }
}
