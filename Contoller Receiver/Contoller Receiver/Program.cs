using Contoller_Receiver.Connectors;
using Contoller_Receiver.Controllers;
using Contoller_Receiver.Forms;
using Contoller_Receiver.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Contoller_Receiver
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<HttpClient>()
                .AddSingleton<IConnector, WebConnector>()
                .AddSingleton<IConnectionController, ConnectionController>()
                .AddSingleton<IReceiverController, ReceiverController>()
                .AddSingleton<ISenderController, SenderController>()
                .AddSingleton<Form1>()
                .AddTransient<ControllerForm>()
                .AddTransient<ReceiverForm>()
                .AddSingleton<FormCreator>(_ => new FormCreator(_.GetRequiredService<ControllerForm>, _.GetRequiredService<ReceiverForm>))
                .AddSingleton<KeysEmulation>()
                .AddSingleton<ILogger, Logger>();
            serviceCollection.AddOptions<ProjectSettings>()
                .Configure(_ => _.ApiUrl = "http://ASPProjects.somee.com/AppController");

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(serviceProvider.GetRequiredService<Form1>());
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }
    }
}