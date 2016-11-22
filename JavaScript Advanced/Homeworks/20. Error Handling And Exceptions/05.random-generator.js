function* random(seed) {
    while (true) {
        let xn = (seed * seed) % (4871 * 7919);
        yield xn % 100;
        seed = xn;
    }
}

let rnd = random(new Date().getMilliseconds());

for (let i = 0; i < 1; i++) {
    console.log(rnd.next().value);
}