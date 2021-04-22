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
        private const string positioningHubName = "positioning-data";
        private const string arrivalHubName = "arrival-data";
        private readonly EventHubProducerClient _positioningClient;
        private readonly EventHubProducerClient _arrivalClient;

        public AzureEventEmitter()
        {
            _positioningClient = new EventHubProducerClient(connectionString, positioningHubName);
            _arrivalClient = new EventHubProducerClient(connectionString, arrivalHubName);
        }

        public async Task SendARSMessage(VehicleArriveEvent message)
        {
            var messageJson = JsonConvert.SerializeObject(message);

            using EventDataBatch eventBatch = await _arrivalClient.CreateBatchAsync();

            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(messageJson)));

            Console.WriteLine($"Sending ARS message {messageJson}");

            await _arrivalClient.SendAsync(eventBatch);
        }

        public async Task SendVPMessage(VehiclePositionEvent message)
        {
            var messageJson = JsonConvert.SerializeObject(message);

            using EventDataBatch eventBatch = await _positioningClient.CreateBatchAsync();

            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(messageJson)));

            Console.WriteLine($"Sending VP message {messageJson}");

            await _positioningClient.SendAsync(eventBatch);
        }


    }
}
