function extractLinks(input) {
    let regex = /www\.[a-zA-Z\-0-9]+(\.[a-z]+)+/g;

    let match;
    let links = [];

    for (let line of input) {
        while (match = regex.exec(line)) {
            links.push(match[0]);
        }
    }

    return links.join('\n');
}