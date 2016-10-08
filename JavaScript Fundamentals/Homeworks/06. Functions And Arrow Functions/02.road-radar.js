function roadRadar([speed, area]) {
    speed = Number(speed);

    let speedLimits = [];
    speedLimits['motorway'] = 130;
    speedLimits['interstate'] = 90;
    speedLimits['city'] = 50;
    speedLimits['residential'] = 20;

    let speedDifference = speed - speedLimits[area];
    if (speedDifference > 0) {
        if (speedDifference <= 20) {
            return 'speeding';
        } else if (speedDifference <= 40) {
            return 'excessive speeding';
        } else {
            return 'reckless driving';
        }
    }
}