import request, { gql } from "graphql-request";
import { RoutingResponse } from "./contracts";

export const getStopDetails = async (nextStop: string, routeId: string, routeDirection: number): Promise<RoutingResponse> => {
  const stopId= `HSL:${nextStop}`;
  const routePattern = `HSL:${routeId}:${routeDirection - 1}:01`;
    const endpoint = 'https://api.digitransit.fi/routing/v1/routers/hsl/index/graphql';

    const query = gql`
            query getStop( $stopId: String!, $routePattern: String!) {
                stop(id: $stopId) {
                name
                stopTimesForPattern(id: $routePattern, numberOfDepartures: 1) {
                    scheduledArrival
                    }  
                }
            }
        `
    const variables = {
        stopId,
        routePattern
    }

    return await request(endpoint, query, variables);
}