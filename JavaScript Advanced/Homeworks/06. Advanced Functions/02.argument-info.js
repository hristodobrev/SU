function argumentInfo() {
    let map = new Map();
    for (let line of arguments) {
        let type = typeof(line);
        if (type === 'object'){
            line = JSON.stringify(line);
        }
        console.log(`${type}: ${line}`);
        if(!map.has(type)){
            map.set(type, 0);
        }

        map.set(type, map.get(type) + 1);
    }

    let keys = Array.from(map.keys());
    for (let key of keys.sort((a, b) => map.get(b) - map.get(a))) {
        console.log(`${key} = ${map.get(key)}`);
    }
}

argumentInfo({ name: 'bob'}, 3.333, 9.999);