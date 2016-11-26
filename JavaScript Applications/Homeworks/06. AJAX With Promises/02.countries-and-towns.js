function attachEvents() {
    let baseUrl = 'https://baas.kinvey.com/appdata/';
    let appKey = 'kid_SynxzgwGx';
    let authHeaders = {
        'Authorization': 'Basic ' + btoa('guest:guest')
    };

    $(document).ajaxSend(function () {
        $('#loading').css('visibility', 'visible');
    });

    $(document).ajaxComplete(function () {
        $('#loading').css('visibility', 'hidden');
    });

    $('#countries').change(loadTowns);
    $('#towns').change(function () {
        $('#edit-town').val($('#towns option:selected').text());
    });

    $('#editCountry').click(editCountry);
    $('#addCountry').click(addCountry);
    $('#delCountry').click(deleteCountry);
    $('#editTown').click(editTown);
    $('#addTown').click(addTown);
    $('#delTown').click(deleteTown);

    loadCountries();

    function loadCountries() {
        $.ajax({
            method: 'GET',
            url: baseUrl + appKey + '/countries',
            headers: authHeaders,
            success: loadCountriesSuccess,
            error: handleError
        });

        function loadCountriesSuccess(data) {
            $('#countries').empty();
            let selected = false;
            for (let country of data) {
                let option = $(`<option value="${country._id}">${country.name}</option>`);
                if (!selected) {
                    option.attr('selected', 'selected');
                    $('#edit-country').val(country.name);
                    selected = true;
                }
                $('#countries').append(option);
            }

            loadTowns();
        }
    }

    function loadTowns() {
        $('#edit-country').val($('#countries option:selected').text());

        $.ajax({
            method: 'GET',
            url: baseUrl + appKey + `/towns?query={"country_id":"${$('#countries').val()}"}`,
            headers: authHeaders,
            success: loadTownsSuccess,
            error: handleError
        });

        function loadTownsSuccess(data) {
            $('#towns').empty();
            $('#edit-town').val('');
            let selected = false;
            for (let town of data) {
                let option = $(`<option value="${town._id}">${town.name}</option>`);
                if (!selected) {
                    option.attr('selected', 'selected');
                    $('#edit-town').val(town.name);
                    selected = true;
                }
                $('#towns').append(option);
            }
        }
    }

    function editCountry() {
        if ($('#edit-country').val() == '') {
            return;
        }

        $.ajax({
            method: 'PUT',
            url: baseUrl + appKey + '/countries/' + $('#countries').val(),
            data: {
                name: $('#edit-country').val()
            },
            headers: authHeaders,
            success: function (data) {
                loadCountries();
            },
            error: handleError
        });
    }

    function addCountry() {
        if ($('#add-country').val() == '') {
            return;
        }

        $.ajax({
            method: 'POST',
            url: baseUrl + appKey + '/countries',
            data: {
                name: $('#add-country').val()
            },
            headers: authHeaders,
            success: function (data) {
                $('#add-country').val('');
                loadCountries();
            },
            error: handleError
        });
    }

    function deleteCountry() {
        $.ajax({
            method: 'DELETE',
            url: baseUrl + appKey + `/towns?query={"country_id":"${$('#countries').val()}"}`,
            headers: authHeaders,
            success: function (data) {
                $.ajax({
                    method: 'DELETE',
                    url: baseUrl + appKey + '/countries/' + $('#countries').val(),
                    headers: authHeaders,
                    success: function (data) {
                        loadCountries();
                    },
                    error: handleError
                });
            },
            error: handleError
        });
    }

    function editTown() {
        if ($('#edit-town').val() == '') {
            return;
        }

        $.ajax({
            method: 'PUT',
            url: baseUrl + appKey + '/towns/' + $('#towns').val(),
            data: {
                name: $('#edit-town').val()
            },
            headers: authHeaders,
            success: function (data) {
                loadTowns();
            },
            error: handleError
        });
    }

    function addTown() {
        if ($('#add-town').val() == '') {
            return;
        }

        $.ajax({
            method: 'POST',
            url: baseUrl + appKey + '/towns',
            data: {
                name: $('#add-town').val(),
                country_id: $('#countries').val()
            },
            headers: authHeaders,
            success: function (data) {
                $('#add-town').val('');
                loadTowns();
            },
            error: handleError
        });
    }

    function deleteTown() {
        $.ajax({
            method: 'DELETE',
            url: baseUrl + appKey + '/towns/' + $('#towns').val(),
            headers: authHeaders,
            success: function (data) {
                loadTowns();
            },
            error: handleError
        });
    }

    function handleError(error) {
        console.log(error);
    }
}