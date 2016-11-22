let Article = require('./article');

class TableArticle extends Article {
    constructor(title, content) {
        super(title, content);
        this.headings = null;
        this.data = null;
    }

    loadData(headings, data) {
        this.headings = headings;
        this.data = data;
    }

    getElementString() {
        let result = `<div class="article">
    <div class="article-title">${super.title}</div>
    <p>${super.content}</p>
    <div class="table">
        <table class="data">`;

        let thead = '<tr>';
        for (let heading of this.headings) {
            thead += `<th>${heading}</th>`;
        }
        thead += '</tr>\n';
        result += thead;

        let tbody = '';
        for (let d of this.data) {
            let line = '<tr>';
            for (let head of this.headings) {
                head = head.replace(/\s+/g, '').toLowerCase();
                line += `<td>${d[head]}</td>`;
            }
            line += '</tr>';
            tbody += line;
        }
        result += tbody + '\n';

        result += `        </table>
    </div>
</div>`;

        return result;
    }
}

module.exports = TableArticle;