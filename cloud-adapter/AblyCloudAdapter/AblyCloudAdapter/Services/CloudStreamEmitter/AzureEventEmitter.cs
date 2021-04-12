using AblyCloudAdapter.Contracts;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AblyCloudAdapter.Services.CloudStreamEmitter
{
    public class AzureEventEmitter : ICloudEmitter
    {
        private const string connectionString = "Endpoint=sb://positioning-data-hub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=mZwHX1u86Vat95ce2qT5SCI2FWCC9kOlNerXsia0Axo=";
        private const string eventHubName = "positioning-data";
        private readonly EventHubProducerClient _client;

        public AzureEventEmitter()
        {
            _client = new EventHubProducerClient(connectionString, eventHubName);
        }

        public async Task SendMessage(VehiclePositionEvent message)
        {
            var messageJson = JsonConvert.SerializeObject(message);

            using EventDataBatch eventBatch = await _client.CreateBatchAsync();

            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(messageJson)));

            Console.WriteLine($"Sending message {messageJson}");

            //await _client.SendAsync(eventBatch);
        }
    }
}
