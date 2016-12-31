/*
* Login Controller
*/
class LoginController
{
    static renderView() {
        var self = this;
        return function() {
            var loginView = new LoginView();
            var view = $(loginView.html);

            view.find('form').submit(self.submit);

            $('body').hide().fadeIn('slow');
            $(app.viewContainerSelector).html(view);
        }
    };

    static submit(e)
    {
        e.preventDefault();

        Requester.post('user', 'login', {
            'username': $(this).find('input[name="username"]').val(),
            'password': $(this).find('input[name="password"]').val()
        })
        .done(loginSuccess)
        .fail(function() {
            document.getElementById('login-form').reset();
        });

        function loginSuccess(data) {

            localStorage.setItem('authUser', JSON.stringify({ username: data.username, token: data._kmd.authtoken }));
            app.user = {
                username: data.username,
                token: data._kmd.authtoken
            };
            document.getElementById('login-form').reset();
            app.router.goTo('home', false); // Redirect to home
        }
    }
}
