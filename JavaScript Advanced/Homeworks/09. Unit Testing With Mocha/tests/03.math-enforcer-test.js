let mathEnforcer = require('../03.math-enforcer').mathEnforcer;
let expect = require('chai').expect;

describe('mathEnforcer', function () {
    describe('mathEnforcer.addFive()', function () {
        it('should return undefinded for incorrect argument', function () {
            expect(mathEnforcer.addFive('5')).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.addFive('Penka')).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.addFive([5])).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.addFive([5, 10, 20])).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.addFive({a: 5})).to.equal(undefined, 'Incorrect result');
        });
        it('should return num + 5 for number argument', function () {
            expect(mathEnforcer.addFive(5)).to.equal(10, 'Incorrect result');
            expect(mathEnforcer.addFive(0)).to.equal(5, 'Incorrect result');
            expect(mathEnforcer.addFive(-10)).to.equal(-5, 'Incorrect result');
            expect(mathEnforcer.addFive(3.14)).closeTo(8.14, 0.01, 'Incorrect result');
        });
    });
    describe('mathEnforcer.subtractTen()', function () {
        it('should return undefinded for incorrect argument', function () {
            expect(mathEnforcer.subtractTen('5')).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.subtractTen('Penka')).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.subtractTen([5])).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.subtractTen([5, 10, 20])).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.subtractTen({a: 5})).to.equal(undefined, 'Incorrect result');
        });
        it('should return num - 10 for number argument', function () {
            expect(mathEnforcer.subtractTen(5)).to.equal(-5, 'Incorrect result');
            expect(mathEnforcer.subtractTen(0)).to.equal(-10, 'Incorrect result');
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20, 'Incorrect result');
            expect(mathEnforcer.subtractTen(3.14)).closeTo(-6.86, 0.01, 'Incorrect result');
        });
    });
    describe('mathEnforcer.sum()', function () {
        it('should return undefinded for incorrect argument', function () {
            expect(mathEnforcer.sum(10, '5')).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.sum('Penka', 54)).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.sum([5], 120)).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.sum(43, [5, 10, 20])).to.equal(undefined, 'Incorrect result');
            expect(mathEnforcer.sum(7, {a: 5})).to.equal(undefined, 'Incorrect result');
        });
        it('should return the sum of the two numbers for number arguments', function () {
            expect(mathEnforcer.sum(34, 32)).to.equal(66, 'Incorrect result');
            expect(mathEnforcer.sum(0, -5)).to.equal(-5, 'Incorrect result');
            expect(mathEnforcer.sum(-10, 13)).to.equal(3, 'Incorrect result');
            expect(mathEnforcer.sum(3.14, 5.21)).closeTo(8.35, 0.01, 'Incorrect result');
        });
    });
});