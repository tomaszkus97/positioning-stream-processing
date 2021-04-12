using System;
using System.Collections.Generic;
using System.Text;

namespace AblyCloudAdapter.Contracts
{
    class VehicleArriveEvent
    {
        public VehicleArriveEvent(VehiclePositionRawEvent raw)
        {
            VehicleNumber = raw.VehicleNumber;
            TimeStamp = raw.TimeStamp;
            Latitude = raw.Latitude;
            Longitude = raw.Longitude;
            LineNumber = raw.LineNumber;
            RouteNumber = raw.RouteNumber;
            Occupancy = raw.Occupancy;
            Delay = raw.Delay;
        }

        public int VehicleNumber { get; set; }
        public DateTime TimeStamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LineNumber { get; set; }
        public string RouteNumber { get; set; }
        public int Occupancy { get; set; }
        public double Delay { get; set; }
    }
}
