function people() {
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

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} is working on a simple task.`);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} is working on a complicated task.`);
            this.tasks.push(`${this.name} is taking time off work.`);
            this.tasks.push(`${this.name} is supervising junior workers.`);
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} scheduled a meeting.`);
            this.tasks.push(`${this.name} is preparing a quarterly report.`);
            this.dividend = 0;
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}

let result = people();
let Manager = result.Manager;
let Senior = result.Senior;
let Junior = result.Junior;

var guy1 = new result.Junior('Peter', 27);
guy1.salary = 1200;
guy1.dividend = 100;
guy1.collectSalary();

let manager = new Manager('Hristo', 19);
manager.salary = 10000;
manager.dividend = 1930;
manager.work();
manager.collectSalary();

let senior = new Senior('Pesho', 21);
senior.salary = 2000;
senior.work();
senior.collectSalary();