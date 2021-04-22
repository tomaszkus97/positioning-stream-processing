export const getPredictedArrivalTime = (scheduledTime: number, delay: number): string => {
  const arrivalInSeconds = scheduledTime + delay;
  return new Date(arrivalInSeconds * 1000).toISOString().substr(11, 8)
}