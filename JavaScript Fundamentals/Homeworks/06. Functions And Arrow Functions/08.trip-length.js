function tripLength([x1,y1,x2,y2,x3,y3]) {
    [x1,y1,x2,y2,x3,y3] = [x1,y1,x2,y2,x3,y3].map(Number);

    let d12 = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
    let d23 = Math.sqrt(Math.pow(x3 - x2, 2) + Math.pow(y3 - y2, 2));
    let d31 = Math.sqrt(Math.pow(x1 - x3, 2) + Math.pow(y1 - y3, 2));

    if (d12 === d23 && d12 === d31 && d23 === d31) {
        console.log('1->2->3: ' + (d12 + d23));
        return;
    }

    let max = Math.max(d12, d23, d31);
    let middlePoint = 3;
    let distance = d23 + d31;

    if (d23 === max && 1 <= middlePoint) {
        middlePoint = 1;
        distance = d12 + d31;
    }

    if (d31 === max && 2 <= middlePoint) {
        middlePoint = 2;
        distance = d12 + d23;
    }

    if (middlePoint === 1) {
        console.log('2->1->3: ' + distance);
    } else if (middlePoint === 2) {
        console.log('1->2->3: ' + distance);
    } else {
        console.log('1->3->2: ' + distance);
    }
}