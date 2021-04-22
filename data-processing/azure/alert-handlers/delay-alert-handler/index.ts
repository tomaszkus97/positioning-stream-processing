import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import { ArrivalEvent} from './contracts';
import { getStopDetails } from "./routing-api-client";

const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    const event: ArrivalEvent = req.body;
    context.log('HTTP trigger function processed a request.', event);
    
    const response = await getStopDetails(event.NextStop, event.RouteNumber, event.RouteDirection);

    context.log(JSON.stringify(response));

    context.res = {
        status: 200, /* Defaults to 200 */
    };

};

export default httpTrigger;