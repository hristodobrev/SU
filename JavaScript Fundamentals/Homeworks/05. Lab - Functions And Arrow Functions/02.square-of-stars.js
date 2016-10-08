function squareOfStars([n]) {
    printSquare(n);

    function printSquare(count = 5) {
        for (let i = 1; i <= count; i++)
            console.log("*" + " *".repeat(count - 1));
    }
}