function chessboard([n]) {
    let html = '<div class="chessboard">\n';
    let color = 'black';
    for (let row = 1; row <= n; row++) {
        color = row % 2 == 1 ? 'black' : 'white';
        html += '  <div>\n';
        for (let col = 1; col <= n; col++) {
            html += `    <span class="${color}"></span>\n`;
            if (color == 'white')
                color = 'black';
            else
                color = 'white';
        }
        html += '  </div>\n';
    }
    html += '</div>';

    return html;
}