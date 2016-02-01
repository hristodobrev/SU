Array.prototype.removeItem = (function (item){
    var newArray = [];
    for (var index in this) {
        if(this[index] !== item && typeof this[index] !== "function") {
            newArray.push(this[index]);
        }
    }

    return newArray;
});

var arr1 = [1, 2, 3, 2];
console.log(arr1.removeItem(3));

var arr2 = ['hi', 'bye', 'hello' ];
console.log(arr2.removeItem('bye'));

var arr3 = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
console.log(arr3.removeItem(1));
