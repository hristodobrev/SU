class Console {

    static get placeholder() {
        return /{\d+}/g;
    }

    static writeLine() {
        let message = arguments[0];
        if (arguments.length === 1) {
            if (typeof (message) === 'object') {
                message = JSON.stringify(message);
                return message;
            }
            else if (typeof(message) === 'string') {
                return message;
            }
        }
        else {
            if (typeof (message) !== 'string') {
                throw new TypeError("No string format given!");
            }
            else {
                var placeholders = message.match(this.placeholder).sort(function (a, b) {
                    a = Number(a.substring(1, a.length - 1));
                    b = Number(b.substring(1, b.length - 1));
                    return a - b;
                });
                if (placeholders.length !== (arguments.length - 1)) {
                    throw new RangeError("Incorrect amount of parameters given!");
                }
                else {
                    for (let i = 0; i < placeholders.length; i++) {
                        let number = Number(placeholders[i].substring(1, placeholders[i].length - 1));
                        if (number !== i) {
                            throw new RangeError("Incorrect placeholders given!");
                        }
                        else {
                            message = message.replace(placeholders[i], arguments[i + 1])
                        }
                    }
                    return message;
                }
            }
        }
    }
}

let expect = require('chai').expect;

describe('Console', function () {
    it('should have function writeLine', function () {
        let writeLineFunction = Console.writeLine;
        expect(typeof writeLineFunction).to.equal('function', 'Console class does not contain writeLine function');
    });

    it('should return string with only one string parameter', function () {
        let result = Console.writeLine('Text');
        expect(result).to.equal('Text', 'The function did not return the correct result');
    });

    it('should return undefined with only one non-string and non-object parameter', function () {
        let result = Console.writeLine(91);
        expect(result).to.equal(undefined, 'The function did not return the correct result');
    });

    it('should return JSON stringified object with only one object parameter', function () {
        let obj = {name: 'Pesho', age: 16};
        let result = Console.writeLine(obj);
        expect(result).to.equal(JSON.stringify(obj), 'The function did not return the correct result');
    });

    it('should return replaced string with correct paramenters', function () {
        let result = Console.writeLine('This is test {0} #{1}', 'Enigma', 15);
        let expectedResult = 'This is test Enigma #15';
        expect(result).to.equal(expectedResult, 'The function did not return the correct result');
    });

    it('should throw TypeError without parameters', function () {
        expect(() => {Console.writeLine()}).to.throw('No string format given!',
            'The function did not throw the correct error');
    });

    it('should throw TypeError with first parameter not string', function () {
        expect(() => {Console.writeLine(10, 'Enigma', 15)}).to.throw('No string format given!',
            'The function did not throw the correct error');
    });

    it('should throw RangeError if the placeholders are not equal to the parameters', function () {
        expect(() => {Console.writeLine('Some sample {2}', 'text', 'another text')}).to.throw(
            'Incorrect amount of parameters given!',
            'The function did not throw the correct error');
    });

    it('should throw RangeError if the placeholders are not equal to the parameters', function () {
        expect(() => {Console.writeLine('Some sample {2} {0}', 'text', 'another text')}).to.throw(
            'Incorrect placeholders given!',
            'The function did not throw the correct error');
    });

    it('should throw RangeError if the placeholders are not equal to the parameters', function () {
        expect(() => {Console.writeLine('Some sample {0} {0}', 'text', 'another text')}).to.throw(
            'Incorrect placeholders given!',
            'The function did not throw the correct error');
    });
});