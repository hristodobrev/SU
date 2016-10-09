function countWordsInText(data) {
    let text = data.join('\n');

    let words = text.split(/[^A-Za-z0-9_]+/)
        .filter(w => w != '');

    let wordCounts = {};
    for (let word of words) {
        if (!wordCounts[word]) {
            wordCounts[word] = 0;
        }
        wordCounts[word]++;
    }

    return JSON.stringify(wordCounts);
}