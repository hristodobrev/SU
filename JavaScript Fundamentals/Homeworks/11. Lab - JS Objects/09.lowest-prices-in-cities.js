function lowestPricesInCities(dataRows) {
    let products = {};

    for (let dataRow of dataRows) {
        let [town, product, price] = dataRow.split(/[\|]+/).map(x => x.trim());
        if (!products[product]) {
            products[product] = {};
        }

        products[product][town] = price;
    }

    for (let product in products) {
        let minPrice = Number.MAX_VALUE;
        let minTown = '';
        for (let town in products[product]) {
            if (minPrice > Number(products[product][town])) {
                minPrice = Number(products[product][town]);
                minTown = town;
            }
        }
        console.log(`${product} -> ${minPrice} (${minTown})`);
    }
}

lowestPricesInCities([
    'Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000'
]);

// lowestPricesInCities([
//     'Sample Town | Sample Product | 1000',
//     'Sample Town | Orange | 2',
//     'Sample Town | Peach | 1',
//     'Sofia | Orange | 3',
//     'Sofia | Peach | 2',
//     'New York | Sample Product | 1000.1',
//     'New York | Burger | 10'
// ]);