class SortedList {
    constructor() {
        this.items = [];
        this.size = this.items.length;
    }

    add(element) {
        this.items.push(element);
        this.update();
    }

    remove(index) {
        if (index < 0 || index > this.items.length - 1) {
            throw new Error('Index out of range');
        }

        this.items[index] = undefined;
        this.update();
    }

    get(index) {
        if (index < 0 || index > this.items.length - 1) {
            throw new Error('Index out of range');
        }

        return this.items[index];
    }

    update() {
        this.items = this.items.filter(x => x != undefined);
        this.items.sort((a, b) => a - b);
        this.size = this.items.length;
    }
}

let list = new SortedList();
console.log(list.hasOwnProperty('size'));
list.add(16);
list.add(2);
list.add(5);
console.log(list.get(0));