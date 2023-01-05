using Contoller_Receiver.Controllers;
using Contoller_Receiver.Forms;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoller_Receiver
{
    internal partial class ControllerForm : FormWithLogging
    {
        private readonly ISenderController _controller;
        private readonly IOptions<ProjectSettings> _options;
        private Action _showForm;

        public ControllerForm(ISenderController controller, IOptions<ProjectSettings> options)
        {
            _controller = controller;
            _options = options;
            LogError = LogErrorMethod;
            LogInfo = LogInfoMethod;

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

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (sendButton.Text == nameof(ButtonStatus.Start))
            {
                LogInfo("Started sending");
                sendButton.Text = nameof(ButtonStatus.Stop);

                keyUp.MouseDown += keyUp_MouseDown;
                keyDown.MouseDown += keyDown_MouseDown;
                keyLeft.MouseDown += keyLeft_MouseDown;
                keyRight.MouseDown += keyRight_MouseDown;

                keyUp.MouseUp += keyUp_MouseUp;
                keyDown.MouseUp += keyDown_MouseUp;
                keyLeft.MouseUp += keyLeft_MouseUp;
                keyRight.MouseUp += keyRight_MouseUp;
            }
            else
            {
                LogInfo("Stopped sending");
                sendButton.Text = nameof(ButtonStatus.Start);

                keyUp.MouseDown -= keyUp_MouseDown;
                keyDown.MouseDown -= keyDown_MouseDown;
                keyLeft.MouseDown -= keyLeft_MouseDown;
                keyRight.MouseDown -= keyRight_MouseDown;

                keyUp.MouseUp -= keyUp_MouseUp;
                keyDown.MouseUp -= keyDown_MouseUp;
                keyLeft.MouseUp -= keyLeft_MouseUp;
                keyRight.MouseUp -= keyRight_MouseUp;
            }
        }

        private void keyUp_MouseDown(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetCommand(Commands.Forward));
        }

        private void keyUp_MouseUp(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetCommand(Commands.CancelForward));
        }

        private void keyDown_MouseDown(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetCommand(Commands.Back));
        }

        private void keyDown_MouseUp(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetCommand(Commands.CancelBack));
        }

        private void keyLeft_MouseDown(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetAxe(-1));
        }

        private void keyLeft_MouseUp(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetAxe(0));
        }

        private void keyRight_MouseDown(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetAxe(1));
        }

        private void keyRight_MouseUp(object sender, MouseEventArgs e)
        {
            Task.Run(() => _controller.SetAxe(0));
        }

        private void ControllerForm_Load(object sender, EventArgs e)
        {
            _options.Value.CurrentForm = this;
            addressEntry.Text = _options.Value.RoomId.ToString();
            sendButton.Text = nameof(ButtonStatus.Start);
            LogInfo("Connected");
        }

        private void ControllerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _showForm();
        }
    }
}
