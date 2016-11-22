class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        let idReg = /^[0-9]{6}$/;
        if (!idReg.test(clientId)) {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        let emailReg = /^[0-9A-Za-z]+@[A-Za-z\.]+$/;
        if (!emailReg.test(email)) {
            throw new TypeError('Invalid e-mail');
        }

        let nameReg = /^[A-Za-z]+$/;
        if (firstName.length < 3 || firstName.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        }

        if (lastName.length < 3 || lastName.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }

        if (!nameReg.test(firstName)) {
            throw new TypeError('First name must contain only Latin characters');
        }

        if (!nameReg.test(lastName)) {
            throw new TypeError('Last name must contain only Latin characters');
        }
    }
}

let test = new CheckingAccount('247046', 'sample@site.com', 'Ivan', 'Petrov');