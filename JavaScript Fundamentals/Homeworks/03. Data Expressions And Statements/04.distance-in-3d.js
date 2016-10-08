function distIn3d([x1, y1, z1, x2, y2, z2]) {
    let distIn2d = Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    let zDist = Math.abs(z1 - z2);

    let distIn3d = Math.sqrt(zDist * zDist + distIn2d * distIn2d);

    return distIn3d;
}