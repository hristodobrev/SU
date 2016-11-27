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