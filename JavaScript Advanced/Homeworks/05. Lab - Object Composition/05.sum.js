function getModel() {
    let model = {
        init: (selector1, selector2, resultSelector) => {
            $(function () {
                model.num1 = $(selector1);
                model.num2 = $(selector2);
                model.result = $(resultSelector);
            });
        },
        add: () => {
            model.action((a, b) => a + b);
        },
        subtract: () => {
            model.action((a, b) => a - b);
        },
        action: (operation) => {
            let val1 = Number(model.val1.val());
            let val2 = Number(model.val2.val());
            model.result.val(operation(val1, val2));
        }
    };

    return model;
}

// Solution using the "Revealing Module" pattern
(function () {
    let num1, num2, result;

    function init(num1Sel, num2Sel, resultSel) {
        num1 = document.getElementById(num1Sel);
        num2 = document.getElementById(num2Sel);
        result = document.getElementById(resultSel);
    }

    function add() {
        action((a, b) => a + b);
    }

    function subtract() {
        action((a, b) => a - b);
    }

    function action(operation) {
        let val1 = Number(num1.value);
        let val2 = Number(num2.value);
        result.value = operation(val1, val2);
    }

    let model = {init, add, subtract};
    return model;
})();