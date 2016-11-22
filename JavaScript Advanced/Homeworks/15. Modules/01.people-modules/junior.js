let Employee = require('./employee');

class Junior extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks.push(`${this.name} is working on a simple task.`);
    }
}

module.exports = Junior;