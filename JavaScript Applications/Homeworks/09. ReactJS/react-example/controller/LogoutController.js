class LogoutController {
    static logout() {
        return function() {

            Requester.logout(app.user.token)
            .done(function () {
                app.user = null;
                localStorage.removeItem('authUser');
                app.router.goTo('home', false);
            })
        }
    }
}
