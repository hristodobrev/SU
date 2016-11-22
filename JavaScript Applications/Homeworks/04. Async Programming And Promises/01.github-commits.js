function loadCommits() {
    let username = $('#username').val();
    let repository = $('#repo').val();
    let url = `https://api.github.com/repos/${username}/${repository}/commits`;

    let xhr = $.ajax({
        method: 'GET',
        url: url
    })
        .then(function (data) {
            $('#commits').empty();
            for (let commit of data) {
                let li = $('<li>').text(
                    `${commit.commit.author.name}: ${commit.commit.message}`
                );

                $('#commits').append(li);
            }
        })
        .catch(function (error) {
            $('#commits').empty();

            let li = $('<li>').text(
                `Error: ${error.status} (${error.statusText})`
            );

            $('#commits').append(li);
        });
}