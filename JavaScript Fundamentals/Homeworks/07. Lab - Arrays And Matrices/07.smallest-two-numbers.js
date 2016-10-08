function smallest2Nums(input) {
    let result = input.sort((a, b) => a - b)
        .slice(0, 2);

    return result.join(' ');
}