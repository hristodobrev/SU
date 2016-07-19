const kinveyBaseUrl = 'https://baas.kinvey.com/';
const kinveyAppKey = 'kid_S1EyK5OH';
const kinveyAppSecret = 'e187b0f2b16e4bc0ad573103b0a5b48e';

function showView(viewId) {
    $('main > section').hide();
    $('#' + viewId).show();
}

function showHideMenuLinks() {
    $('#link-home').show();
    if(sessionStorage.getItem('authToken') == null) {
        $('#link-login').show();
        $('#link-register').show();
        $('#link-list-books').hide();
        $('#link-create-book').hide();
        $('#link-logout').hide();
    } else {
        $('#link-login').hide();
        $('#link-register').hide();
        $('#link-list-books').show();
        $('#link-create-book').show();
        $('#link-logout').show();
    }
}

function showInfo(message) {
    $('#info-box').text(message);
    $('#info-box').fadeIn();
    setTimeout(function () {
        $('#info-box').fadeOut()
    }, 3000);
}

function showError(errorMsg) {
    $('#error-box').text('Error: ' + errorMsg);
    $('#error-box').fadeIn();
}

function showHomeView(){
    showView('view-home');
}

function showLoginView(){
    showView('view-login');
}

function login(){
    const kinveyLoginUrl = kinveyBaseUrl + 'user/' + kinveyAppKey + '/login';
    const kinveyAuthHeaders = { Authorization: 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret) };

    let userData = {
        username: $('#login-user').val(),
        password: $('#login-pass').val()
    };

    $.ajax({
        method: 'POST',
        url: kinveyLoginUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: loginSuccess,
        error: handleAjaxError
    });

    function loginSuccess(response) {
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        showHideMenuLinks();
        listBooks();
        showInfo('Logged in successfully.');
    }
}

function showRegisterView(){
    showView('view-register');
}

function register() {
    const kinveyLoginUrl = kinveyBaseUrl + 'user/' + kinveyAppKey + '/';
    const kinveyAuthHeaders = { Authorization: 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret) };

    let userData = {
        username: $('#register-user').val(),
        password: $('#register-pass').val()
    };

    $.ajax({
        method: 'POST',
        url: kinveyLoginUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: registerSuccess,
        error: handleAjaxError
    });

    function registerSuccess(response) {
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        showHideMenuLinks();
        listBooks();
        showInfo('Registered successfully.');
    }
}

function listBooks(){
    $('#books').empty();
    showView('view-books');

    const kinveyBooksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/book-library';
    const kinveyAuthHeaders = {
        Authorization: 'Kinvey ' + sessionStorage.getItem('authToken')
    };

    $.ajax({
        method: 'GET',
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        success: loadBooksSuccess,
        error: handleAjaxError
    });

    function loadBooksSuccess(books) {
        showInfo('Books loaded successfully.');
        if(books.length == 0) {
            $('#books').text('No books in the library.');
        } else {
            let booksTable = $('<table>')
                .append($('<tr>')
                    .append(
                        $('<th>Title</th>'),
                        $('<th>Author</th>'),
                        $('<th>Description</th>'))
                );

            for (let book of books) {
                booksTable.append(
                    $('<tr>').append(
                        $('<td>').text(book.title),
                        $('<td>').text(book.author),
                        $('<td>').text(book.description))
                );

                let commentsRow = $('<tr class="comments-row">');
                let commentsDataCol = $('<td colspan="3">');
                if(book.comments) {
                    let commentsList = $('<ul>');
                    console.log(book.comments);
                    for(let comment of book.comments) {
                        commentsList.append(
                            $('<li>').append(
                                $('<p class="comment">').text(comment.text),
                                $('<p class="author">').text('--' + comment.author))
                        );
                    }
                    commentsDataCol.append(commentsList);
                }

                commentsDataCol.append($('<a href="#" onclick="showCommentField(this)">').text('Add comment...'));
                let commentForm = $('<form>');
                commentForm.append($('<input type="text" placeholder="Type your name..." required="true">'));
                commentForm.append($('<input type="text" placeholder="Enter your comment..." required="true">'));
                commentForm.append($('<input type="submit" value="Add comment" onclick="addComment(this)">'));
                commentForm.append($('<input type="button" value="Cancel" onclick="hideCommentField(this)">'));
                commentsDataCol.append(commentForm);
                commentsRow.append(commentsDataCol);
                booksTable.append(commentsRow);
            }

            $('#books').append(booksTable);
        }
    }
}

