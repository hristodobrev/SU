function* reverseGenerator(arr) {
    for (let i = arr.length - 1; i >= 0; i--) {
        yield arr[i];
    }
}

let arr = [1, 2, 3, 4, 5];
for (let obj of reverseGenerator(arr)) {
    console.log(obj);
}