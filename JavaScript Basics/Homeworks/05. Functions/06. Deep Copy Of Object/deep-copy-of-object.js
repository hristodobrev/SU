function clone(obj) {
    if(obj == null || typeof obj != 'object') {
        return obj;
    }

    var copy = obj.constructor();
    for (var attr in obj) {
        if(obj.hasOwnProperty(attr)) {
            copy[attr] = obj[attr];
        }
    }

    return copy;
}

function compareObjects(a, b) {
    console.log(a == b);
}

var a = {name: 'Pesho', age: 21}
var b = clone(a); // a deep copy
compareObjects(a, b);

var c = {name: 'Pesho', age: 21} ;
var d = c; // not a deep copy
compareObjects(c, d);
