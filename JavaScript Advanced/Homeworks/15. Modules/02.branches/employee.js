class Employee {
    constructor(name, age, position) {
        if (age.constructor.name != 'Number') {
            throw new TypeError('Age must be number.');
        }

        this.name = name;
        this.age = age;
        this.position = position;
    }

    toString() {
        return `${this.name}, ${this.age} (${this.position})\n`;
    }
}

module.exports = Employee;