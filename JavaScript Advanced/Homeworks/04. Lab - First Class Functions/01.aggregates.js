function aggregates(input) {
    let sum = reducer(input, (a, b) => a + b);
    let min = reducer(input, (a, b) => Math.min(a, b));
    let max = reducer(input, (a, b) => Math.max(a, b));
    let product = reducer(input, (a, b) => a * b);
    let join = reducer(input, (a, b) => [a, b].join(''));

    console.log('Sum = ' + sum);
    console.log('Min = ' + min);
    console.log('Max = ' + max);
    console.log('Product = ' + product);
    console.log('Join = ' + join);

    function reducer(arr, func) {
        let result = arr[0];
        for (let i = 1; i < arr.length; i++) {
            result = func(result, arr[i]);
        }

        return result;
    }
}

aggregates([2, 3, 10, 5]);