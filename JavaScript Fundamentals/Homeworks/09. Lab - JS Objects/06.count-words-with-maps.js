function countWordsInTextWithMaps(data) {
    let words = data.join('\n').toLowerCase()
        .split(/[^a-zA-Z\d_]+/).filter(x => x != '');

    let wordsCount = new Map();

    for (let word of words) {
        if (!wordsCount.has(word)) {
            wordsCount.set(word, 1);
        } else {
            wordsCount.set(word, wordsCount.get(word) + 1);
        }
    }

    let allWords = Array.from(wordsCount.keys()).sort();

    allWords.forEach(w => console.log(`'${w}' -> ${wordsCount.get(w)} times`));
}