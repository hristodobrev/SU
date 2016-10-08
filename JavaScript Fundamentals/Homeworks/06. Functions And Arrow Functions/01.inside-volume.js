function insideVolume(input) {
    let points = input.map(Number);
    let x1 = 10;
    let x2 = 50;
    let y1 = 20;
    let y2 = 80;
    let z1 = 15;
    let z2 = 50;

    for (let i = 0; i < points.length / 3; i++) {
        let x = points[i * 3];
        let y = points[i * 3 + 1];
        let z = points[i * 3 + 2];

        if (x1 <= x && x <= x2 && y1 <= y && y <= y2 &&
            z1 <= z && z <= z2) {
            console.log('inside');
        } else {
            console.log('outside');
        }
    }
}