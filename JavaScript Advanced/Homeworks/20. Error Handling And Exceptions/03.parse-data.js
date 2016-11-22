function makeCandy(recipes) {
    class Candy {
        constructor(topping, filling, spice) {
            let validToppings = ['milk chocolate', 'white chocolate', 'dark chocolate'];
            if (!validToppings.includes(topping)) {
                throw new TypeError('Invalid topping: ' + topping);
            }
            this.topping = topping;

            this.filling = filling;
            if (this.filling != null) {
                let validFillings = ['hazelnut', 'caramel', 'strawberry', 'blueberry', 'yogurt', 'fudge'];
                let fillingsArr = filling.split(',');
                for (let fill of fillingsArr) {
                    if (!validFillings.includes(fill)) {
                        throw new TypeError('Invalid fillings: ' + filling);
                    }
                }
                if (fillingsArr.length > 3) {
                    throw new RangeError('Invalid fillings count: ' + fillingsArr.length);
                }

                this.filling = filling;
            }

            this.spice = spice;
            if (spice != null) {
                if (spice == 'poison' || spice == 'asbestos') {
                    throw new TypeError('Invalid spice: ' + spice);
                }
            }
        }
    }

    let candies = [];
    for (let recipe of recipes) {
        let [topping, filling, spice] = recipe.split(':');
        if (!topping || topping == '')
            topping = null;
        if (!filling || filling == '')
            filling = null;
        if (!spice || spice == '')
            spice = null;
        try {
            let candy = new Candy(topping, filling, spice);
            candies.push(candy);
        } catch (e) {
            console.log(e.message);
        }
    }

    return candies;
}

let candies = makeCandy([
    'milk chocolate',
    'dark chocolate:chips',
    'white chocolate::podison',  // invalid
    'white chocolate:fudge:',
    'frosting:yogurt:frosting', // invalid
    'dark chocolate:blueberry,blueberry,yogurt:rock crystals:invalid'
]);

console.log(candies);