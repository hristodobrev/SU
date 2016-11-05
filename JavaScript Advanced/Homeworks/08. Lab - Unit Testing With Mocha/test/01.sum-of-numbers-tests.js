let sum = require('../01.sum-of-numbers').sum;
let expect = require("chai").expect;

describe("sum(arr)", function() {
    it("should return 3 for [1, 2]", function() {
        expect(sum([1, 2])).to.be.equal(3);
    });
    it("should return 5 for [9, -4]", function() {
        expect(sum([9, -4])).to.be.equal(5);
    });
    it("should return -12 for [1, 2, 4, -19]", function() {
        expect(sum([1, 2, 4, -19])).to.be.equal(-12);
    });
});