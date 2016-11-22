function getInfo() {
    $('#buses').empty();
    let baseUrl = 'https://judgetests.firebaseio.com/businfo/';

    $.get(baseUrl + $('#stopId').val() + '.json')
        .then(function (data) {
            let name = data.name;
            $('#stopName').text(name);
            let buses = data.buses;
            let keys = Object.keys(buses);
            for (let key of keys) {
                $('#buses').append(
                    $('<li>').text(`Bus ${key} arrives in ${buses[key]} minutes`)
                );
            }
        })
        .catch(function () {
            $('#stopName').text('Error');
        });
}