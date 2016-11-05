let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');
let sharedObject = {
    name: null,
    income: null,
    changeName: function (name) {
        if (name.length === 0) {
            return;
        }
        this.name = name;
        let newName = $('#name');
        newName.val(this.name);
    },
    changeIncome: function (income) {
        if (!Number.isInteger(income) || income <= 0) {
            return;
        }
        this.income = income;
        let newIncome = $('#income');
        newIncome.val(this.income);
    },
    updateName: function () {
        let newName = $('#name').val();
        if (newName.length === 0) {
            return;
        }
        this.name = newName;
    },
    updateIncome: function () {
        let newIncome = $('#income').val();
        if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
            return;
        }
        this.income = Number(newIncome);
    }
};

document.body.innerHTML = `<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Shared Object</title>
</head>
<body>
    <div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>
</body>
</html>`;

describe('sharedObject', function () {
    it('with invalid parameters, should not change the income property', function () {
        sharedObject.income = 10;
        sharedObject.changeIncome('pesho');
        expect(sharedObject.income).to.equal(10, 'Incorrect result');
    });

    it('with floating point number, should not change the income property', function () {
        sharedObject.income = 10;
        sharedObject.changeIncome(15.95);
        expect(sharedObject.income).to.equal(10, 'Incorrect result');
    });

    it('with negative number, should change the income property', function () {
        sharedObject.income = 10;
        sharedObject.changeIncome(-15);
        expect(sharedObject.income).to.equal(10, 'Incorrect result');
    });

    it('with negative number, should change the income property', function () {
        sharedObject.income = 10;
        sharedObject.changeIncome(0);
        expect(sharedObject.income).to.equal(10, 'Incorrect result');
    });

    it('with valid parameters, should change the income property', function () {
        sharedObject.income = 10;
        sharedObject.changeIncome(15);
        expect(sharedObject.income).to.equal(15, 'Incorrect result');
    });
});