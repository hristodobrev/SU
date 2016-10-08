function orbit([orbitSize, start]) {
    [orbitSize, start] = [orbitSize.split(' ').map(Number), start.split(' ').map(Number)];
    let rows = orbitSize[0];
    let cols = orbitSize[1];
    let startRow = start[0];
    let startCol = start[1];
    let matrix = [];

    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            let value = Math.max(Math.abs(col - startCol), Math.abs(row - startRow));
            matrix[row][col] = value + 1;
        }
    }


    return matrix.map(x => x.join(' ')).join('\n');
}