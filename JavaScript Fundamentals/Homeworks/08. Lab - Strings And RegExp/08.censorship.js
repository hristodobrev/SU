function censorship(input) {
    let text = input[0];
    let words = input.slice(1).join('|');
    let regex = new RegExp(words, 'g');
    text = text.replace(regex, w => '-'.repeat(w.length));

    return text;
}