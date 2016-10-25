function fibonacci(n) {
    let fib = (function () {
        let f1 = 0;
        let f2 = 1;

        return () => {
            let result = f1 + f2;
            f1 = f2;
            f2 = result;

            return f1;
        }
    })();

    let numbers = [];
    for (let i = 0; i < n; i++) {
        numbers.push(fib());
    }

    return numbers;
}

fibonacci(5)