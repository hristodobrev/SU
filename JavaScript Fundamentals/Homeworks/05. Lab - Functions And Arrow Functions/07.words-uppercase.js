function wordsUppercase([str]) {
    let strToUpper = str.toUpperCase();
    let words = extractWords();
    words = words.filter(w => w != '');

    return words.join(', ');

    function extractWords() {
        return strToUpper.split(/\W+/);
    }
}