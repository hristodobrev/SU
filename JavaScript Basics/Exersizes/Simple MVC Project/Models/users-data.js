var userModel = {
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
};