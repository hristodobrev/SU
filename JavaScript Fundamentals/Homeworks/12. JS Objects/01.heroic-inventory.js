function heroicInventory(heroesData) {
    let heroes = [];
    for (let heroData of heroesData) {
        let [heroName, heroLevel, heroItems] = heroData.split(/[\/]+/).filter(h => h !== '').map(x => x.trim());
        let items = heroItems ? heroItems.split(/[, ]+/).filter(i => i !== '') : [];
        let hero = {name: heroName, level: Number(heroLevel), items: items};
        heroes.push(hero);
    }

    console.log(JSON.stringify(heroes));
}

heroicInventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1'
]);