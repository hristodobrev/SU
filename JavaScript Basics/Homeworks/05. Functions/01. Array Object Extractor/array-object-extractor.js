function extractObjects(array) {
    var newArray = [];
    array.forEach(function (element) {
       if(isObject(element)) {
           newArray.unshift(element);
       }
    });

    return newArray;
}

isObject = function(a) {
    //console.log(a.constructor);  // If you don't know how .constructor works, uncomment this
    return a.constructor === Object;
};

console.log(extractObjects([
        "Pesho",
        4,
        4.21,
        { name : 'Valyo', age : 16 },
        { type : 'fish', model : 'zlatna ribka' },
        [1,2,3],
        "Gosho",
        { name : 'Penka', height: 1.65}
    ]
));