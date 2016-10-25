function radicalMarketing(input) {
    let people = new Map();
    let subscriptions = new Map();
    let mostPopular = null;
    for (let line of input) {
        let tokens = line.split('-');
        if (mostPopular == null) {
            mostPopular = tokens[0];
        }
        if (tokens.length === 1) {
            if (!people.has(tokens[0])) {
                people.set(tokens[0], []);
                subscriptions.set(tokens[0], []);
            }
        } else {
            let a = tokens[0];
            let b = tokens[1];
            if (people.has(a) && people.has(b) && a != b && people.get(b).indexOf(a) === -1) {
                people.get(b).push(a);
                subscriptions.get(a).push(b);
            }
        }
    }

    let subscribers = [];
    for (let person of people) {
        if (people.get(person[0]).length > subscribers.length) {
            mostPopular = person[0];
            subscribers = people.get(person[0]);
        }
    }

    for (let person of people) {
        if (people.get(person[0]).length === people.get(mostPopular).length) {
            if (subscriptions.get(person[0]).length > subscriptions.get(mostPopular).length){
                mostPopular = person[0];
            }
        }
    }

    console.log(mostPopular);
    for (let i = 0; i < people.get(mostPopular).length; i++) {
        console.log(`${i + 1}. ${people.get(mostPopular)[i]}`);
    }
}

radicalMarketing([
    'A',
    'B',
    'C',
    'D',
    'A-B',
    'B-A',
    'C-A',
    'D-A',
    'D-B',
    'B-D',
    'C-B',
]);