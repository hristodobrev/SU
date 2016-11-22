let Employee = require('./employee');

class Manager extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks.push(`${this.name} scheduled a meeting.`);
        this.tasks.push(`${this.name} is preparing a quarterly report.`);
        this.dividend = 0;
    }
}

module.exports = Manager;