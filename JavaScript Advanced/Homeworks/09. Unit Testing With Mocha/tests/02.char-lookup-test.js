let lookupChar = require('../02.char-lookup').lookupChar;
let expect = require('chai').expect;

describe('lookupChar(str, index)', function () {
    it('should return undefined for incorrect type of the arguments', function () {
        expect(lookupChar({name: 'Goshko'}, 10)).to.equal(undefined, 'Incorrect result');
        expect(lookupChar(10, 10)).to.equal(undefined, 'Incorrect result');
        expect(lookupChar([1, 3, 5, 8], 2)).to.equal(undefined, 'Incorrect result');
        expect(lookupChar(2, 'Pesho')).to.equal(undefined, 'Incorrect result');
        expect(lookupChar([6, 3, 7, 9], 'Pesho')).to.equal(undefined, 'Incorrect result');
        expect(lookupChar({error: () => {console.log('Incorrect input')}}, 'Pesho')).to.equal(undefined, 'Incorrect result');
        expect(lookupChar((a) => console.log(a), 'Pesho')).to.equal(undefined, 'Incorrect result');
        expect(lookupChar('Pesho', 2.14)).to.equal(undefined, 'Incorrect result');
    });
    it('should return Incorrect index for index out of the range of the string', function () {
        expect(lookupChar('Pesho', 10)).to.equal('Incorrect index', 'Incorrect result');
        expect(lookupChar('Gosho i Pesho', 'Gosho i Pesho'.length)).to.equal('Incorrect index', 'Incorrect result');
        expect(lookupChar('Pesho', -4)).to.equal('Incorrect index', 'Incorrect result');
    });
    it('should return the character at the specified index for valid input', function () {
        expect(lookupChar('Pesho', 4)).to.equal('o', 'Incorrect result');
        expect(lookupChar('Goshko', 0)).to.equal('G', 'Incorrect result');
        expect(lookupChar('Penka is beautiful', 12)).to.equal('u', 'Incorrect result');
    });
});
