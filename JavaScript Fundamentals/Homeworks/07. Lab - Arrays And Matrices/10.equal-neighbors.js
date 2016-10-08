function equalNeighborsCount(input) {
    let matrix = input.map((row) => row.split(' '));

    let neighbors = 0;
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (col < matrix[row].length - 1 && matrix[row][col] == matrix[row][col + 1]) {
                neighbors++;
            }
            if (row < matrix.length - 1 && matrix[row][col] == matrix[row + 1][col]) {
                neighbors++;
            }
        }
    }

    return neighbors;
}