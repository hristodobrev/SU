function calcExpression() {
    var expression = document.getElementById('expression').value;

    document.getElementById('result').innerHTML = eval(expression);
}