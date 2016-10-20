function attachEvents() {
    $('#showTownsButton').on('click', show);
    $('#items li').on('click', select);

    function select() {
        if ($(this).attr('data-selected')) {
            $(this).css('background', '');
            $(this).removeAttr('data-selected');
        } else {
            $(this).css('background', '#ddd');
            $(this).attr('data-selected', 'true');
        }
    }

    function show() {
        $('#selectedTowns').text(
            $('#items li[data-selected="true"]').toArray().map(li => li.textContent)
                .join(', ')
        );
    }
}