function arithmephile(input) {
    let maxProduct = Number.NEGATIVE_INFINITY;
    for (let i = 0; i < input.length; i++) {
        let num = Number(input[i]);
        if (num >= 0 && num < 10){
            let currentProduct = 1;
            for (let j = i + 1; j < Math.min(i + num + 1, input.length); j++) {
                currentProduct *= Number(input[j]);
            }
            if (maxProduct < currentProduct){
                maxProduct = currentProduct;
            }
        }
    }

    return maxProduct;
}

console.log(arithmephile([
    100,
    200,
    2,
    3,
    2,
    3,
    2,
    1,
    1
]));