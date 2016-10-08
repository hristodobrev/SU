function cookingByNumbers(input) {
    let num = Number(input[0]);

    let operations = {
        'chop': function() { num /= 2; console.log(num); },
        'dice': function() { num = Math.sqrt(num); console.log(num); },
        'spice': function() { num++; console.log(num); },
        'bake': function() { num *= 3; console.log(num); },
        'fillet': function() { num *= 0.8; console.log(num); }
    };

    let actions = input.slice(1);
    actions.forEach(x => operations[x]());
}