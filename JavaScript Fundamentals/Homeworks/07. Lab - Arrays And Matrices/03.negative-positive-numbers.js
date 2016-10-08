function negativePositiveNumbers(input) {
    input = input.map(Number);
    let result = [];
    for (let num of input) {
        if (num < 0) {
            result.unshift(num);
        } else {
            result.push(num);
        }
    }

    return result.join('\n');
}