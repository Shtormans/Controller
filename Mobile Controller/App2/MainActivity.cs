using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using System;
using System.Net.Http;
using Xamarin.Essentials;

namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        public enum PageVariation
        {
            Controller,
            Connector,
            Nothing
        }

        public enum Commands
        {
            Forward,
            CancelForward,
            Back,
            CancelBack,
            Empty
        }

        private static PageVariation _page = PageVariation.Nothing;
        private bool _isStarted;
        private static bool _isConnected = false;
        public static string BaseUrl = "http://ASPProjects.somee.com/AppController";
        public static string RoomId = "";

        public static HttpClient Client;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Client = new HttpClient();

            InitializeConnectionPage();

            InitializeControllerPage();
        }

        private async void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading.Acceleration;

            string content = data.Y.ToString("F3");

            var JsonContent = APIResponseConverter.SerializeResponse(content);
            await Client.PostAsync($"{BaseUrl}/SetAxe/{RoomId}", JsonContent);
        }

        private void InitializeControllerPage()
        {
            _page = PageVariation.Controller;
            SetContentView(Resource.Layout.activity_main);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            Button startButton = FindViewById<Button>(Resource.Id.startButton);
            startButton.Click += StartButton_Click;

            Button runButton = FindViewById<Button>(Resource.Id.runButton);
            runButton.Touch += RunButton_Touch;

            Button stopButton = FindViewById<Button>(Resource.Id.stopButton);
            stopButton.Touch += StopButton_Touch;
        }

        private async void StopButton_Touch(object sender, View.TouchEventArgs e)
        {
            if (!_isConnected)
            {
                return;
            }

            if (e.Event.Action == MotionEventActions.Down)
            {
                var content = APIResponseConverter.SerializeResponse(Commands.Back);
                await Client.PostAsync($"{BaseUrl}/SetCommand/{RoomId}", content);
            }
            else if (e.Event.Action == MotionEventActions.Up || e.Event.Action == MotionEventActions.Cancel)
            {
                var content = APIResponseConverter.SerializeResponse(Commands.CancelBack);
                await Client.PostAsync($"{BaseUrl}/SetCommand/{RoomId}", content);
            }
        }

        private async void RunButton_Touch(object sender, View.TouchEventArgs e)
        {
            if (!_isConnected)
            {
                return;
            }

            if (e.Event.Action == MotionEventActions.Down)
            {
                var content = APIResponseConverter.SerializeResponse(Commands.Forward);
                await Client.PostAsync($"{BaseUrl}/SetCommand/{RoomId}", content);
            }
            else if (e.Event.Action == MotionEventActions.Up || e.Event.Action == MotionEventActions.Cancel)
            {
                var content = APIResponseConverter.SerializeResponse(Commands.CancelForward);
                await Client.PostAsync($"{BaseUrl}/SetCommand/{RoomId}", content);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                return;
            }

            _isStarted = !_isStarted;
            if (_isStarted)
            {
                Accelerometer.Start(SensorSpeed.Game);
            }
            else
            {
                Accelerometer.Stop();
            }
        }

        private void InitializeConnectionPage()
        {
            _isStarted = false;
            _page = PageVariation.Connector;
            SetContentView(Resource.Layout.server_connector);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            Button connectButton = FindViewById<Button>(Resource.Id.connectButton);
            connectButton.Click += ConnectButton_Click;

            var addressEditText = FindViewById<EditText>(Resource.Id.connectionAddress);
            addressEditText.Text = RoomId;

            var resultEditText = FindViewById<EditText>(Resource.Id.connectionResult);
            if (_isConnected)
            {
                resultEditText.Text = "Connected";
            }
            else
            {
                resultEditText.Text = "Not Connected";
            }
        }

        private async void ConnectButton_Click(object sender, System.EventArgs e)
        {
            var addressEditText = FindViewById<EditText>(Resource.Id.connectionAddress);
            RoomId = addressEditText.Text;

            var connectionResult = FindViewById<EditText>(Resource.Id.connectionResult);
            
            try
            {
                int.Parse(RoomId);
            }
            catch (Exception)
            {
                connectionResult.Text = "Incorrect address";
                return;
            }

            var passwordEditText = FindViewById<EditText>(Resource.Id.connectionPassword);
            string password = passwordEditText.Text;


            try
            {
                var content = APIResponseConverter.SerializeResponse(password);
                var response = await Client.PostAsync($"{BaseUrl}/TryConnect/{RoomId}", content);
                var result = await APIResponseConverter.DeserializeResponse<ResponseModel<bool>>(response);

                if (result.Success == false)
                {
                    connectionResult.Text = result.Error;
                    return;
                }

                connectionResult.Text = "Connected";
                _isConnected = true;
            }
            catch (System.Exception)
            {
                _isConnected = false;
                connectionResult.Text = "Server Error";
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    if (_page == PageVariation.Controller)
                    {
                        return false;
                    }
                    InitializeControllerPage();
                    return true;
                case Resource.Id.navigation_dashboard:
                    if (_page == PageVariation.Connector)
                    {
                        return false;
                    }
                    InitializeConnectionPage();
                    return true;
                case Resource.Id.navigation_notifications:
                    return true;
            }
            return false;
        }
    }
}

