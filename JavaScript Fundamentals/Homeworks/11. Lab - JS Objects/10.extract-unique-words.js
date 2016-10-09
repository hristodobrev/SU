function extractUniqueWords(sentences) {
    let uniqueWords = [];
    for (let sentence of sentences) {
        let words = sentence.split(/[^a-zA-Z]+/).map(x => x.trim()).filter(x => x !== '');
        for (let word of words) {
            if (uniqueWords.indexOf(word.toLowerCase()) === -1) {
                uniqueWords.push(word.toLowerCase());
            }
        }
    }

    return uniqueWords.join(', ');
}

extractUniqueWords([
    'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.'
]);