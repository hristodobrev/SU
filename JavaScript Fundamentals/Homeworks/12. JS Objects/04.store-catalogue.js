function storeCatalogue(products) {
    let productsMap = new Map();

    for (let product of products) {
        let [productName, productPrice] = product.split(' : ');
        productsMap.set(productName, Number(productPrice));
    }

    let productKeys = Array.from(productsMap.keys()).sort();
    let currentChar;
    for (let key of productKeys) {
        let firstChar = key[0].toUpperCase();
        if (firstChar != currentChar) {
            currentChar = firstChar;
            console.log(firstChar);
        }
        console.log(`  ${key}: ${productsMap.get(key)}`);
    }
}

storeCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);