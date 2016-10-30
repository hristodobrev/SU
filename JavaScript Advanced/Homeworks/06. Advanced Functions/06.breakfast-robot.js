let breakfastRobot = (function () {
    let robot = (function () {
        stock = {
            protein: 0,
            carbohydrate: 0,
            fat: 0,
            flavour: 0
        };

        recipes = {
            apple: {carbohydrate: 1, flavour: 2},
            coke: {carbohydrate: 10, flavour: 20},
            burger: {carbohydrate: 5, flavour: 3, fat: 7},
            omelet: {flavour: 1, fat: 1, protein: 5},
            cheverme: {flavour: 10, fat: 10, protein: 10, carbohydrate: 10},
        };

        return {
            restock: (microelement, quantity) => {
                stock[microelement] += Number(quantity);
                return 'Success';
            },
            prepare: (recipe, quantity) => {
                let productsNeeded = recipes[recipe];
                for (let i = 0; i < quantity; i++) {
                    let hasProducts = true;
                    for (let product in productsNeeded) {
                        if (stock[product] < productsNeeded[product]) {
                            return `Error: not enough ${product} in stock`;
                        }
                    }
                    for (let product in productsNeeded) {
                        stock[product] -= productsNeeded[product];
                    }
                }

                return 'Success';
            },
            report: () => {
                return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`;
            }
        }
    })();

    function executeCommand(commands) {
        let [command, arg, quantity] = commands.split(' ');
        return robot[command](arg, quantity);
    }

    return executeCommand;
})();

console.log(breakfastRobot('restock flavour 50'));
console.log(breakfastRobot('restock fat 50'));
console.log(breakfastRobot('report'));
console.log(breakfastRobot('prepare coke 4'));