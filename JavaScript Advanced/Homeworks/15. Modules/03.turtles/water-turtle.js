let Turtle = require('./turtle');

class WaterTurtle extends Turtle {
    constructor(name, age, gender, waterPool) {
        super(name, age, gender);
        this._waterPool = waterPool;
    }

    get currentWaterPool() {
        return this._waterPool;
    }

    travel(waterPool) {
        super.grow(5);
        this._waterPool = waterPool;
    }

    toString() {
        let result = super.toString();
        result += `Currently inhabiting ${this.currentWaterPool}\n`;

        return result;
    }
}

module.exports = WaterTurtle;