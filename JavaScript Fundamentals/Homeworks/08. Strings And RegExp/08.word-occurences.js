function wordOccurences([text, word]) {
    let regex = new RegExp(('\\b' + word + '\\b'), 'gi');

    let matches = text.match(regex);

    return matches ? matches.length : 0;
}