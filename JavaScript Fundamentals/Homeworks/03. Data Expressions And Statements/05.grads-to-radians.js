function gradsToRadiansw([grads]) {
    let gradMultiplier = 360 / 400;
    let degrees = gradMultiplier * grads;

    degrees = degrees % 360;
    if (degrees < 0) {
        degrees += 360;
    }

    return degrees;
}