function extendPrototype(Class) {
    Class.prototype.species = 'Human';
    Class.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}

class Test {
    constructor(name) {
        this.name = name;
    }
}

let t = new Test('test');

extendPrototype(Test);

console.log(t.toSpeciesString());