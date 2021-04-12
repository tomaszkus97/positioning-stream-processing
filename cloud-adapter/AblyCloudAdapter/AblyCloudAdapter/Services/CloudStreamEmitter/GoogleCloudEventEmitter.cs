using AblyCloudAdapter.Contracts;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Grpc.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Google.Cloud.PubSub.V1.PublisherClient;

namespace AblyCloudAdapter.Services.CloudStreamEmitter
{
    public class GoogleCloudEventEmitter : ICloudEmitter
    {
        private const string topicId = "positioning-data";
        private const string projectId = "positioning-stream-processing";
        private PublisherClient _client;
        public GoogleCloudEventEmitter() 
        { 
        }

        public async Task Initialize()
        {
            TopicName topicName = new TopicName(projectId, topicId);
            _client = await PublisherClient.CreateAsync(topicName);
        }

        public async Task SendMessage(VehiclePositionEvent message)
        {
            var messageJson = JsonConvert.SerializeObject(message);
            
            var pubsubMessage = new PubsubMessage()
            {
                Data = ByteString.CopyFromUtf8(messageJson)
            };

            await _client.PublishAsync(pubsubMessage);
        }
    }
}
