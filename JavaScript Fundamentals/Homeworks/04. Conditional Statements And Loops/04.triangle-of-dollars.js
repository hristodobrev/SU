function triangleOfDollars([n]) {
    n = Number(n);
    for (let i = 1; i <= n; i++) {
        let row = '';
        for (let c = 1; c <= i; c++) {
            row += '$';
        }
        console.log(row);
    }
}