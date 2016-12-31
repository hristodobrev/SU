class Router
{
    constructor() {

        this.history = window.history;
        this.guardUrl = 'home';
        this.routes = {
            '/': {
                title: 'Home Page',
                get: HomeController.renderView(),
                auth: false
            },
            'home': {
                title: 'Home Page',
                get: HomeController.renderView(),
                auth: false
            },
            'login': {
                title: 'Login Page',
                get: LoginController.renderView(),
                auth: false
            },
            'register': {
                title: 'Register Page',
                get: RegisterController.renderView(),
                auth: false
            },
            'ads' : {
                title: 'Ad List',
                get: AdController.renderView(),
                auth: true
            },
            'ad?id' : {
                title: 'Single Ad Title',
                get: AdController.renderSingleView(),
                auth: true
            },
            'logout': LogoutController.logout(),
        };
    }

    saveToHistory(obj) {

        if(typeof obj.onload !== 'undefined' && obj.onload == true)
            this.history.replaceState({
                title: obj.title,
                url: obj.url
            }, obj.title, obj.url );
        else
            this.history.pushState({
                title: obj.title,
                url: obj.url
            }, obj.title, obj.url );
    }

    guard(url, callBackFunc) {

        if(this.routes[url].auth == true) // If url requires authentication
            if(app.user) // If user is logged in
                callBackFunc(); // Go
            else
                this.routes[this.guardUrl].get(); // otherwise go to the root url
        else // If the url does not require authentication
            if(app.user) // If the user is logged in
                // if url is one of the following go back to root url
                if(url == 'login' || url == 'register')
                    this.routes[this.guardUrl].get();
                else
                    callBackFunc(); // Go
            else
                callBackFunc();
    }

    goTo(url, popstate) {

        // Verify if it's external link
        if (url.match(/(http:\/\/|https:\/\/)/gm)) {
            window.location = url
            return;
        }

        // Url is internal
        var execute;
        var parameters = this.params(url);

        if(Object.keys(parameters).length == 0)
        {
            if(url == 'logout')
                execute = this.routes[url]();
            else
            {
                execute = this.routes[url].get;
                this.guard(url, () => {

                    execute();
                    console.log(popstate)
                    if(popstate == false)
                        this.saveToHistory({
                            url: url,
                            title: this.routes[url].title
                        });
                });
            }
        }
        else {

            var root = url.split('?')[0];
            var pseudoUrl = '';
            var c = 0;
            for(var p in parameters)
            {
                if(c==0) p = '?' + p;
                else p = '&' + p;
                pseudoUrl += p;
                c++;
            }
            pseudoUrl = root + pseudoUrl;
            execute = this.routes[pseudoUrl].get;

            this.guard(pseudoUrl, () => {
                execute(parameters);
                if(popstate == false)
                    this.saveToHistory({
                        url: url,
                        title: this.routes[pseudoUrl].title
                    });
            });
        }
    }

    params(url) {
        var parms = {}, pieces, parts, i;
        var hash = url.lastIndexOf("#");
        if (hash !== -1) {
            // isolate just the hash value
            url = url.slice(hash + 1);
        }
        var question = url.indexOf("?");
        if (question !== -1) {
            url = url.slice(question + 1);
            pieces = url.split("&");
            for (i = 0; i < pieces.length; i++) {
                parts = pieces[i].split("=");
                if (parts.length < 2) {
                    parts.push("");
                }
                parms[decodeURIComponent(parts[0])] = decodeURIComponent(parts[1]);
            }
        }
        return parms;
    }
}
