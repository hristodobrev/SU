class Textbox {
    constructor(selector, regex) {
        this._elements = $(selector);
        let that = this;
        this._elements.on('input', function () {
            for (let el of that._elements) {
                $(el).val(this.value);
            }

            that.value = this.value;
        });
        this._invalidSymbols = regex;
    }

    get value() {
        return this._value;
    }

    set value(val) {
        this._value = val;
        for (let el of this._elements) {
            $(el).val(this._value);
        }
    }

    get elements() {
        return this._elements;
    }

    isValid() {
        if (this._invalidSymbols.test(this.value)) {
            return false;
        }

        return true;
    }
}