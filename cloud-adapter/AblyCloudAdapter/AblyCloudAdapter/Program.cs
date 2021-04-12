using System;
using AblyCloudAdapter.Services.DataStreamClient;
using AblyCloudAdapter.Services.CloudStreamEmitter;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AblyCloudAdapter.Contracts;

namespace AblyCloudAdapter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var settings = InitOptions();

            var streamClient = new MQTTStreamClient();
            var azureEmitter = new AzureEventEmitter();
            //var googleEmitter = new GoogleCloudEventEmitter();

            //await googleEmitter.Initialize();

            streamClient.InitializeConnection(settings.StreamConnection, azureEmitter.SendMessage);

            Console.ReadLine();
        }

        private static IConfigurationRoot InitConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            return builder.Build();
        }

        private static CloudAdapterOptions InitOptions()
        {
            var config = InitConfig();
            return config.Get<CloudAdapterOptions>();
        }
    }
}
