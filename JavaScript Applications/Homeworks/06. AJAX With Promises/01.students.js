function attachEvents() {
    let baseUrl = 'https://baas.kinvey.com/appdata/';
    let appKey = 'kid_BJXTsSi-e';
    let appSecret = '447b8e7046f048039d95610c1b039390';
    let authHeaders = {
        'Authorization': 'Basic ' + btoa('guest:guest')
    };

    $('#btnAdd').click(function () {
        let data = {
            'ID': $('#id').val(),
            'FirstName': $('#first-name').val(),
            'LastName': $('#last-name').val(),
            'FacultyNumber': $('#f-num').val(),
            'Grade': $('#grade').val()
        };

        $.ajax({
            method: 'POST',
            url: baseUrl + appKey + '/students',
            data: data,
            headers: authHeaders,
            success: loadData,
            error: showError
        });
    });

    loadData();

    function loadData() {
        $.ajax({
            method: 'GET',
            url: baseUrl + appKey + '/students',
            headers: authHeaders,
            success: function (data) {
                data.sort((a, b) => a.ID - b.ID);

                for (let student of data) {
                    let tr = `<tr>
    <td>${student.ID}</td>
    <td>${student.FirstName}</td>
    <td>${student.LastName}</td>
    <td>${student.FacultyNumber}</td>
    <td>${student.Grade}</td>
</tr>`;
                    $('#results').append(tr);
                }
            },
            error: showError
        });
    }

    function showError(error) {
        let errorDiv = $('<div>')
            .attr('class', 'error')
            .text(`Error: ${error.status} (${error.statusText})`)
            .click(function () {
                errorDiv.fadeOut(function () {
                    errorDiv.clear();
                });
            });

        $(document.body).prepend(errorDiv);
    }
}