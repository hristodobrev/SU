function orderedList() {
    let items = [];

    let list = {
        size: 0,
        add: add,
        remove: remove,
        get: get
    };

    function add(element) {
        items.push(element);
        list.size++;
        update();
    }

    function remove(index) {
        if (index < 0 || index > items.length - 1) {
            throw new Error('Index out of range');
        }

        items[index] = undefined;
        list.size--;
        update();
    }

    function get(index) {
        if (index < 0 || index > items.length - 1) {
            throw new Error('Index out of range');
        }

        return items[index];
    }

    function update() {
        items = items.filter(x => x != undefined);
        items.sort((a, b) => a - b);
    }

    return list;
}

let list = orderedList();
list.add(5);
list.add(1);
list.add(8);
list.add(10);
list.add(3);
list.remove(3);
console.log(list.size);
console.log(list.get(0));
console.log(list.get(1));
console.log(list.get(2));
console.log(list.get(3));
list.remove(2);
console.log(list.get(2));