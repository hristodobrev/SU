attachEvents();

function attachEvents() {
    $('#submit').on('click', sendMessage);
    // $('#refresh').on('click', refresh);

    let baseUrl = 'https://messenger-b6a81.firebaseio.com/';

    refresh();

    function sendMessage() {
        let data = {
            author: $('#author').val(),
            content: $('#content').val(),
            timestamp: new Date().getTime()
        };

        let req = {
            method: 'POST',
            url: baseUrl + '.json',
            data: JSON.stringify(data),
            success: function (data) {
                $('#author').val('');
                $('#content').val('');
                refresh();
            },
            error: function (error) {
                $('#messages').text('Error');
            }
        };
        $.ajax(req);
    }

    function refresh() {
        let req = {
            method: 'GET',
            url: baseUrl + '.json',
            success: function (data) {
                let keys = Object.keys(data);
                keys.sort((a, b) => {
                    return data[a].timestamp - data[b].timestamp;
                });

                let result = '';
                for (let key of keys) {
                    result += `${data[key].author}: ${data[key].content}\n`;
                }
                $('#messages').text(result);
            },
            error: function (error) {
                $('#messages').text('Error');
            }
        };

        $.ajax(req);
    }
}