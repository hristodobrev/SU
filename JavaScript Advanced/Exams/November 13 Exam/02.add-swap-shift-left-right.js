let expect = require('chai').expect;

function createList() {
    let data = [];
    return {
        add: function (item) {
            data.push(item)
        },
        shiftLeft: function () {
            if (data.length > 1) {
                let first = data.shift();
                data.push(first);
            }
        },
        shiftRight: function () {
            if (data.length > 1) {
                let last = data.pop();
                data.unshift(last);
            }
        },
        swap: function (index1, index2) {
            if (!Number.isInteger(index1) || index1 < 0 || index1 >= data.length ||
                !Number.isInteger(index2) || index2 < 0 || index2 >= data.length ||
                index1 === index2) {
                return false;
            }
            let temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
            return true;
        },
        toString: function () {
            return data.join(", ");
        }
    };
}

describe('list', function () {
    let list;
    beforeEach(function () {
        list = createList();
    });

    describe('add', function () {
        it('should be initially empty', function () {
            expect(list.toString()).to.equal('', 'The list is not empty');
        });

        it('should add item to the end of the list', function () {
            list.add();
            expect(list.toString()).to.equal('', 'The list is not empty');
        });

        it('should add item to the end of the list', function () {
            list.add(1);
            list.add('two');
            expect(list.toString()).to.equal('1, two', 'The list is not empty');
            list.add({text: 'three'});
            list.add([4, 'five']);
            expect(list.toString()).to.equal('1, two, [object Object], 4,five', 'The list is not empty');
        });
    });

    describe('shiftLeft', function () {
        it('should shift correctly', function () {
            list.add(1);
            list.add('two');
            list.add([4, 'five']);
            list.shiftLeft();
            expect(list.toString()).to.equal('two, 4,five, 1', 'The list is not empty');
            list.shiftLeft();
            expect(list.toString()).to.equal('4,five, 1, two', 'The list is not empty');
        });

        it('should shift correctly', function () {
            list.shiftLeft();
            expect(list.toString()).to.equal('', 'The list is not empty');
            list.add(1);
            list.shiftLeft();
            expect(list.toString()).to.equal('1', 'The list is not empty');
            list.shiftLeft();
            list.add(2);
            list.shiftLeft();
            expect(list.toString()).to.equal('2, 1', 'The list is not empty');
        });
    });

    describe('shiftRight', function () {
        it('should shift correctly', function () {
            list.add(1);
            list.add('two');
            list.add([4, 'five']);
            list.shiftRight();
            expect(list.toString()).to.equal('4,five, 1, two', 'The list is not empty');
            list.shiftRight();
            expect(list.toString()).to.equal('two, 4,five, 1', 'The list is not empty');
        });

        it('should shift correctly', function () {
            list.shiftRight();
            expect(list.toString()).to.equal('', 'The list is not empty');
            list.add(1);
            list.shiftRight();
            expect(list.toString()).to.equal('1', 'The list is not empty');
            list.shiftRight();
            list.add(2);
            list.shiftRight();
            expect(list.toString()).to.equal('2, 1', 'The list is not empty');
        });
    });

    describe('swap', function () {
        it('should swap the two items with correct parameters', function () {
            list.add('Pesho');
            list.add('Gosho');
            list.add('Tosho');
            expect(list.swap(0, 1)).to.equal(true, 'The items did not swap correctly.');
            expect(list.toString()).to.equal('Gosho, Pesho, Tosho', 'The items did not swap correctly.');
            expect(list.swap(0, 2)).to.equal(true, 'The items did not swap correctly.');
            expect(list.toString()).to.equal('Tosho, Pesho, Gosho', 'The items did not swap correctly.');
        });

        it('should not swap anything with not correct parameters', function () {
            list.add('Pesho');
            list.add('Gosho');
            list.add('Tosho');
            expect(list.swap(0, 3)).to.equal(false, 'The items did not swap correctly.');
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
            expect(list.swap('0', '1')).to.equal(false, 'The items did not swap correctly.');
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
            expect(list.swap(undefined, 5)).to.equal(false, 'The items did not swap correctly.');
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
        });

        it('should not swap anything with not correct parameters', function () {
            list.add('Pesho');
            list.add('Gosho');
            list.add('Tosho');
            expect(list.swap(0, -3)).to.equal(false);
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
        });

        it('should not swap anything with not correct parameters', function () {
            list.add('Pesho');
            list.add('Gosho');
            list.add('Tosho');
            expect(list.swap(0)).to.equal(false);
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
        });

        it('should not swap anything with not correct parameters', function () {
            list.add('Pesho');
            list.add('Gosho');
            list.add('Tosho');
            expect(list.swap(1, 1)).to.equal(false);
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
        });

        it('should not swap anything with not correct parameters', function () {
            list.add('Pesho');
            list.add('Gosho');
            list.add('Tosho');
            expect(list.swap(1.5, 0.5)).to.equal(false);
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
        });

        it('should not swap anything with not correct parameters', function () {
            list.add('Pesho');
            list.add('Gosho');
            list.add('Tosho');
            expect(list.swap(NaN, 1)).to.equal(false);
            expect(list.toString()).to.equal('Pesho, Gosho, Tosho', 'The items were swapped.');
        });

        it('should not swap anything with not correct parameters', function () {
            expect(list.swap(0, 0)).to.equal(false);
            expect(list.toString()).to.equal('', 'The items were swapped.');
            list.add(1);
            expect(list.swap(0, 0)).to.equal(false);
            expect(list.toString()).to.equal('1', 'The items were swapped.');
            list.add(2);
            expect(list.swap(0, 1)).to.equal(true);
            expect(list.toString()).to.equal('2, 1', 'The items were swapped.');
        });
        it('should swap correctly with correct parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(0, 4)).to.equal(true, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('five, 2, three, 4, 1', 'The list was not swap correctly');
            expect(list.swap(0, 2)).to.equal(true, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('three, 2, five, 4, 1', 'The list was not swap correctly');
        });

        it('should swap correctly with correct parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(0, 4)).to.equal(true, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('five, 2, three, 4, 1', 'The list was not swap correctly');
            expect(list.swap(0, 2)).to.equal(true, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('three, 2, five, 4, 1', 'The list was not swap correctly');
            expect(list.swap(3, 2)).to.equal(true, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('three, 2, 4, five, 1', 'The list was not swap correctly');
            expect(list.swap(2, 3)).to.equal(true, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('three, 2, five, 4, 1', 'The list was not swap correctly');
        });

        it('should not swap with same parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(0, 0)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with incorrect parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(0, '1')).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with incorrect parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap('0', 1)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with incorrect parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(0.5, 1)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with incorrect parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(0, 1.5)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with out of range parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(-1, 1)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with out of range parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(1, -1)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with out of range parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(6, 1)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with out of range parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(1, 6)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with out of range parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(undefined, 2)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with out of range parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap(2, undefined)).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });

        it('should not swap with incorrect parameters', function () {
            list.add(1);
            list.add(2);
            list.add('three');
            list.add(4);
            list.add('five');
            expect(list.swap([1, 2])).to.equal(false, 'The swap did not return the correct result');
            expect(list.toString()).to.equal('1, 2, three, 4, five', 'The list was not swap correctly');
        });
    });
});