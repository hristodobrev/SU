function magicMatrices(matrix) {
    matrix = matrix.map(x => x.split(' ').map(Number));

    let sum = 0;
    for (let i = 0; i < matrix[0].length; i++) {
        sum += matrix[0][i];
    }

    for (let row = 0; row < matrix.length; row++) {
        let currentSum = 0;
        for (let col = 0; col < matrix[0].length; col++) {
            currentSum += matrix[row][col];
        }
        if (currentSum != sum) {
            return 'false';
        }
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let currentSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            currentSum += matrix[row][col];
        }
        if (currentSum != sum) {
            return 'false';
        }
    }

    return 'true';
}