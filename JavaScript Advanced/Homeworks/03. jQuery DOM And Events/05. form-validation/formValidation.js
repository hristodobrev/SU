function validate() {
    $('#submit').on('click', submit);
    let company = $('#company');
    company.on('click', function () {
        if (company[0].checked){
            $('#companyInfo').css('display', 'block');
        } else {
            $('#companyInfo').css('display', 'none');
        }
    });

    function submit(event) {
        event.preventDefault();
        let notValid = 0;

        let username = $('#username');
        let email = $('#email');
        let password = $('#password');
        let confirmPassword = $('#confirm-password');


        let usernameRegex = /^[A-Za-z0-9]{3,20}$/;
        if (!usernameRegex.test(username.val())) {
            username.css('border-color', 'red');
            notValid++;
        }

        let passwordRegex = /^[A-Za-z0-9_]{5,15}$/;
        if (!passwordRegex.test(password.val())) {
            password.css('border-color', 'red');
            notValid++;
        }

        if (!passwordRegex.test(confirmPassword.val()) || confirmPassword.val() !== password.val()) {
            confirmPassword.css('border-color', 'red');
            password.css('border-color', 'red');
            notValid++;
        }

        let emailRegex = /^(.*)@(.*)\.(.*)$/;
        if (!emailRegex.test(email.val())){
            email.css('border-color', 'red');
            notValid++;
        }

        if($('#company')[0].checked){
            let companyNumber = $('#companyNumber');
            let num = Number(companyNumber.val());

            if(num < 1000 || num > 9999){
                companyNumber.css('border-color', 'red');
                notValid++;
            }
        }

        if(notValid == 0){
            $('#valid').css('display', 'block');
        } else {
            $('#valid').css('display', 'none');
        }
    }
}