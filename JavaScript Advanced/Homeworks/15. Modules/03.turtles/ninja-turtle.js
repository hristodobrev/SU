let Turtle = require('./turtle');

class NinjaTurtle extends Turtle {
    constructor(name, age, gender, maskColor, weapon) {
        super(name, age, gender);
        this._maskColor = maskColor;
        this._weapon = weapon;
        this._level = 0;
    }

    grow(age) {
        super.grow(age);
        this._level += age;
    }

    toString() {
        let result = super.toString();
        let subName = this.name.substr(0, 3);
        let line = `${subName} wears a ${this._maskColor} mask, and is an apprentice with the ${this._weapon}.\n`;
        if (this._level >= 25 && this._level < 100) {
            line = `${subName} wears a ${this._maskColor} mask, and is smokin strong with the ${this._weapon}.\n`;
        } else if (this._level >= 100) {
            line = `${subName} wears a ${this._maskColor} mask, and is BEYOND GODLIKE with the ${this._weapon}.\n`;
        }

        return result + line;
    }
}

module.exports = NinjaTurtle;