function showCommentField(button){
    button = $(button);
    button.hide();
    button.next().fadeIn();
}

function hideCommentField(button) {
    button = $(button);
    button.parent().hide();
    button.parent().prev().fadeIn();
}

function addComment(button) {
    const kinveyBooksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/book-library';
    const kinveyAuthHeaders = {
        Authorization: 'Kinvey ' + sessionStorage.getItem('authToken')
    };

    button = $(button);
    let bookSplited = button.parent().parent().parent().prev().children();
    let title = $(bookSplited[0]).text();
    let author = $(bookSplited[1]).text();
    let description = $(bookSplited[2]).text();
    let commentAuthor = button.prev().prev().val();
    let commentText = button.prev().val();

    $.ajax({
        method: 'GET',
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        success: findBook,
        error: handleAjaxError
    });

    function findBook(books) {
        for (let book of books) {
            if(book.title == title && book.author == author && book.description == description) {
                addBookComment(book, commentText, commentAuthor);
                return;
            }
        }
    }
}

function addBookComment(bookData, commentText, commentAuthor) {
    const kinveyBooksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/book-library';
    const kinveyAuthHeaders = {
        Authorization: 'Kinvey ' + sessionStorage.getItem('authToken'),
        'Content-type': 'application/json'
    };

    if(!bookData.comments) {
        bookData.comments = [];
    }

    bookData.comments.push({text: commentText, author: commentAuthor});

    $.ajax({
        method: 'PUT',
        url: kinveyBooksUrl + '/' + bookData._id,
        headers: kinveyAuthHeaders,
        data: JSON.stringify(bookData),
        success: addBookCommentSuccess,
        error: handleAjaxError
    });

    function addBookCommentSuccess(response) {
        listBooks();
        showInfo('Comment added.');
    }
}

function showCreateBookView(){
    showView('view-create-book');
}

function createBook() {
    const kinveyBooksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/book-library';
    const kinveyAuthHeaders = {
        Authorization: 'Kinvey ' + sessionStorage.getItem('authToken')
    };

    let bookData = {
        title: $('#book-title').val(),
        author: $('#book-author').val(),
        description: $('#book-description').val()
    };

    $.ajax({
        method: 'POST',
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        data: bookData,
        success: createBookSuccess,
        error: handleAjaxError
    });

    function createBookSuccess(){
        listBooks();
        showInfo('Book created successfully.');
    }
}

function logout() {
    sessionStorage.clear();
    showHideMenuLinks();
    showView('view-home');
}

function handleAjaxError(errorMsg) {
    //console.log(response);
    //let errorMsg = JSON.parse(response);
    //console.log(errorMsg);

    if(errorMsg.readyState == 0) {
        errorMsg = 'Cannot connect due to network error.';
    }
    if(errorMsg.responseJSON && errorMsg.responseJSON.description) {
        errorMsg = errorMsg.responseJSON.description;
    }

    showError(errorMsg);
}

$(function () {
    showHideMenuLinks();
    showView('view-home');

    $('#link-home').click(showHomeView);
    $('#link-login').click(showLoginView);
    $('#link-register').click(showRegisterView);
    $('#link-list-books').click(listBooks);
    $('#link-create-book').click(showCreateBookView);
    $('#link-logout').click(logout);

    $('#form-login').submit(function (e) {
        e.preventDefault();
        login();
    });
    $('#form-register').submit(function (e) {
        e.preventDefault();
        register();
    });
    $('#form-create-book').submit(function (e) {
        e.preventDefault();
        createBook();
    });

    $(document).on({
        ajaxStart: function () {
            $('#loading-box').fadeIn();
        },
        ajaxStop: function () {
            $('#loading-box').fadeOut();
        }
    });
});