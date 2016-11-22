let Turtle = require('./turtle');

class EvkodianTurtle extends Turtle {
    constructor(name, age, gender, evkodiumValue) {
        super(name, age, gender);
        this._evkodiumValue = evkodiumValue;
    }

    get evkodium() {
        let density = this.age * 2;
        if(this.gender == 'male') {
            density += this.age;
        }

        return {
            value: this._evkodiumValue,
            density: density
        };
    }

    toString() {
        let result = super.toString();
        let evk = this.evkodium.value * this.evkodium.density;
        result += `Evkodium: ${evk}\n`;

        return result;
    }
}

module.exports = EvkodianTurtle;