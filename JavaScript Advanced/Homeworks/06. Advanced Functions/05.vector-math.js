(function vectorMath() {
    function add(vect1, vect2) {
        return [vect1[0] + vect2[0], vect1[1] + vect2[1]];
    }
    
    function multiply(vect, scalar) {
        return [vect[0] * scalar, vect[1] * scalar];
    }
    
    function length(vect) {
        return Math.sqrt(vect[0] * vect[0] + vect[1] * vect[1]);
    }
    
    function dot(vect1, vect2) {
        return vect1[0] * vect2[0] + vect1[1] * vect2[1];
    }

    function cross(vect1, vect2) {
        return vect1[0] * vect2[1] - vect2[0] * vect1[1];
    }

    return {add, multiply, length, dot, cross};
})()

console.log(vectorMath().add([1,3], [3,4]));
console.log(vectorMath().multiply([1,3], 2));
console.log(vectorMath().length([1,3]));
console.log(vectorMath().dot([1,3], [3,4]));
console.log(vectorMath().cross([1,3], [3,4]));