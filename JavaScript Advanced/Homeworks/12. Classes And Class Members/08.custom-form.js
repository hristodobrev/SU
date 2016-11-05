let jsdom = require('jsdom-global')();
let $ = require('jquery');
(function () {

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

class Form {
    constructor() {
        this._element = $('<div class="form">');
        this._textboxes = [];
        for (let textbox of arguments) {
            if (!(textbox instanceof Textbox)) {
                throw new Error('The parameters must be a type of Textbox.');
            } else {
                this._element.append(textbox.elements);
                this._textboxes.push(textbox);
            }
        }
    }

    submit() {
        let allTrue = true;
        for (let textbox of this._textboxes) {
            if (textbox.isValid()) {
                textbox.elements.css('border', '2px solid green');
            } else {
                textbox.elements.css('border', '2px solid red');
                allTrue = false;
            }
        }

        return allTrue;
    }

    attach(selector) {
        $(selector).append(this._element);
    }
}

return {
    Textbox: Textbox,
    Form: Form
};

})();

let f1 = new Form(new Textbox('.bla', /[0-9]+/),'fawfga');
console.log(f1);