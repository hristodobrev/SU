function expressionSplit([expression]) {
    return expression.split(/[\s.();,]+/).filter(x => x != '').join('\n');
}