function aggregateElements(input) {
    let elements = input.map(Number);

    aggregate(elements, 0, (a,b) => a + b);
    aggregate(elements, 0, (a,b) => a + 1 / b);
    aggregate(elements, '', (a,b) => a + b);

    function aggregate(arr, initVal, func) {
        let result = initVal;
        for (let i = 0; i < arr.length; i++) {
            result = func(result, arr[i]);
        }
        console.log(result);
    }
}