class Branch {
    constructor(branchId, branchName, companyName) {
        if (branchId.constructor.name != 'Number') {
            throw new TypeError('Id must be number.');
        }

        this._branchId = branchId;
        this._branchName = branchName;
        this._companyName = companyName;
        this._employees = [];
    }

    get employees() {
        return this._employees;
    }

    hire(employee) {
        if (employee.constructor.name != 'Employee') {
            throw new TypeError('Cannot add object which is not Employee');
        }

        this._employees.push(employee);
    }

    toString() {
        let result = `@ ${this._companyName}, ${this._branchName}, ${this._branchId}\n`;
        result += 'Employed:\n';
        if (this._employees.length == 0) {
            result += 'None...\n';
        } else {
            for (let emp of this._employees) {
                result += `** ${emp.toString()}\n`;
            }
        }

        return result;
    }
}

module.exports = Branch;