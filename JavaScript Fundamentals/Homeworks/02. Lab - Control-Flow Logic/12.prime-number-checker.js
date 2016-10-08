function primeNumberChecker(num) {
    let prime = num > 1;
    for (let d = 2; d <= Math.sqrt(num); d++) {
        if (num % d == 0) {
            prime = false;
            break;
        }
    }

    return prime;
}