function scoreToHTML(scoreStr) {
    let scoreArr = JSON.parse(scoreStr);
    let html = '<table>\n';
    html += '  <tr><th>name</th><th>score</th></tr>\n';

    for (let score of scoreArr) {
        html += `  <tr><td>${htmlEscape(score.name)}</td><td>${htmlEscape(score.score)}</td></tr>\n`;
    }

    html += '</table>';

    return html;

    function htmlEscape(text) {
        text = new String(text);
        let map = { '"': '&quot;', '&': '&amp;', '\'': '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}