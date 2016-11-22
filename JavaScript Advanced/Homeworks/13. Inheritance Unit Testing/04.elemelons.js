function elemelons() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new TypeError('Abstract class cannot be instantiated directly.');
            }

            this.weight = weight;
            this.melonSort = melonSort;
        }

        toString() {
            let result = '';
            let element = this.constructor.name;
            element = element.substr(0, element.length - 5);
            result += `Element: ${element}\n`;
            result += `Sort: ${this.melonSort}\n`;

            return result;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = weight * melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let result = super.toString();
            result += `Element Index: ${this.elementIndex}`;

            return result;
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = weight * melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let result = super.toString();
            result += `Element Index: ${this.elementIndex}`;

            return result;
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = weight * melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let result = super.toString();
            result += `Element Index: ${this.elementIndex}`;

            return result;
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = weight * melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let result = super.toString();
            result += `Element Index: ${this.elementIndex}`;

            return result;
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._index = 0;
            this._elementsArr = [Watermelon, Firemelon, Earthmelon, Airmelon];
            this.morph();
        }

        morph() {
            this.prototype = Object.create(this._elementsArr[this._index].prototype);
            this.constructor = this._elementsArr[this._index];
            this._index++;
            this._index = this._index % this._elementsArr.length;
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    }
}

let result = elemelons();
let Melon = result.Melon;
let Watermelon = result.Watermelon;
let Firemelon = result.Firemelon;
let Earthmelon = result.Earthmelon;
let Airmelon = result.Airmelon;
let Melolemonmelon = result.Melolemonmelon;

let melolemonmelon = new Melolemonmelon(12.5, "Kingsize");
console.log(melolemonmelon.toString());
console.log();
melolemonmelon.morph();
melolemonmelon.morph();
melolemonmelon.morph();
console.log(melolemonmelon.toString());
console.log();
melolemonmelon.morph();
console.log(melolemonmelon.toString());
console.log();
melolemonmelon.morph();
console.log(melolemonmelon.toString());