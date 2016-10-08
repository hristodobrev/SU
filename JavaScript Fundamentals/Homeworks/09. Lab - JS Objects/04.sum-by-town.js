function sumByTown(data) {
    let townIncomes = {};

    for (let i = 0; i < data.length; i += 2) {
        let town = data[i];
        let income = Number(data[i + 1]);
        if (!townIncomes[town]) {
            townIncomes[town] = 0;
        }
        townIncomes[town] += income;
    }

    return JSON.stringify(townIncomes);
}