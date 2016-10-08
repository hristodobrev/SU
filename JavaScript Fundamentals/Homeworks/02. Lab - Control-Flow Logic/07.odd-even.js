function oddEven([num]) {
    let rem = num % 2;
    if (rem == 0) {
        return 'even';
    } else if (rem == Math.round(rem)) {
        return 'odd';
    }

    return 'invalid';
}