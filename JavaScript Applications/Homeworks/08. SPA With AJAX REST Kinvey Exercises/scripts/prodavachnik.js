function startApp() {
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_HJtqzovGl";
    const kinveyAppSecret =
        "7647195288d84698a58903853ba27548";
    const kinveyAppAuthHeaders = {
        'Authorization': "Basic " +
        btoa(kinveyAppKey + ":" + kinveyAppSecret),
    };

    $(document).on({
        ajaxStart: function () {
            $('#loadingBox').fadeIn();
        },
        ajaxStop: function () {
            $('#loadingBox').fadeOut();
        }
    });

    $('#infoBox, #errorBox').click(function () {
        $(this).fadeOut();
    });

    $('#linkHome').click(showHomeView);
    $('#linkLogin').click(showLoginView);
    $('#linkRegister').click(showRegisterView);
    $('#linkListAds').click(listAds);
    $('#linkCreateAd').click(showCreateAdView);
    $('#linkLogout').click(logout);

    $('#buttonLoginUser').click(loginUser);
    $('#buttonRegisterUser').click(registerUser);
    $('#buttonCreateAd').click(createAd);
    $('#buttonEditAd').click(editAd);

    showHideMenuLinks();
    showHomeView();

    function showHideMenuLinks() {
        if (sessionStorage.getItem('authToken')) {
            $('#linkHome').show();
            $('#linkLogin').hide();
            $('#linkRegister').hide();
            $('#linkListAds').show();
            $('#linkCreateAd').show();
            $('#linkLogout').show();
        } else {
            $('#linkHome').show();
            $('#linkLogin').show();
            $('#linkRegister').show();
            $('#linkListAds').hide();
            $('#linkCreateAd').hide();
            $('#linkLogout').hide();
        }
    }

    function showView(viewName) {
        $('section').hide();
        $(`#${viewName}`).fadeIn();
    }

    function showHomeView() {
        showView('viewHome');
    }

    function showLoginView() {
        showView('viewLogin');
        $('#formLogin').trigger('reset');
    }

    function showRegisterView() {
        showView('viewRegister');
        $('#formRegister').trigger('reset');
    }

    function showListAdsView() {
        showView('viewAds');
    }

    function showCreateAdView() {
        showView('viewCreateAd');
        $('#loggedInUser').text('');
        $('#formCreateAd').trigger('reset');
    }

    function loginUser() {
        let data = {
            username: $('#formLogin input[name=username]').val(),
            password: $('#formLogin input[name=passwd]').val()
        };

        $.ajax({
            method: 'POST',
            url: kinveyBaseUrl + 'user/' + kinveyAppKey + '/login',
            headers: kinveyAppAuthHeaders,
            data: data,
            success: loginSuccess,
            error: handleAjaxError
        });

        function loginSuccess(userInfo) {
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            listAds();
            showInfo('Logged in successful');
        }
    }

    function registerUser() {
        let data = {
            username: $('#formRegister input[name=username]').val(),
            password: $('#formRegister input[name=passwd]').val()
        };

        console.log(data);

        $.ajax({
            method: 'POST',
            url: kinveyBaseUrl + 'user/' + kinveyAppKey,
            headers: kinveyAppAuthHeaders,
            data: data,
            success: registerSuccess,
            error: handleAjaxError
        });

        function registerSuccess(userInfo) {
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            listAds();
            showInfo('Registered successful');
        }
    }

    function logout() {
        sessionStorage.clear();
        showHideMenuLinks();
        showHomeView();
        showInfo('Logout Successful');
        $('#loggedInUser').text('');
    }

    function saveAuthInSession(userInfo) {
        sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
        sessionStorage.setItem('username', userInfo.username);
        sessionStorage.setItem('userId', userInfo._id);
        $('#loggedInUser').text('Welcome, ' + userInfo.username + '!').show();
    }

    function listAds() {
        showListAdsView();

        $.ajax({
            method: 'GET',
            url: kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/ads',
            headers: getKinveyUserAuthHeaders(),
            success: listAdsSuccess,
            error: handleAjaxError
        });

        function listAdsSuccess(ads) {
            $('#ads').empty();

            if (ads.length > 0) {
                let table = $(`<table>
    <tr>
        <th>Title</th>
        <th>Publisher</th>
        <th>Description</th>
        <th>Price</th>
        <th>Date Published</th>
        <th>Actions</th>
    </tr>
</table>`);

                for (let ad of ads) {
                    let adHtml = $(`<tr>
                    <td>${ad.title}</td>
                    <td>${ad.publisher}</td>
                    <td>${ad.description}</td>
                    <td>${ad.price}</td>
                    <td>${ad.datePublished}</td>
                </tr>`);

                    let delLink = $('<a href="#">[Delete]</a>').click(function () {
                        deleteAd(ad._id);
                    });
                    let editLink = $('<a href="#">[Edit]</a>').click(function () {
                        editAd(ad._id);
                    });

                    adHtml.append($('<td>').append(delLink).append(editLink));

                    table.append(adHtml);
                }

                $('#ads').append(table);
            } else {
                $('#ads').append($('<p>No Advertisments aviable.</p>'));
            }
        }
    }

    function createAd() {
        let data = {
            title: $('#formCreateAd input[name=title]').val(),
            description: $('#formCreateAd textarea[name=description]').val(),
            publisher: sessionStorage.getItem('username'),
            datePublished: $('#formCreateAd input[name=datePublished]').val(),
            price: $('#formCreateAd input[name=price]').val()
        };

        $.ajax({
            method: 'POST',
            url: kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/ads',
            headers: getKinveyUserAuthHeaders(),
            data: data,
            success: createAdSuccess,
            error: handleAjaxError
        });

        function createAdSuccess(adData) {
            listAds();
            showInfo('Ad created successful')
        }
    }

    function editAd() {

    }

    function deleteAd(id) {
        $.ajax({
            method: 'DELETE',
            url: kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/ads/' + id,
            headers: getKinveyUserAuthHeaders(),
            success: deleteAdSuccess,
            error: handleAjaxError
        });

        function deleteAdSuccess() {
            listAds();
            showInfo('Ad deleted succesful');
        }
    }

    function getKinveyUserAuthHeaders() {
        return {
            'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
        };
    }

    function showError(msg) {
        $('#errorBox').text(msg);
        $('#errorBox').fadeIn();
    }

    function showInfo(msg) {
        $('#infoBox').text(msg);
        $('#infoBox').fadeIn();
    }

    function handleAjaxError(error) {
        showError('Error: ' + error.responseJSON.description);
    }
}