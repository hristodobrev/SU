function attachEvents() {
    $('#btnAdd').on('click', function () {
        let text = $('#newItem').val();
        if(text != '') {
            let option = $(`<option>${text}</option>`);
            $('#towns').append(option);
            $('#newItem').val('');
        }
    });

    $('#btnDelete').on('click', function () {
        let options = $('#towns option');
        for (let option of options) {
            if($(option)[0].selected){
                $(option).remove();
            }
        }
    });
}