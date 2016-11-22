class Turtle {
    constructor(name, age, gender) {
        if (new.target == Turtle) {
            throw new Error('Abstract class cannot be instantiated directly');
        }

        this._name = name;
        this._age = age;
        this._gender = gender;
    }

    get name() {
        return this._name;
    }

    get age() {
        return this._age;
    }

    get gender() {
        return this._gender;
    }

    grow(age) {
        this._age += age;
    }

    toString() {
        let result = `Turtle: ${this.name}\n`;
        result += `Aged - ${this.age}; Gender - ${this.gender}\n`;

        return result;
    }
}

module.exports = Turtle;