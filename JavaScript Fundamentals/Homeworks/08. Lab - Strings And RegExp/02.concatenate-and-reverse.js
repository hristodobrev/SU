function concatenateAndReverse(arr) {
    let allStrings = arr.join('');
    return allStrings.split('').reverse().join('');
}