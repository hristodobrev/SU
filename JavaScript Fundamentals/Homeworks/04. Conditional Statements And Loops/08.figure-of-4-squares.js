function figureOf4Squares([n]) {
    n = Number(n);
    if (n == 2) {
        return '+++';
    }
    let horizontalLine = '+';
    for (let i = 0; i < n - 2; i++) {
        horizontalLine += '-';
    }
    horizontalLine += '+';
    for (let i = 0; i < n - 2; i++) {
        horizontalLine += '-';
    }
    horizontalLine += '+';

    let lines = n - 3;
    if (n % 2 === 0) {
        lines--;
    }
    lines /= 2;

    let verticalLine = horizontalLine.split('+').join('|').split('-').join(' ');
    console.log(horizontalLine);
    for (let i = 0; i < lines; i ++) {
        console.log(verticalLine);
    }
    console.log(horizontalLine);
    for (let i = 0; i < lines; i ++) {
        console.log(verticalLine);
    }
    if (n > 2) {
        console.log(horizontalLine);
    }
}