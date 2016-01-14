function modifyScore(arr) {
    var filtered = arr.filter(function(num) {
        return num >= 0 && num <= 400;
    });

    var sorted = filtered.sort(function(a, b){
        return a > b;
    });

    var modified = sorted.map(function(num) {
        return Math.floor(num * 0.8 * 10) / 10;
    });

    console.log(modified);
}