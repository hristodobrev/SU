let Entity = require('./entity');
let Dog = require('./dog');

class Person extends Entity {
    constructor(name, phrase, dog) {
        super(name);

        if(dog.constructor.name != 'Dog') {
            throw new TypeError('The dog must be of type Dog.');
        }

        this.dog = dog;
        this.phrase = phrase;
    }

    saySomething() {
        return `${super.saySomething()} says: ${this.phrase}${this.dog.name} barks!`;
    }
}

module.exports = Person;