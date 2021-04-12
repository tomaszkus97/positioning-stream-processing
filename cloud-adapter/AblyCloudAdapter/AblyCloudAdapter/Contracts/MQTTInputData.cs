using System;
using Newtonsoft.Json;

namespace AblyCloudAdapter.Contracts
{
    public class VehiclePositionRawEvent
    {
        [JsonProperty("veh")]
        public int VehicleNumber { get; set; }
        [JsonProperty("tst")]
        public DateTime TimeStamp { get; set; }
        [JsonProperty("spd")]
        public double Speed { get; set; }
        [JsonProperty("hdg")]
        public int Heading { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("long")]
        public double Longitude { get; set; }
        [JsonProperty("acc")]
        public double Acceleration { get; set; }
        [JsonProperty("line")]
        public string LineNumber { get; set; }
        [JsonProperty("route")]
        public string RouteNumber { get; set; }
        [JsonProperty("occu")]
        public int Occupancy { get; set; }
        [JsonProperty("dl")]
        public double Delay { get; set; }
    }

    public class MQTTInputData
    {
        [JsonProperty("ARS")]
        public VehiclePositionRawEvent Event { get; set; }
    }
}
