function treasureLocator(input) {
    let islands = [
        { x1: 8, x2: 9, y1: 0, y2: 1, name: 'Tokelau' },
        { x1: 1, x2: 3, y1: 1, y2: 3, name: 'Tuvalu' },
        { x1: 5, x2: 7, y1: 3, y2: 6, name: 'Samoa' },
        { x1: 0, x2: 2, y1: 6, y2: 8, name: 'Tonga' },
        { x1: 4, x2: 9, y1: 7, y2: 8, name: 'Cook' }
    ];

    for (let i = 0; i < input.length; i += 2) {
        let x = Number(input[i]);
        let y = Number(input[i + 1]);
        let onIsland = false;

        for (let island of islands) {
            if (checkIsInsideIsland(island, x, y)) {
                onIsland = true;
                break;
            }
        }

        if (!onIsland) {
            console.log('On the bottom of the ocean');
        }
    }

    function checkIsInsideIsland (island, x, y) {
        if (island.x1 <= x && x <= island.x2 &&
            island.y1 <= y && y <= island.y2) {
            console.log(island.name);
            return true;
        }

        return false;
    }
}