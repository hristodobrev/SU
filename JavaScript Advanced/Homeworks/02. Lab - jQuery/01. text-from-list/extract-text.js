function extractText() {
    let joinedItems = $('ul#items li')
        .toArray()
        .map(li => li.textContent)
        .join(', ');
    $('#result').text(joinedItems);
}