let inputs = $('div#add-book input, div#add-book textarea').keypress(function (e) {
    if(e.keyCode == 13) {
        addBook();
    }
});

function addBook() {
    let title = $('#add-book-title');
    let author = $('#add-book-author');
    let description = $('#add-book-description');

    addBookToDataBase(title.val(), author.val(), description.val());

    title.val('');
    author.val('');
    description.val('');
}

function addBookToDataBase(title, author, description){
    if(!title || !author || !description) {
        throw new Error('You must fill all fields.');
    }

    let bookData = { title: title, author: author, description: description };
    let authorization = 'Basic ' + btoa('guest:guest');

    $.ajax({
        method: 'POST',
        url: 'https://baas.kinvey.com/appdata/kid_S1EyK5OH/books',
        headers: {
            Authorization: authorization
        },
        data: bookData,
        success: showSuccess,
        error: showError
    });
}

function getBooksFromDatabase() {
    $.ajax({
        mehtod: 'GET',
        url: 'https://baas.kinvey.com/appdata/kid_S1EyK5OH/books',
        headers: {
            Authorization: 'Basic ' + btoa('guest:guest')
        },
        success: showData,
        error: showError
    });
}

function addComment(sender) {
    let children = $(sender).parent().parent().parent().children();
    let title = $($(children[0]).children()[0]).text();
    let author = $($(children[1]).children()[0]).text();
    let description = $(children[2]).text();

    $.ajax({
        mehtod: 'GET',
        url: 'https://baas.kinvey.com/appdata/kid_S1EyK5OH/books',
        headers: {
            Authorization: 'Basic ' + btoa('guest:guest')
        },
        success: findBook,
        error: showError
    });

    function findBook(data, status) {
        let bookFound;
        for (let book of data) {
            if(book.title == title && book.author == author && book.description == description) {
                bookFound = book;
                break;
            }
        }

        let comments = [];
        if(bookFound.comments) {
            comments = JSON.parse(bookFound.comments);
        }

        let currentComment = $(sender).prev().val();
        comments.push(currentComment);

        let stringifiedComments = JSON.stringify(comments);
        bookFound.comments = stringifiedComments;

        $.ajax({
            method: 'PUT',
            url: 'https://baas.kinvey.com/appdata/kid_S1EyK5OH/books/' + bookFound._id,
            headers: {
                Authorization: 'Basic ' + btoa('guest:guest')
            },
            data: bookFound,
            success: showSuccess,
            error: showError
        });
    }
}

function showData(data, status) {
    let booksList = $('ul#books-list');
    booksList.empty();
    for (book of data) {
        let li = $('<li>');
        li.append($('<h3>').html($('<a href="#">').text(book.title)));
        li.append($('<span>').html($('<a href="#">').text(book.author)));
        li.append($('<p>').text(book.description));
        let commentsDiv = $('<div class="comments">');
        commentsDiv.append($('<h3>').text('Comments'));

        if(book.comments){
            let comments = JSON.parse(book.comments);
            let commentsList = $('<ul>');

            for (let comment of comments) {
                commentsList.append($('<li>').text(comment));
            }

            commentsDiv.append(commentsList);
            li.append(commentsDiv);
        }

        let a = book.comments ? "Enter a comment..." : "Enter the first comment...";

        let commentButton = $('<button onclick="addComment(this)">').text('Add Comment');
        let commentField = $('<input type="text">').keypress(function (e) {
            if(e.keyCode == 13) {
                addComment(commentButton);
            }
        });
        commentField.attr('placeholder', a);

        commentsDiv.append($('<div class="add-comment">')
            .append(commentField)
            .append(commentButton));

        li.append(commentsDiv);

        booksList.append(li);
    }
}

function showSuccess(data, status) {
    getBooksFromDatabase();
    console.log(data);
}

function showError(data, status) {
    console.log(data);
}

(function () {
    getBooksFromDatabase();
}());