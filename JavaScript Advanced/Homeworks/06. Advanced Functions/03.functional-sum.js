let functionalSum = (function(){
    let sum = 0;

    let add = function (value) {
        sum += value;
        return add;
    };

    add.toString = function(){
        return sum;
    };

    return add;
})();

console.log(functionalSum(5)(5)(-3)(1).toString());