(function () {
    String.prototype.ensureStart = function (str) {
        if (this.indexOf(str) != 0) {
            return str + this.toString();
        }

        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (this.toString().indexOf(str) != this.toString().length - str.length) {
            return this.toString() + str;
        }

        return this.toString();
    };

    String.prototype.isEmpty = function () {
        if (this.toString() === '') {
            return true;
        }

        return false;
    };

    String.prototype.truncate = function (n) {
        if (this.toString().length < n) {
            return this.toString();
        }

        let dots = '...';
        if (n < 4) {
            return dots.substr(0, n);
        }

        let words = this.toString().split(' ');
        if (words.length == 1) {
            return this.toString().substr(0, n - 3) + '...';
        } else {
            let cut = this.toString().substr(0, n - 3);
            if (this.toString()[n - 3] == ' ') {
                return cut + '...';
            } else {
                cut = cut.split(' ');
                cut.pop();
                cut = cut.join(' ');

                return cut + '...';
            }
        }
    };

    String.format = function (str, ...params) {
        let reg = new RegExp('{([0-9])}', 'g');
        str = str.replace(reg, (match, index) => {
            if (params[index]) {
                return params[index];
            } else {
                return match;
            }
        });

        return str;
    }
})();


let str = 'my string'
console.log(str);
str = str.ensureStart('my')
console.log(str);
str = str.ensureStart('hello ')
console.log(str);
str = str.truncate(16)
console.log(str);
str = str.truncate(14)
console.log(str);
str = str.truncate(8)
console.log(str);
str = str.truncate(4)
console.log(str);
str = str.truncate(2)
console.log(str);
str = String.format('The {0} {1} fox',
    'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}',
    'dog');
console.log(str);