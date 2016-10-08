function capitalizeWords([text]) {
    text = text.toLowerCase().split(' ');
    let words = [];
    for (let word of text) {
        let newWord = word[0].toUpperCase() + word.slice(1);
        words.push(newWord);
    }

    return words.join(' ');
}