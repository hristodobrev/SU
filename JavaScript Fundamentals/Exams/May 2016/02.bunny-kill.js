function bunnyKill(lines) {
    let matrix = [];
    let bombs = lines.splice(-1)[0].split(' ');
    for (let line of lines) {
        line = line.split(' ').map(x => Number(x));
        matrix.push(line);
    }

    for (let bomb of bombs) {
        bombCell(bomb);
    }

    function bombCell(cell) {
        let [row, col] = cell.split(',').map(x => Number(x));
        let minRow = Math.max(row - 1, 0);
        let minCol = Math.max(col - 1, 0);
        let maxRow = Math.min(row + 1, matrix.length - 1);
        let maxCol = Math.min(col + 1, matrix[row].length - 1);
        let damage = matrix[row][col];

        for (let curRow = minRow; curRow <= maxRow; curRow++) {
            for (let curCol = minCol; curCol <= maxCol; curCol++) {
                if (curCol != col || curRow != row) {
                    matrix[curRow][curCol] -= damage;
                }
            }
        }
    }

    let damage = 0;
    let bunnies = 0;
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (matrix[row][col] > 0) {
                bunnies++;
                damage += matrix[row][col];
            }
        }
    }

    console.log(`${damage}\n${bunnies}`);
    console.log(matrix);
}

bunnyKill([
    '5 10 15 20',
    '10 10 10 10',
    '10 15 10 10',
    '10 10 10 10',
    '2,2 0,1'
]);