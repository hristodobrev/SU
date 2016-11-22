function mapSort(map, sortFn) {
    if (!sortFn) {
        map = new Map([...map].sort());
    } else {
        map = new Map([...map].sort(sortFn));
    }

    return map;
}

module.exports = mapSort;