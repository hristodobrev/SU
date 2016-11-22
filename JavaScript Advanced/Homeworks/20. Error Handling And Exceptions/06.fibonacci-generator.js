function* fibonacci() {
    let first = 1;
    let second = 1;

    while (true) {
        if (first == 1 && second == 1) {
            yield first;
        }
        if (second == 1) {
            yield second;
        }

        let current = first + second;
        yield current;
        first = second;
        second = current;
    }
}

let fib = fibonacci();
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);