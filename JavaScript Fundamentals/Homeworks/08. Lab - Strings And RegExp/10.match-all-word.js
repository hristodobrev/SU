function matchAllWords([towns]) {
    return towns.split(/\W+/).filter(x => x !== '').join('|');
}