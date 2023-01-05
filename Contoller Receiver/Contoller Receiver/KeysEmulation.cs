using WindowsInput;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace Contoller_Receiver
{
    internal class KeysEmulation
    {
        private InputSimulator _inputSimulator;
        private bool _isPressing_A;
        private bool _isPressing_D;
        private readonly IXbox360Controller _xbox;

        public KeysEmulation()
        {
            _inputSimulator = new InputSimulator();

            _isPressing_A = false;
            _isPressing_D = false;

            var client = new ViGEmClient();
            _xbox = client.CreateXbox360Controller();
            _xbox.Connect();
        }

        private void KeyDown_A()
        {
            if (!_isPressing_A)
            {
                _inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_A);
                _isPressing_A = true;
            }
        }

        private void KeyDown_D()
        {
            if (!_isPressing_D)
            {
                _inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_D);
                _isPressing_D = true;
            }
        }

        private void KeyUp_A()
        {
            if (_isPressing_A)
            {
                _inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_A);
                _isPressing_A = false;
            }
        }

        private void KeyUp_D()
        {
            if (_isPressing_D)
            {
                _inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_D);
                _isPressing_D = false;
            }
        }

        public void Rotate(double y)
        {
            if (y > 1)
                y = 1;
            else if (y < -1)
                y = -1;

            short tilt = (short)(short.MaxValue * y);
            if (tilt != 0)
            {
                _xbox.SetAxisValue(Xbox360Axis.LeftThumbX, tilt);
            }
        }

        public void KeyDown_W()
        {
            _inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);
        }

        public void KeyUp_W()
        {
            _inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
        }

        public void KeyDown_S()
        {
            _inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_S);
        }

        public void KeyUp_S()
        {
            _inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_S);
        }
    }
}
