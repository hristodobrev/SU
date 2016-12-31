/*
* Register Controller
*/
class RegisterController
{
    static renderView() {

        return function() {

            var registerView = new RegisterView();
            var view = $(registerView.html);
            /* Submit Form */
            view.find('form').submit(function(e) {

            });

            $('body').hide().fadeIn('slow');
            $(app.viewContainerSelector).html(view);
        }
    };

    static submit(e) {
        e.preventDefault();

        KinveyRequester.post('user', '', {
            'username': $(this).find('input[name="username"]').val(),
            'password': $(this).find('input[name="password"]').val()
        })
        .done(function (data) {
            document.getElementById('register-form').reset();
            app.router.goTo('login', false);
        })
        .fail(function (data) {
            document.getElementById('register-form').reset();
        })
    }
}
