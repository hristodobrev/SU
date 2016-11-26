function attachEvents() {
    let baseUrl = 'https://judgetests.firebaseio.com/locations.json';
    let symbols = {
        'Sunny': '&#x2600;',
        'Partly sunny': '&#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;',
        'Degrees': '&#176;'
    };

    $('#submit').click(getWeather);

    function getWeather() {
        $.ajax({
            method: 'GET',
            url: baseUrl,
            success: function (data) {
                let code;
                for (let location of data) {
                    if (location.name == $('#location').val()) {
                        code = location.code;
                    }
                }

                getForecast(code);
            },
            error: function (error) {
                console.log(error);
            }
        });

        function getForecast(code) {
            if (code) {
                let todayUrl = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;
                let daysUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;
                let todayRequest = $.get(todayUrl);
                let daysRequest = $.get(daysUrl);

                Promise.all([todayRequest, daysRequest])
                    .then(function ([todayData, daysData]) {
                        $('#forecast').css('display', 'block');

                        $('#current')
                            .empty()
                            .append(
                                $(`<span class="condition symbol">${symbols[todayData.forecast.condition]}</span>`)
                            )
                            .append(
                                $(`<span class="condition">`)
                                    .append($('<span class="forecast-data">')
                                        .text(todayData.name))
                                    .append($('<span class="forecast-data">')
                                        .html(todayData.forecast.low +
                                            symbols.Degrees +
                                            '/' + todayData.forecast.high +
                                            symbols.Degrees))
                                    .append($('<span class="forecast-data">')
                                        .text(todayData.forecast.condition))
                            );

                        for (let dayData of daysData.forecast) {
                            $('#upcoming')
                                .append(
                                    $('<span class="upcoming">')
                                        .append($('<span class="symbol">')
                                            .html(symbols[dayData.condition])
                                        )
                                        .append($('<span class="forecast-data">')
                                            .html(dayData.low +
                                                symbols.Degrees + '/' +
                                                dayData.high +
                                                symbols.Degrees
                                            )
                                        )
                                        .append($('<span class="forecast-data">')
                                            .html(dayData.condition)
                                        )
                                );
                        }
                    })
                    .catch(function (error) {
                        $('#forecast').css('display', 'block');
                    });
            }
        }
    }
}