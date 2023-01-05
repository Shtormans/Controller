using Contoller_Receiver.Controllers;
using Contoller_Receiver.Forms;
using Contoller_Receiver.Models;
using Microsoft.Extensions.Options;

namespace Contoller_Receiver
{
    internal enum ConnectButtonStatus
    {
        Create,
        Connect
    }

    internal enum ConnectionStatus
    {
        Receiver,
        Controller
    }

    internal enum Commands
    {
        Forward,
        CancelForward,
        Back,
        CancelBack,
        Empty
    }

    internal enum ButtonStatus
    {
        Start,
        Stop
    }

    internal partial class Form1 : FormWithLogging
    {
        private readonly IConnectionController _controller;
        private readonly IOptions<ProjectSettings> _options;
        private readonly FormCreator _formCreator;

        public Form1(IConnectionController controller, IOptions<ProjectSettings> options, FormCreator formCreator)
        {
            _controller = controller;
            _options = options;
            _formCreator = formCreator;
            LogError = LogErrorMethod;
            LogInfo = LogInfoMethod;

            InitializeComponent();
            connectButton.Text = nameof(ConnectButtonStatus.Create);
            connectionType.Text = nameof(ConnectionStatus.Receiver);
            connectionType.Items.Add(ConnectionStatus.Receiver);
            connectionType.Items.Add(ConnectionStatus.Controller);
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

        private void passwordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordEntry.Text = String.Empty;
            passwordEntry.Enabled = !passwordEntry.Enabled;
        }

        private void addressEntry_TextChanged(object sender, EventArgs e)
        {
            if (addressEntry.Text.Length == 0)
            {
                connectButton.Text = nameof(ConnectButtonStatus.Create);
            }
            else if (connectButton.Text == nameof(ConnectButtonStatus.Create))
            {
                connectButton.Text = nameof(ConnectButtonStatus.Connect);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text == nameof(ConnectButtonStatus.Create))
            {
                Task.Run(() => CreateRoom());
            }
            else
            {
                Task.Run(() => TryConnect());
            }
        }

        private async Task CreateRoom()
        {
            int roomId = await _controller.CreateRoom(passwordEntry.Text);
            if (roomId == -1)
            {
                return;
            }

            _options.Value.RoomId = roomId;
            Invoke(() => CreateNewForm());
        }

        private async Task TryConnect()
        {
            int roomId;

            bool isCorrectAddress = int.TryParse(addressEntry.Text, out roomId);
            if (!isCorrectAddress)
            {
                return;
            }

            bool success = await _controller.TryConnect(roomId, passwordEntry.Text);
            if (success)
            {
                _options.Value.RoomId = roomId;
                Invoke(() => CreateNewForm());
            }
        }

        public void FocusForm()
        {
            this.Show();
            _options.Value.CurrentForm = this;
        }

        private void CreateNewForm()
        {
            this.Hide();
            statusEntry.Text = String.Empty;
            passwordEntry.Text = String.Empty;
            addressEntry.Text = String.Empty;

            if (connectionType.Text == nameof(ConnectionStatus.Receiver))
            {
                _formCreator.CreateReceive().ShowPreviousFormAction(() => FocusForm());
            }
            else
            {
                _formCreator.CreateController().ShowPreviousFormAction(() => FocusForm());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _options.Value.CurrentForm = this;
        }
    }
}