import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import { ArrivalEvent} from './contracts';
import { getStopDetails } from "./routing-api-client";
import { getPredictedArrivalTime } from "./timingFunctions";

const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    const event: ArrivalEvent = req.body;
    const nextStop = await getStopDetails(event.NextStop, event.RouteNumber, event.RouteDirection);

    const scheduledArrival = nextStop.stop.stopTimesForPattern[0]?.scheduledArrival;

    context.log(getPredictedArrivalTime(scheduledArrival, event.Delay));

    context.res = {
        status: 200, /* Defaults to 200 */
    };

};

export default httpTrigger;