let isSymmetric = require('../02.check-for-symmetry').isSymmetric;
let expect = require("chai").expect;

describe("isSymmetric(arr)", function() {
    it("should return false for [1, 2]", function() {
        expect(isSymmetric([1, 2])).to.be.equal(false);
    });
    it("should return true for [9, -4, 9]", function() {
        expect(isSymmetric([9, -4, 9])).to.be.equal(true);
    });
    it("should return true for ['Pesho', 'Gosho', 'Pesho']", function() {
        expect(isSymmetric(['Pesho', 'Gosho', 'Pesho'])).to.be.equal(true);
    });
    it("should return false for ['Pesho', 'Gosho', 'Pesho', 'Gosho']", function() {
        expect(isSymmetric(['Pesho', 'Gosho', 'Pesho', 'Gosho'])).to.be.equal(false);
    });
    it("should return true for []", function() {
        expect(isSymmetric([])).to.be.equal(true);
    });
    it("should return false for 'NotCorrectInput'", function() {
        expect(isSymmetric('NotCorrectInput')).to.be.equal(false);
    });
    it("should return false for {name: Pesho}", function() {
        expect(isSymmetric({name: 'Pesho'})).to.be.equal(false);
    });
    it("should return false for (5, 10)", function() {
        expect(isSymmetric(5, 10)).to.be.equal(false);
    });
    it("should return true for ([5,'hi',{a:5},new Date(),{a:5},'hi',5])", function() {
        expect(isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5])).to.be.equal(true);
    });
    it("should return false for ([5,'hi',{a:5},new Date(),{x:5},'hi',5])", function() {
        expect(isSymmetric([5,'hi',{a:5},new Date(),{x:5},'hi',5])).to.be.equal(false);
    });
});