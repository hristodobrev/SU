function reverseArrayIterable(arr) {
    let index = arr.length - 1;

    return {
        [Symbol.iterator]: function () {
            return this;
        },
        next: function () {
            if (index >= 0) {
                return {
                    value: arr[index--],
                    done: false
                };
            } else {
                return {
                    done: true
                };
            }
        }
    }
}

let arr = [1, 2, 3, 4, 5];
let iterable = reverseArrayIterable(arr);

for (let num of iterable) {
    console.log(num);
}