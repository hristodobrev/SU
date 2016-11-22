let Entity = require('./entity');

class Dog extends Entity {
    constructor(name) {
        super(name);
    }

    saySomething() {
        return `${super.saySomething()} barks!`;
    }
}

module.exports = Dog;