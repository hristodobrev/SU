function quadraticEquation([a, b, c]) {
    [a, b, c] = [a, b, c].map(Number);

    let descriminant = (b * b) - (4 * a * c);

    if (descriminant > 0) {
        let x1 = (-b - Math.sqrt(descriminant)) / (2 * a);
        let x2 = (-b + Math.sqrt(descriminant)) / (2 * a);

        if (x1 > x2) {
            [x1,x2] = [x2,x1];
        }

        return `${x1}\n${x2}`;
    }

    if (descriminant == 0) {
        let x = -b / (2 * a);

        if (x === -0) {
            x = 0;
        }

        return x;
    }

    return 'No';
}