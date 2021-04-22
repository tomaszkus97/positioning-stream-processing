using System;
using System.Collections.Generic;
using System.Text;

namespace AblyCloudAdapter.Contracts
{
    public class VehicleArriveEvent
    {
        public VehicleArriveEvent(VehiclePositionRawEvent raw, string nextStop, int routeDirection)
        {
            VehicleNumber = raw.VehicleNumber;
            TimeStamp = raw.TimeStamp;
            Latitude = raw.Latitude;
            Longitude = raw.Longitude;
            LineNumber = raw.LineNumber;
            RouteNumber = raw.RouteNumber;
            Occupancy = raw.Occupancy;
            Delay = raw.Delay;
            NextStop = nextStop;
            RouteDirection = routeDirection;
        }

        public int VehicleNumber { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LineNumber { get; set; }
        public string RouteNumber { get; set; }
        public int Occupancy { get; set; }
        public double Delay { get; set; }
        public string NextStop { get; set; }
        public int RouteDirection { get; set; }
    }
}
