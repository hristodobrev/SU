function rounding([num, precision]) {
    if (precision > 15) {
        precision = 15;
    }

    let step = Math.pow(10, precision);
    let result = Math.round(num * step) / step;

    return result;
}