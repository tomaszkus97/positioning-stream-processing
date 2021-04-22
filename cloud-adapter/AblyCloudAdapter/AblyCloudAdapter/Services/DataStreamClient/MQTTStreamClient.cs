using AblyCloudAdapter.Contracts;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AblyCloudAdapter.Services.DataStreamClient
{
    public class MQTTStreamClient
    {
        private readonly IMqttClient _client;
        public MQTTStreamClient()
        {
            var factory = new MqttFactory();
            _client = factory.CreateMqttClient();
        }

        public async void InitializeConnection(StreamConnectionSettings settings, 
            Func<VehicleArriveEvent, Task> arsMessageReceivedCallback, Func<VehiclePositionEvent, Task> vpMessageReceivedCallback)
        {
            var options = new MqttClientOptionsBuilder()
                .WithWebSocketServer(settings.ServerAddress)
                .WithTls()
                .Build();

            _client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("### CONNECTED WITH SERVER ###");
                await _client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(settings.ChannelName).Build());
                Console.WriteLine("### SUBSCRIBED ###");
            });

            _client.UseApplicationMessageReceivedHandler(async eventArgs =>
            {
                var stringMessage = System.Text.Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload);
                var vpEvent = JsonConvert.DeserializeObject<VPEvent>(stringMessage);
                if(vpEvent.Event != null)
                {
                    Console.WriteLine($"VP event received: {eventArgs.ApplicationMessage.Topic}");
                    var message = new VehiclePositionEvent(vpEvent.Event);
                    await vpMessageReceivedCallback(message);
                    return;
                }
                var arsEvent = JsonConvert.DeserializeObject<ARSEvent>(stringMessage);
                if (arsEvent.Event != null)
                {
                    Console.WriteLine($"ARS event received: {eventArgs.ApplicationMessage.Topic}");
                    var direction = GetDirectionFromTopic(eventArgs.ApplicationMessage.Topic);
                    var nextStop = GetNextStopFromTopic(eventArgs.ApplicationMessage.Topic);
                    var message = new VehicleArriveEvent(arsEvent.Event, nextStop, direction);
                    await arsMessageReceivedCallback(message);
                    return;
                }

            });

            await _client.ConnectAsync(options, CancellationToken.None);
        }

        private string GetNextStopFromTopic(string topic)
        {
            var parts = topic.Split('/');
            return parts[13];
        }

        private int GetDirectionFromTopic(string topic)
        {
            int direction = 0;
            var parts = topic.Split('/');
            var dirString = parts[10];
            if(Int32.TryParse(dirString, out int j))
            {
                direction = j;
            };
            return direction;
        }

        internal void InitializeConnection()
        {
            throw new NotImplementedException();
        }
    }
}
