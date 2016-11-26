function attachEvents() {
    let baseUrl = 'https://baas.kinvey.com/';
    let appKey = 'kid_BJ_Ke8hZg';
    let authHeaders = {
        'Authorization': 'Basic ' + btoa('guest:pass')
    };
    $('#getVenues').click(getVenues);

    function getVenues() {
        $.ajax({
            method: 'POST',
            url: baseUrl + `rpc/kid_BJ_Ke8hZg/custom/calendar?query=${$('#venueDate').val()}`,
            headers: authHeaders,
            success: getVenuesSuccess,
            error: handleError
        });

        function getVenuesSuccess(data) {
            $('#venue-info').empty();

            for (let venueId of data) {
                $.ajax({
                    method: 'GET',
                    url: baseUrl + `appdata/kid_BJ_Ke8hZg/venues/${venueId}`,
                    headers: authHeaders,
                    success: getVenueSuccess,
                    error: handleError
                });
            }

            function getVenueSuccess(venue) {
                let venueHtml = $(`<div class="venue" id="${venue._id}">
  <span class="venue-name"><input class="info" type="button" value="More info">${venue.name}</span>
  <div class="venue-details" style="display: none;">
    <table>
      <tr><th>Ticket Price</th><th>Quantity</th><th></th></tr>
      <tr>
        <td class="venue-price">${venue.price} lv</td>
        <td><select class="quantity">
          <option value="1">1</option>
          <option value="2">2</option>
          <option value="3">3</option>
          <option value="4">4</option>
          <option value="5">5</option>
        </select></td>
        <td><input class="purchase" type="button" value="Purchase"></td>
      </tr>
    </table>
    <span class="head">Venue description:</span>
    <p class="description">${venue.description}</p>
    <p class="description">Starting time: ${venue.startingHour}</p>
  </div>
</div>`);
                venueHtml.find('.info').click(function () {
                    $('.venue-details').css('display', 'none');
                    venueHtml.find('.venue-details').css('display', 'block');
                });

                venueHtml.find('.purchase').click(function () {
                    let qty = venueHtml.find('.quantity').val();
                    let html = $(`<span class="head">Confirm purchase</span>
<div class="purchase-info">
  <span>${venue.name}</span>
  <span>${qty} x ${venue.price}</span>
  <span>Total: ${qty * venue.price} lv</span>
  <input type="button" value="Confirm">
</div>`);

                    html.find('input').click(function () {
                        let url = baseUrl + `rpc/kid_BJ_Ke8hZg/custom/purchase?venue=${venue._id}&qty=${qty}`;
                        $.ajax({
                            method: 'POST',
                            url: url,
                            headers: authHeaders,
                            success: function (data) {
                                $('#venue-info').empty();
                                let dataHtml = $(data.html);
                                dataHtml.append('<p>You may print this page as your ticket</p>');
                                $('#venue-info').append(dataHtml);
                            },
                            error: function (error) {
                                console.log(error);
                            }
                        });
                    });

                    $('#venue-info').empty();
                    $('#venue-info').append(html);
                });

                $('#venue-info').append(venueHtml);
            }
        }
    }

    function handleError(error) {
        console.log(error);
    }
}