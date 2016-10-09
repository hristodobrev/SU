function cappyJuice(dataRows) {
    let juices = new Map();
    let bottles = new Map();
    for (let dataRow of dataRows) {
        let [product, quantity] = dataRow.split(' => ');
        if (!juices.has(product)) {
            juices.set(product, Number(quantity));
        } else {
            juices.set(product, juices.get(product) + Number(quantity));
        }

        if (juices.get(product) >= 1000) {
            bottles.set(product, Math.floor(juices.get(product) / 1000));
        }
    }

    for (let juice of bottles.keys()) {
        console.log(`${juice} => ${bottles.get(juice)}`);
    }
}

cappyJuice([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);