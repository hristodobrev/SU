function* reverseArrayGenerator(arr) {
    for (let i = arr.length - 1; i >= 0; i--) {
        yield arr[i];
    }
}

function* oddNums() {
    let num = -1;
    while (true) {
        yield num += 2;
    }
}

let g = oddNums();

for (let i = 0; i < 10; i++) {
    console.log(g.next().value);
}

console.log('----------');

let arr = [1, 2, 3, 4, 5];
for (let num of reverseArrayGenerator(arr)) {
    console.log(num);
}

console.log([0, ...arr, 6, 7, 8, 9].join(' '));
console.log(Math.max(...arr));