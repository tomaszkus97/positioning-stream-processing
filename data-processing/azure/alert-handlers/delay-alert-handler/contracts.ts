export interface ArrivalEvent {
  VehicleNumber: string;
  TimeStamp: string;
  Latitude: number;
  Longitude: number;
  LineNumber: string;
  RouteNumber: string;
  Occupancy: number;
  Delay: number;
  NextStop: string;
  RouteDirection: number;
}

export interface RoutingResponse {
  stop: {
    name: string;
    stopTimesForPattern: [{
      scheduledArrival: number
    }]
  }
}