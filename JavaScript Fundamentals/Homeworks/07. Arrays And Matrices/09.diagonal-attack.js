function diagonalAttack(matrix) {
    matrix = matrix.map(x => x.split(' ').map(Number));

    let mainSum = 0;
    let secondarySum = 0;
    for (let row = 0; row < matrix.length; row++) {
        mainSum += matrix[row][row];
        secondarySum += matrix[row][matrix[row].length - row - 1];
    }

    if (mainSum == secondarySum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (row != col && row != matrix[row].length - col - 1) {
                    matrix[row][col] = mainSum;
                }
            }
        }
    }

    return matrix.map(x => x.join(' ')).join('\n');
}