function reverseArrayIterator(arr) {
    let index = arr.length - 1;

    return {
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
    };
}

let arr = [1, 2, 3, 4, 5];
let iterator = reverseArrayIterator(arr);
while (true) {
    let item = iterator.next();
    if (item.done) {
        break;
    }
    console.log(item.value);
}