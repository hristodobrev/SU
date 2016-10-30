let extensibleObj = (function () {
    let obj = {
        extend: function (template) {
            for (let prop in template) {
                let type = typeof template[prop];
                if (type === 'function') {
                    Object.getPrototypeOf(obj)[prop] = template[prop];
                } else {
                    obj[prop] = template[prop];
                }
            }
        }
    };

    return obj;
})();

let templateObj = {
    a: 5,
    b: function () {
        console.log(templateObj.a);
    },
    c: [1,24,6,5],
    d: { name: 'Pesho', age: 19 },
    e: 'Some text'
};

extensibleObj.extend(templateObj);
extensibleObj.b();
console.log(extensibleObj);