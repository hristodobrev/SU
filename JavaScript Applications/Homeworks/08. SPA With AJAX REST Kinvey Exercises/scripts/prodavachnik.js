function startApp() {

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
}