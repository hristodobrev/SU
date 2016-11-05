let isOddOrEven = require('../01.even-or-odd').isOddOrEven;
let expect = require('chai').expect;

describe('isOddOrEven(str)', function () {
    it('should return undefined for non-string input', function () {
        expect(isOddOrEven({name: 'Pesho'})).to.equal(undefined, 'Incorrect result');
    });
    it('should return undefined for non-string input', function () {
        expect(isOddOrEven([1, 3, 6, 3])).to.equal(undefined, 'Incorrect result');
    });
    it('should return undefined for non-string input', function () {
        expect(isOddOrEven(7)).to.equal(undefined, 'Incorrect result');
    });
    it('should return odd for odd string lenght', function () {
        expect(isOddOrEven('Ivancho')).to.equal('odd', 'Incorrect result');
        expect(isOddOrEven('Mariika')).to.equal('odd', 'Incorrect result');
        expect(isOddOrEven('Penka')).to.equal('odd', 'Incorrect result');
    });
    it('should return even for even string length', function () {
        expect(isOddOrEven('Petq')).to.equal('even', 'Incorrect result');
        expect(isOddOrEven('Gogo')).to.equal('even', 'Incorrect result');
        expect(isOddOrEven('Ivan')).to.equal('even', 'Incorrect result');
    });
});