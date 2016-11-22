class Checkbox {
    constructor(label, selector) {
        this._label = label;
        this._elements = $(selector);
        this.elements.on('change', () => {
            this.value = this.elements[0].checked;
        });
        this.value = this.elements[0].checked;
    }

    get label() {
        return this._label;
    }

    get elements() {
        return this._elements;
    }

    set value(val) {
        if (val.constructor.name != 'Boolean') {
            throw new Error('The value must be of type Boolean');
        }

        this._value = val;
        this.elements[0].checked = val;
    }

    get value() {
        return this._value;
    }
}

module.exports = Checkbox;