function solve() {
    let baseUrl = 'https://judgetests.firebaseio.com/schedule/';
    let currentStopId = 'depot';
    let nextStopId = 'depot';

    function depart() {
        let req = {
            method: 'GET',
            url: baseUrl + nextStopId + '.json',
            success: function (data) {
                currentStopId = nextStopId;
                nextStopId = data.next;
                $('#info').html($('<span class="info">').text(`Next stop ${data.name}`));
                $('#depart').attr('disabled', true);
                $('#arrive').removeAttr('disabled');
            },
            error: function () {
                $('#info').html($('<span class="info">').text(`Error`));
                $('#arrive').attr('disabled', true);
                $('#depart').attr('disabled', true);
            }
        };

        $.ajax(req);
    }

    function arrive() {
        let req = {
            method: 'GET',
            url: baseUrl + currentStopId + '.json',
            success: function (data) {
                $('#info').html($('<span class="info">').text(`Arriving at ${data.name}`));
                $('#arrive').attr('disabled', true);
                $('#depart').removeAttr('disabled');
            },
            error: function () {
                $('#info').html($('<span class="info">').text(`Error`));
                $('#arrive').attr('disabled', true);
                $('#depart').attr('disabled', true);
            }
        };

        $.ajax(req);
    }

    return {
        depart,
        arrive
    };
}
let result = solve();