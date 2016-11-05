let createCalculator = require('../04.add-subtract').createCalculator;
let expect = require('chai').expect;

describe("createCalculator tests", function() {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    });

    it("should return 5 after {add 3; add 2}", function() {
        calc.add(3); calc.add(2); let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("should return 5 after {add 3; add 12; subtract 10}", function() {
        calc.add(3); calc.add(12); calc.subtract(10); let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("should return -7 after {subtract 3; subtract 4}", function() {
        calc.subtract(3); calc.subtract(4); let value = calc.get();
        expect(value).to.be.equal(-7);
    });
    it("should return 20 after {subtract '20'; subtract '-40'}", function() {
        calc.subtract(20); calc.subtract(-40); let value = calc.get();
        expect(value).to.be.equal(20);
    });
    it("should return NaN after {subtract 'Pesho'; add 'Gosho'}", function() {
        calc.subtract('Pesho'); calc.add('Gosho'); let value = calc.get();
        expect(value.toString()).to.be.equal('NaN');
    });
});