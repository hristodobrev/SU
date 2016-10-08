function secretData(input) {
    let regex = /\*[A-Z][A-Za-z]*(?=\s+|$)|\+[\d\-]{10}(?=\s+|$)|\![a-zA-Z\d]+(?=\s+|$)|\_[a-zA-Z\d]+(?=\s+|$)/g;

    let match;
    let result = [];

    for (let line of input) {
        let currentLine = line;
        currentLine = currentLine
            .replace(regex, x => '|'.repeat(x.length));
        result.push(currentLine);
    }

    return result.join('\n');
}