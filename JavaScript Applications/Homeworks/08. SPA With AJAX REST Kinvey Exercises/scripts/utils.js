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