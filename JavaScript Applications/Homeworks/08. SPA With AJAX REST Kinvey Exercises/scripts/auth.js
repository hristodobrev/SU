const kinveyBaseUrl = "https://baas.kinvey.com/";
const kinveyAppKey = "kid_HJtqzovGl";
const kinveyAppSecret =
    "7647195288d84698a58903853ba27548";
const kinveyAppAuthHeaders = {
    'Authorization': "Basic " +
    btoa(kinveyAppKey + ":" + kinveyAppSecret),
};

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

function getKinveyUserAuthHeaders() {
    return {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    };
}