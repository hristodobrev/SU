class App
{
    constructor(args) {
        this.user = JSON.parse(localStorage.getItem('authUser'));
        this.menuSelector = args.menuSelector;
        this.viewContainerSelector = args.viewContainerSelector;
        this.greetingsSelector = args.greetingsSelector;
        this.router = new Router();
    }

    urlHandler()
    {
        var self = this;
        var onLoadUrl = 'home';

        // Load initial content.
        this.router.goTo(onLoadUrl, true);
        this.router.saveToHistory({
            url: onLoadUrl,
            title: this.router.routes[onLoadUrl].title,
            onload: true
        });

        // Update the page content when the popstate event is called.
        window.addEventListener('popstate', function(event) {

            if(event.state)
                self.router.goTo(event.state.url, true);
            else
                self.router.goTo('/', true);

        });

        // Goes to url
        $(document).on('click', 'a', (e) => {
            e.preventDefault();

            self.router.goTo( $(e.target).attr('href'), false );
        });
    }

    messageHandle() {
        $(document).on({
            ajaxStart: () => {
                $('#boxInfo').text('Loading ...');
            },
            ajaxStop: () => {
                $('#boxInfo').text('');
                this.navbarHandle(this.menuSelector);
                this.greetings(this.greetingsSelector);
            },
            ajaxError: () => {
                $('#boxError').text('An error occured.').show();
                setTimeout(function() {
                    $('#boxError').fadeOut();
                }, 2 * 1000);
            }
        });
    }

    navbarHandle(menuSelector) {
        if (app.user != null) {
            $(menuSelector).html(`
                <li><a class="link" href="home">Home</a></li>
                <li><a class="link" href="create-ad">Create Ad</a></li>
                <li><a class="link" href="ads">Ads</a></li>
                <li><a class="link" href="logout">Logout</a></li>
                `);
            }
            else
            {
                $(menuSelector).html(`
                    <li><a class="link" href="home">Home</a></li>
                    <li><a class="link" href="login">Login</a></li>
                    <li><a class="link" href="register">Register</a></li>
                    `);
                }
            }
            greetings(greetingsSelector) {
                if (app.user != null) {
                    $(greetingsSelector).html(`<li><a id="greeting">Welcome, ${this.user.username}</a></li>`);
                }
                else
                $(greetingsSelector).html(``);
            }

            start() {
                console.log('Application is loading...');

                // Init in the order they load on the page
                this.navbarHandle(this.menuSelector);
                this.greetings(this.greetingsSelector);
                this.messageHandle();
                this.urlHandler();
            }
        }
