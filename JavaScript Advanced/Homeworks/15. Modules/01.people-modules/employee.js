class Employee {
    constructor(name, age) {
        if (new.target === Employee) {
            throw new TypeError('Cannot instatiate Employee directly.')
        }
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    work() {
        let task = this.tasks.shift();
        console.log(task);
        this.tasks.push(task);
    }

    collectSalary() {
        if (this.dividend != null && this.constructor.name === 'Manager') {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        } else {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }
}

module.exports = Employee;