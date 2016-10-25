function orderRectangles(input) {
    let rectangles = [];

    for (let line of input) {
        let rect = createRect(line[0], line[1]);
        rectangles.push(rect);
    }

    rectangles.sort((a, b) => a.compareTo(b));
    return rectangles;

    function createRect(width, height) {
        let rect = {
            width,
            height,
            area: () => width * height,
            compareTo: (other) => {
                let result = other.area() - rect.area();
                return result || other.width - rect.width;
            }
        };

        return rect;
    }
}

orderRectangles([[10,5], [3,20], [5,12]]);