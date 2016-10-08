function binToDec([binNum]) {
    let decNum = 0;
    for (let i = binNum.length - 1, pow = 0; i >= 0; i--, pow++) {
        if (binNum[i] === '1') {
            decNum += Math.pow(2, pow);
        }
    }

    return decNum;
}