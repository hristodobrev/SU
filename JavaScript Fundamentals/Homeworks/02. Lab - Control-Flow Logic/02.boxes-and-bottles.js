function boxesAndBottles([a, b]) {
    let n = Math.floor(a / b);
    if (a % b != 0) {
        n++;
    }

    return n;
}