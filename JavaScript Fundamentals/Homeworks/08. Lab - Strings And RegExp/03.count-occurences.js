function countOccurences([word, str]) {
    str = str.toLowerCase();
    word = word.toLowerCase();
    let count = 0;
    let index = 0;
    while (index >= 0) {
        index = str.indexOf(word, index + 1);

        if (index !== -1) {
            count++;
        }
    }

    return count;
}