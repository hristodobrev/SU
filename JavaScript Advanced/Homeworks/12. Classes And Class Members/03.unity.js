class Rat {
    constructor(name) {
        this.name = name;
        this.rats = new Array();
    }

    unite(rat) {
        if (!(rat instanceof Rat)) {
            return;
        }

        this.rats.push(rat);
    }

    getRats() {
        return this.rats;
    }

    toString() {
        let result = this.name;
        for (let rat of this.rats) {
            result += `\n##${rat.name}`;
        }

        return result;
    }
}

let pesho = new Rat('Pesho');
let gosho = new Rat('Gosho');
let penka = new Rat('Penka');
let stoika = new Rat('Stoika');
let ivan = new Rat('Ivan');

pesho.unite(gosho);
pesho.unite('Penkatata');
pesho.unite(penka);
pesho.unite(stoika);
pesho.unite(ivan);

ivan.unite(pesho);
ivan.unite(gosho);
ivan.unite(penka);

penka.unite(pesho);

console.log('' + pesho);
console.log('' + ivan);
console.log('' + penka);
console.log('' + stoika);