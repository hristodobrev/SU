function diagonalSums(input) {
    let matrix = input.map((row) => row.split(' ').map(Number));

    let mainSum = 0, secondarySum = 0;
    for (let row = 0; row < matrix.length; row++) {
        mainSum += matrix[row][row];
        secondarySum += matrix[row][matrix.length - row - 1];
    }

    return mainSum + ' ' + secondarySum;
}