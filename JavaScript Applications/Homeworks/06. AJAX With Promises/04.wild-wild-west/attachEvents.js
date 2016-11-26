function attachEvents() {
    let baseUrl = 'https://baas.kinvey.com/appdata/kid_rJp-cNwMg/players/';
    let authHeaders = {
        'Authorization': 'Basic ' + btoa('guest:guest')
    };

    $('#addPlayer').click(addPlayer);
    loadPlayers();

    function addPlayer() {
        $.ajax({
            method: 'POST',
            url: baseUrl,
            headers: authHeaders,
            data: {
                name: $('#addName').val(),
                money: 500,
                bullets: 6
            },
            success: function (data) {
                $('#addName').val('');
                loadPlayers();
            },
            error: handleError
        });
    }

    function deletePlayer(id) {
        $.ajax({
            method: 'DELETE',
            url: baseUrl + id,
            headers: authHeaders,
            success: function (data) {
                loadPlayers();
            },
            error: handleError
        });
    }

    function loadPlayers() {
        $.ajax({
            method: 'GET',
            url: baseUrl,
            headers: authHeaders,
            success: displayPlayers,
            error: handleError
        });

        function displayPlayers(players) {
            $('#players').empty();

            for (let player of players) {
                let playerDiv = $(`<div class="player" data-id="${player._id}">
            <div class="row">
                <label>Name:</label>
                <label class="name">${player.name}</label>
            </div>
            <div class="row">
                <label>Money:</label>
                <label class="money">${player.money}</label>
            </div>
            <div class="row">
                <label>Bullets:</label>
                <label class="bullets">${player.bullets}</label>
            </div>
            <button class="play">Play</button>
            <button class="delete">Delete</button>
        </div>`);

                playerDiv.find('.play').click(function () {
                    $('#save').attr('data-id', player._id);
                    $('canvas').css('display', '');
                    $('#save').css('display', '');
                    $('#reload').css('display', '');

                    let pl = {
                        name: player.name,
                        money: Number(player.money),
                        bullets: Number(player.bullets)
                    };

                    loadCanvas(pl);

                    $('#reload').click(function () {
                        pl.money -= 60;
                        pl.bullets = 6;
                    });

                    $('#save').click(function () {
                        $.ajax({
                            method: 'PUT',
                            url: baseUrl + player._id,
                            headers: authHeaders,
                            data: pl,
                            success: function (data) {
                                loadPlayers();
                                $('canvas').css('display', 'none');
                                $('#save').css('display', 'none');
                                $('#reload').css('display', 'none');
                                clearInterval(document.getElementById("canvas").intervalId);
                            },
                            error: handleError
                        });
                    });
                });
                playerDiv.find('.delete').click(function () {
                    deletePlayer(player._id);
                });

                $('#players').append(playerDiv);
            }

        }
    }

    function handleError(error) {
        console.log(`Error: ${error.statusCode}: (${error.statusText})`);
    }
}