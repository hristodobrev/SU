function spiralMatrix([dimensions]) {
    dimensions = dimensions.split(' ');
    let rows = Number(dimensions[0]);
    let cols = Number(dimensions[1]);

    let matrix = [];
    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
    }

    let cell = 1;
    let row = 0;
    let col = 0;
    let dir = 'r';
    while (cell <= rows * cols) {
        matrix[row][col] = cell;

        if (dir == 'r' && (col >= cols - 1 || (col < cols && matrix[row][col + 1])))
            dir = 'd';
        if (dir == 'd' && (row >= rows - 1 || (row < rows && matrix[row + 1][col])))
            dir = 'l';
        if (dir == 'l' && (col <= 0 || (col > 0 && matrix[row][col - 1])))
            dir = 'u';
        if (dir == 'u' && (row <= 0 || (row > 0 && matrix[row - 1][col])))
            dir = 'r';

        switch(dir) {
            case 'r': col++; break;
            case 'd': row++; break;
            case 'l': col--; break;
            case 'u': row--; break;
        }
        cell++;
    }

    return matrix.map(x => x.join(' ')).join('\n');
}