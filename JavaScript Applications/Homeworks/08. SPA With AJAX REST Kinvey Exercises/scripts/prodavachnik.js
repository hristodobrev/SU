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
            $('#loggedInUser').show();
        } else {
            $('#linkHome').show();
            $('#linkLogin').show();
            $('#linkRegister').show();
            $('#linkListAds').hide();
            $('#linkCreateAd').hide();
            $('#linkLogout').hide();
            $('#loggedInUser').hide();
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
        $('#formCreateAd').trigger('reset');
    }

    function showEditAdView() {
        showView('viewEditAd');
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
                    <td>${ad.title}<br>
                    <img src="${ad.img}" alt="Ad Image" width="200">
                    </td>
                    <td>${ad.publisher}</td>
                    <td>${ad.description}</td>
                    <td>${ad.price}</td>
                    <td>${ad.datePublished}</td>
                </tr>`);

                    let actionsTd = $('<td>');

                    let viewLink = $('<a href="#">[View]</a>').click(function () {
                        detailsAd(ad);
                    });
                    actionsTd.append(viewLink);

                    if (ad._acl.creator == sessionStorage.getItem('userId')) {
                        let delLink = $('<a href="#">[Delete]</a>').click(function () {
                            deleteAd(ad._id);
                        });
                        let editLink = $('<a href="#">[Edit]</a>').click(function () {
                            loadAdForEdit(ad);
                        });

                        actionsTd.append(delLink).append(editLink);
                    }

                    adHtml.append(actionsTd);
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
            price: $('#formCreateAd input[name=price]').val(),
            img: $('#formCreateAd input[name=img]').val()
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
        let id = $('#formEditAd input[name=id]').val();

        let data = {
            title: $('#formEditAd input[name=title]').val(),
            description: $('#formEditAd textarea[name=description]').val(),
            publisher: sessionStorage.getItem('username'),
            datePublished: $('#formEditAd input[name=datePublished]').val(),
            price: $('#formEditAd input[name=price]').val(),
            img: $('#formEditAd input[name=img]').val()
        };

        $.ajax({
            method: 'PUT',
            url: kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/ads/' + id,
            headers: getKinveyUserAuthHeaders(),
            data: data,
            success: editAdSuccess,
            error: handleAjaxError
        });

        function editAdSuccess(adData) {
            listAds();
            showInfo('Ad edited successful')
        }
    }

    function loadAdForEdit(ad) {
        $('#formEditAd input[name=id]').val(ad._id);
        $('#formEditAd input[name=publisher]').val(ad.publisher);
        $('#formEditAd input[name=title]').val(ad.title);
        $('#formEditAd textarea[name=description]').val(ad.description);
        $('#formEditAd input[name=datePublished]').val(ad.datePublished);
        $('#formEditAd input[name=price]').val(ad.price);
        $('#formEditAd input[name=img]').val(ad.img);
        showEditAdView();
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

    function detailsAd(ad) {
        let adHtml = $(`<h1>${ad.title}</h1><br>
        <img src="${ad.img}" alt="Ad Image" width="400">
        <p><strong>Price:</strong> <span>${ad.price}</span></p><br>
        <p><strong>Description:</strong></p>
        <p>${ad.description}</p><br>
        <p><strong>Publisher:</strong> <span>${ad.publisher}</span></p><br>
        <p><strong>Date Published:</strong> ${ad.datePublished}</p>`);

        $('#viewDetailsAd').empty();
        $('#viewDetailsAd').append(adHtml);
        showView('viewDetailsAd');
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
        setTimeout(function () {
            $('#infoBox').fadeOut();
        }, 2000);
    }

    function handleAjaxError(error) {
        showError('Error: ' + error.responseJSON.description);
    }
}