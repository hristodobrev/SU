function multiplicationTable([n]) {
    let result = '<table border="1">\n';
    result += '<tr><th>x</th>';
    for (let i = 1; i <= n; i++) {
        result += `<th>${i}</th>`;
    }
    result += '</tr>\n';
    for (let row = 1; row <= n; row++) {
        result += `<tr><th>${row}</th>`;
        for (let col = 1; col <= n; col++) {
            result += `<td>${col*row}</td>`;
        }
        result += '</tr>\n';
    }
    result += '</table>';

    return result;
}