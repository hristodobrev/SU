function calcSupply(age, maxAge, food, foodPerDay) {
    var kilograms = (maxAge - age) * 365 * foodPerDay;

    var result = kilograms + 'kg of ' + food + ' would be enough until I am ' + maxAge + ' years old.';

    return result;
}
function calculateFood() {
    var age = getElementValue('age');
    var maxAge = getElementValue('max-age');
    var food = getElementValue('food');
    var foodPerDay = getElementValue('food-per-day');

    var log = document.getElementById('result');

    log.innerHTML = calcSupply(age, maxAge, food, foodPerDay);
}

function getElementValue(id) {
    return document.getElementById(id).value;
}