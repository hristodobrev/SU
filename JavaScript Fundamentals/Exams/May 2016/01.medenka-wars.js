function medenkaWars(input) {
    let naskorDamage = 0;
    let viktorDamage = 0;
    let lastNaskorDamage = 0;
    let lastViktorDamage = 0;
    let naskorTurns = 0;
    let viktorTurns = 0;
    for (let line of input) {
        let tokens = line.split(' ');
        let medenkas = Number(tokens[0]);
        let force = tokens[1];

        if (force === 'white') {
            let damage = medenkas * 60;
            if (lastViktorDamage === damage) {
                viktorTurns++;
            } else {
                viktorTurns = 1;
                lastViktorDamage = damage;
            }
            if (viktorTurns >= 2) {
                damage *= 2.75;
            }
            viktorDamage += damage;
        } else {
            let damage = medenkas * 60;
            if (lastNaskorDamage === damage) {
                naskorTurns++;
            } else {
                naskorTurns = 1;
                lastNaskorDamage = damage;
            }
            if (naskorTurns >= 5) {
                damage *= 4.5;
            }
            naskorDamage += damage;
        }
    }

    console.log(`Winner - ${naskorDamage > viktorDamage ? 'Naskor' : 'Vitkor'}`);
    console.log(`Damage - ${naskorDamage > viktorDamage ? naskorDamage : viktorDamage}`);
}

// medenkaWars([
//     '5 white medenkas',
//     '5 dark medenkas',
//     '4 white medenkas'
// ]);

medenkaWars([
    '2 dark medenkas',
    '1 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas',
    '15 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas'
]);