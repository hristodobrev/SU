function extractText([str]) {
    let results = [];
    let rightPar = -1;
    while (true) {
        let leftPar = str.indexOf('(', rightPar + 1);
        if (leftPar === -1) {
            break;
        }

        rightPar = str.indexOf(')', leftPar + 1);
        if (rightPar === -1) {
            break;
        }

        let textInside = str.substring(leftPar + 1, rightPar);
        results.push(textInside);
    }

    return results.join(', ');
}