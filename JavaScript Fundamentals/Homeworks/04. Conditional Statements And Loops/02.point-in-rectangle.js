function pointInRectangle([x, y, xMin, xMax, yMin, yMax]) {
    [x, y, xMin, xMax, yMin, yMax] = [x, y, xMin, xMax, yMin, yMax].map(Number);
    let isInside = x >= xMin && x <= xMax && y >= yMin && y <= yMax;
    let result = isInside ? 'inside' : 'outside';

    return result;
}