function functionalCalculator([a, b, op]) {
    [a,b] = [a,b].map(Number);

    let sum = (a,b) => a + b;
    let sub = (a,b) => a - b;
    let mult = (a,b) => a * b;
    let div = (a,b) => a / b;

    switch (op) {
        case '+': return sum(a,b); break;
        case '-': return sub(a,b); break;
        case '*': return mult(a,b); break;
        case '/': return div(a,b); break;
    }
}