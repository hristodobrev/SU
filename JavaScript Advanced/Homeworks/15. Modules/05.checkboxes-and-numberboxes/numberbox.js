class Numberbox {
    constructor(label, selector, minValue, maxValue) {
        this._label = label;
        this._elements = $(selector);
        this._minValue = Number(minValue);
        this._maxValue = Number(maxValue);
        this.elements.on('change', () => {
            this.value = this.elements.val();
        });
    }

    get label() {
        return this._label;
    }

    get elements() {
        return this._elements;
    }

    set value(val) {
        val = Number(val);
        if (isNaN(val)) {
            throw new Error('The value must be of type Number');
        }

        if (val < this._minValue || val > this._maxValue) {
            throw new Error('The value must be between the min and max value');
        }

        this._value = val;
        this.elements.val(val);
    }

    get value() {
        return this._value;
    }
}

module.exports = Numberbox;