function* lookAndSay(start) {
    let element = '' + start;
    while (true) {
        let nextElement = '';
        if (element.length == 1) {
            yield '1' + element;
            element = '1' + element;
        }

        let currentDigit = element[0];
        let currentCount = 1;
        for (let i = 1; i < element.length; i++) {
            if (element[i] == currentDigit) {
                currentCount++;
            } else {
                nextElement += '' + currentCount + currentDigit;
                currentDigit = element[i];
                currentCount = 1;
            }
            if (i == element.length - 1) {
                nextElement += '' + currentCount + currentDigit;
            }
        }

        yield nextElement;
        element = nextElement;
    }
}

let lookSequence = lookAndSay(113);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
