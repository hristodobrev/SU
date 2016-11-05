function isOddOrEven(str) {
    if (typeof str != 'string'){
        return undefined;
    }

    return str.length % 2 == 0 ? 'even' : 'odd';
}

let expect = require("chai").expect;
let assert = require("chai").assert;

describe('isOddOrEven(str)', function () {
    it('should return odd for odd length of string', function () {
        expect(isOddOrEven('balbal')).to.be.equal('even', 'Incorrect result');
    });
    it('should return undefined for non-string argument', function () {
        isOddOrEven({name: 'Pesho'}).should.equal(undefined, 'Function did not return the correct result');
        assert.equal(isOddOrEven([2, 5, 2]), undefined, 'Function did not return the correct result');
    });
});