using System;

namespace AblyCloudAdapter.Contracts
{
    class VehiclePositionEvent
    {
        public int VehicleNumber { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Speed { get; set; }
        public int Heading { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Acceleration { get; set; }
        public string LineNumber { get; set; }
        public string RouteNumber { get; set; }
        public int Occupancy { get; set; }
    }
}