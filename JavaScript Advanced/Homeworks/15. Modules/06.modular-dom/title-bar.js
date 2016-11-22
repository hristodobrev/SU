let BaseElement = require('./base-element');

class TitleBar extends BaseElement {
    constructor(title) {
        super();
        this.title = title;
        this.links = [];
    }

    addLink(href, name) {
        let link = `<a class="menu-link" href="${href}">${name}</a>`;
        this.links.push(link);
    }

    getElementString() {
        let result = `<header class="header">
    <div><span class="title">${this.title}</span></div>
    <div>
        <nav class="menu">`;

        result += this.links.join('|');

        result += `</nav>
    </div>
</header>`;

        return result;
    }
}

module.exports = TitleBar;