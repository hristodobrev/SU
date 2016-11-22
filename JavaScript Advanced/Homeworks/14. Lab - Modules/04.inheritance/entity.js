class Entity {
    constructor(name) {
        if (new.target == Entity) {
            throw new Error('Cannot instantiate abstract class directly.');
        }

        this.name = name;
    }

    saySomething() {
        return this.name;
    }
}

module.exports = Entity;