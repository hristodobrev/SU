var userView = {
    username: document.getElementById('name'),
    email: document.getElementById('email'),
    render: function(model) {
        this.username.innerText = 'Username: ' + model.username;
        this.email.innerText = 'E-mail: ' + model.email;
    }
};