using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
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

        public async void InitializeConnection(StreamConnectionSettings settings, Func<byte[], Task> messageReceivedCallback)
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
                Console.WriteLine($"Message received: {eventArgs.ApplicationMessage.Topic}" );
                await messageReceivedCallback(eventArgs.ApplicationMessage.Payload);
            });

            await _client.ConnectAsync(options, CancellationToken.None);
        }

        internal void InitializeConnection()
        {
            throw new NotImplementedException();
        }
    }
}
