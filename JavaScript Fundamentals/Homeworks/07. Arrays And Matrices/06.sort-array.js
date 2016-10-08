function sortArray(arr) {
    arr.sort((a, b) => b < a).sort((a, b) => a.length - b.length);

    return arr.join('\n');
}