function findVariablesInSentence(input) {
    let variables = [];
    let regex = /\b_([a-zA-Z0-9]+)\b/g;
    let match;
    for (let line of input) {
        while (match = regex.exec(line)) {
            variables.push(match[1]);
        }
    }

    return variables.join(',');
}