function getTrafficCoeff(averageSpeed, averageDelay) {
    return averageSpeed - (averageDelay > 0 ? averageDelay : 0);
}