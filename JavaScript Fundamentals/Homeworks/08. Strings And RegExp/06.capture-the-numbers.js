function captureNumbers(input) {
    let nums = [];
    let regex = /[0-9]+/g;
    let match;
    for (let line of input) {
        while (match = regex.exec(line)) {
            nums.push(match);
        }
    }

    return nums.join(' ');
}