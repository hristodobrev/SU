function sumFirstLast(input) {
    input = input.map(Number);
    let first = input[0];
    let last = input[input.length - 1];
    let sum = first + last;

    return sum;
}