userModel = {
    data: {
        username: 'unnamed',
        email: 'no-email'
    },
    setData: function (d) {
        this.data.username = d.username;
        this.data.email = d.email;
    },
    getData: function () {
        return this.data;
    }
}

userView = {
    render: function(model) {
        document.querySelector('#name').innerText = 'Username: ' + model.data.username;
        document.querySelector('#email').innerText = 'E-mail: ' + model.data.email;
    }
}

formController = {
    model: userModel,
    view: userView,
    handler: function() {
        this.view.render(this.model);
    }
}

function handleClick() {
    var qs = (function(a) {
        if (a == "") return {};
        var b = {};
        for (var i = 0; i < a.length; ++i)
        {
            var p=a[i].split('=', 2);
            if (p.length == 1)
                b[p[0]] = "";
            else
                b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
        }
        return b;
    })(window.location.search.substr(1).split('&'));
    window.location.search = 'logged.html';
    console.log(window.location);
    console.log(qs);
    //formController.handler();
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}