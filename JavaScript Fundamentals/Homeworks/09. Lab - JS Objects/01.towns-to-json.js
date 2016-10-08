function townsToJSON(towns) {
    let townsArr = [];
    for (let town of towns.slice(1)) {
        let [empty, name, lat, lng] = town.split(/\s*\|\s*/);
        let townObj = { Town: name, Latitude: Number(lat), Longitude: Number(lng) };
        townsArr.push(townObj);
    }

    return JSON.stringify(townsArr);
}