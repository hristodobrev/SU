function rosettaStone(input) {
    let n = Number(input[0]);
    let templateMatrix = [];
    let encodedMatrix = [];
    let alphabet = {
        0: ' ',1: 'A',2: 'B',3: 'C',4: 'D',5: 'E',6: 'F',7: 'G',8: 'H',9: 'I',
        10: 'J',11: 'K',12: 'L',13: 'M',14: 'N',15: 'O',16: 'P',17: 'Q',18: 'R',19: 'S',
        20: 'T',21: 'U',22: 'V',23: 'W',24: 'X',25: 'Y',26: 'Z'
    };

    for (let i = 1; i < 1 + n; i++) {
        let currentRow = input[i].split(/\s+/).map(Number);
        templateMatrix.push(currentRow);
    }
    for (let i = n + 1; i < input.length; i++) {
        let currentRow = input[i].split(/\s+/).map(Number);
        encodedMatrix.push(currentRow);
    }

    let templateHeight = templateMatrix.length;
    let templateWidth = templateMatrix[0].length;

    // console.log(templateMatrix);
    // console.log();
    // console.log(encodedMatrix);

    for (let row = 0; row < encodedMatrix.length; row += templateMatrix.length) {
        for (let col = 0; col < encodedMatrix[row].length; col += templateMatrix[0].length) {
            merge(row, col);
        }
    }

    function merge(r, c) {
        for (let row = r, rowOffset = 0; row < Math.min(r + templateHeight, encodedMatrix.length); row++, rowOffset++) {
            for (let col = c, colOffset = 0; col < Math.min(c + templateWidth, encodedMatrix[row].length); col++, colOffset++) {
                encodedMatrix[row][col] += Number(templateMatrix[rowOffset][colOffset]);
            }
        }
    }

    // console.log(encodedMatrix);

    for (let row = 0; row < encodedMatrix.length; row++) {
        for (let col = 0; col < encodedMatrix[row].length; col++) {
            let value = encodedMatrix[row][col] % 27;
            encodedMatrix[row][col] = alphabet[value];
        }
    }

    console.log(encodedMatrix.map(x => x.join('')).map(x => x.replace(/\s+/, ' ')).join('').trim());
}

rosettaStone([ '2',
    '31 32',
    '74 37',
    '19 0 23 25',
    '22 3 12 17',
    '5 9 23 11']
);