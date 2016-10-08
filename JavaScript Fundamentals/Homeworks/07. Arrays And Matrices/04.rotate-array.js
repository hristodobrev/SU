function rotateArr(arr) {
    let rotations = Number(arr.pop());

    let right = arr.slice(-rotations);
    arr.splice(-rotations);
    let left = arr;

    return right.concat(left).join(' ');
}