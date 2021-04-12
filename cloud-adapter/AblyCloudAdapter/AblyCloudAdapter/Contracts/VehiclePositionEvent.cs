using System;

namespace AblyCloudAdapter.Contracts
{
    public class VehiclePositionEvent
    {
        public VehiclePositionEvent(VehiclePositionRawEvent raw)
        {
            VehicleNumber = raw.VehicleNumber;
            TimeStamp = raw.TimeStamp;
            Speed = raw.Speed;
            Heading = raw.Heading;
            Latitude = raw.Latitude;
            Longitude = raw.Longitude;
            Acceleration = raw.Acceleration;
            LineNumber = raw.LineNumber;
            RouteNumber = raw.RouteNumber;
            Occupancy = raw.Occupancy;
            Delay = raw.Delay;
        }

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
        public double Delay { get; set; }
    }
}