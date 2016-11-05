class Extensible {
    constructor(){
        if (!Extensible.id) {
            Extensible.id = 0;
        }

        this.id = Extensible.id;

        Extensible.id++;
    }

    static get id() {
        return Extensible._id;
    }

    static set id(value){
        Extensible._id = value;
    }

    extend(template) {
        for (let prop in template) {
            let type = typeof template[prop];
            if (type === 'function') {
                Object.getPrototypeOf(this)[prop] = template[prop];
            } else {
                this[prop] = template[prop];
            }
        }
    }
}

let a = new Extensible();
let b = new Extensible();
let c = new Extensible();
let d = new Extensible();

let template = {
    extensionMethod: function () {
        console.log('Some function');
    },
    extensionProperty: 'someString'
};

a.extend(template);
a.extensionMethod();

console.log(a);
console.log(b);
console.log(c.id);
console.log(d.id);