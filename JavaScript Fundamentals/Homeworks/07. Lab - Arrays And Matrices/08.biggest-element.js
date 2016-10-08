function biggestElement(input) {
    let matrix = input.map((row) => row.split(' ').map(Number));

    let biggest = Number.NEGATIVE_INFINITY;
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (biggest < matrix[row][col])
                biggest = matrix[row][col];
        }
    }

    return biggest;
}