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
    $.ajax({
        method: 'POST',
        url: kinveyBaseUrl + 'rpc/' + kinveyAppKey + '/custom/viewcounter',
        headers: getKinveyUserAuthHeaders(),
        data: {
            adTitle: ad.title
        },
        success: detailsSuccess,
        error: handleAjaxError
    });

    function detailsSuccess(views) {
        console.log(views);
        let adHtml = $(`<h1>${ad.title}</h1><br>
        <img src="${ad.img}" alt="Ad Image" width="400">
        <p><strong>Price:</strong> <span>${ad.price}</span></p><br>
        <p><strong>Description:</strong></p>
        <p>${ad.description}</p><br>
        <p><strong>Publisher:</strong> <span>${ad.publisher}</span></p><br>
        <p><strong>Date Published:</strong> ${ad.datePublished}</p>
        <p><strong>Views:</strong> ${views}</p>
`);

        $('#viewDetailsAd').empty();
        $('#viewDetailsAd').append(adHtml);
        showView('viewDetailsAd');
    }
}