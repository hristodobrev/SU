function firstAndLastKNumbers(input) {
    input = input.map(Number);
    let k = input[0];
    let arr = input.slice(1);
    let firstElements = arr.slice(0, k);
    let secondElements = arr.slice(Math.max(arr.length - k, 0));

    console.log(firstElements.join(' '));
    console.log(secondElements.join(' '));
}