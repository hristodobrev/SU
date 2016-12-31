/*
 * HomeController
 */
class HomeController
{
    static renderView() {

        return function() {

            var homeView = new HomePageView();

            $('body').hide().fadeIn('slow');
            $(app.viewContainerSelector).html( $(homeView.html) );
        }
    };
}
