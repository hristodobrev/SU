function cars(commands) {
    let map = new Map();
    let carManager = {
        create: ([name, , parent]) => {
            parent = parent ? map.get(parent) : null;
            let newObj = Object.create(parent);
            map.set(name, newObj);
        },
        set: ([name, key, value]) => {
            let obj = map.get(name);
            obj[key] = value;
        },
        print: ([name]) => {
            let obj = map.get(name);
            let keys = [];
            for (let key in obj) {
                keys.push(key);
            }
            console.log(keys.map((key) => `${key}:${obj[key]}`).join(', '));
        }
    };

    for (let command of commands) {
        let commandParmeters = command.split(' ');
        let action = commandParmeters.shift();
        carManager[action](commandParmeters);
    }
}

cars(['create c1','create c2 inherit c1','set c1 color red','set c2 model new','print c1','print c2']);