function cityMarkets(dataRows) {
    let towns = new Map();

    for (let dataRow of dataRows) {
        let [town, product, sale] = dataRow.split(/[\-\>]+/).map(x => x.trim());
        if (!towns.has(town)) {
            towns.set(town, new Map());
        }

        let [productCount, productPrice] = sale.split(/[:]+/).map(Number);

        if (!towns.get(town).has(product)) {
            towns.get(town).set(product, productCount * productPrice);
        }
    }

    let townKeys = towns.keys();
    for (let townKey of townKeys) {
        console.log(`Town - ${townKey}`);
        let townProductKeys = towns.get(townKey).keys();
        for (let townProductKey of townProductKeys) {
            console.log(`$$$${townProductKey} : ${towns.get(townKey).get(townProductKey)}`);
        }
    }
}

cityMarkets([
    'Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'
]);