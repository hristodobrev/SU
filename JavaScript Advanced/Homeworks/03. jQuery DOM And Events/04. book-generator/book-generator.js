createBook = (function createBook(selector, title, author, isbn) {
    let bookId = 1;

    return function (selector, title, author, isbn) {
        let book = $('<div>');
        let id = 'book' + bookId;
        book.css('border', 'medium none');
        book.attr('id', id);
        bookId++;

        let titleParagraph = $('<p class="title">').text(title);
        let authorParagraph = $('<p class="author">').text(author);
        let isbnParagraph = $('<p class="isbn">').text(isbn);

        let selectBtn = $('<button>Select</button>');
        let deselectBtn = $('<button>Deselect</button>');

        selectBtn.on('click', function () {
            book.css('border', '2px solid blue');
        });

        deselectBtn.on('click', function () {
            book.css('border', 'none');
        });

        book.append(titleParagraph);
        book.append(authorParagraph);
        book.append(isbnParagraph);
        book.append(selectBtn);
        book.append(deselectBtn);

        $(selector).append(book);
    }
})();