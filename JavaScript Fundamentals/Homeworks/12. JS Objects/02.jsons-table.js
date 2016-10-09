function jsonTable(jsonStrings) {
    let html = '<table>\n';
    for (let jsonString of jsonStrings) {
        let employee = JSON.parse(jsonString);
        html += '    <tr>\n';
        for (let key in employee) {
            html += `        <td>${employee[key]}</td>\n`;
        }
        html += '    <tr>\n';
    }
    html += '</table>';

    return html;
}

jsonTable([
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]);