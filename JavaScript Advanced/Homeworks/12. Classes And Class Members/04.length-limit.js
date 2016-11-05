class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }

    increase(amount) {
        if (amount < 0) {
            return;
        }

        this.innerLength += amount;
    }

    decrease(amount) {
        if (amount < 0 || this.innerLength < amount) {
            return;
        }

        this.innerLength -= amount;
    }

    toString() {
        if (this.innerLength < this.innerString.length) {
            if (this.innerLength == 0) {
                return '...';
            }

            return this.innerString.substr(0, this.innerLength) + '...';
        }

        return this.innerString;
    }
}

let str1 = new Stringer('Initial string', 20);
str1.decrease(20);
str1.increase(10);
console.log('' + str1);