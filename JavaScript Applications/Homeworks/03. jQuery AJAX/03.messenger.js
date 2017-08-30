attachEvents();

function attachEvents() {
    $('#submit').on('click', sendMessage);
    $('#content').on('keyup', contentKeyup);
    // $('#refresh').on('click', refresh);

    let baseUrl = 'https://messenger-b6a81.firebaseio.com/';

    getMessages();

    function contentKeyup(e) {
        if (e.keyCode == 13) {
            sendMessage();
        }
    }

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
                $('#content').val('');
                getMessages();
            },
            error: function (error) {
                $('#messages').text('Error');
            }
        };
        $.ajax(req);
    }

    function getMessages() {
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
                    var date = new Date(data[key].timestamp).toLocaleString();
                    var li = $('<li>');
                    if (data[key].author == $('#author').val()) {
                        li.addClass('me');
                    }

                    li.html(`<strong>${data[key].author}</strong>: ${data[key].content} <span class="time">${date}</span>`);
                    
                    $('#messages').append(li);
                }
                $('#messages').scrollTop($('#messages')[0].scrollHeight);
                // $('#messages').text(result);
            },
            error: function (error) {
                $('#messages').text('Error');
            }
        };

        $.ajax(req);
    }
}