let Article = require('./article');

class ImageArticle extends Article {
    constructor(title, content, image) {
        super(title, content);
        this.image = image;
    }

    getElementString() {
        return `<div class="article">
    <div class="article-title">${super.title}</div>
    <div class="image"><img src="${this.image}"></div>
    <p>${super.content}</p>
</div>`;
    }
}

module.exports = ImageArticle;