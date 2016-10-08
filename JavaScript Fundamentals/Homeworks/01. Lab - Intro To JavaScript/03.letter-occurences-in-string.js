function letterOccurences(args) {
    var word = args[0];
    var letter = args[1];
    var counts = 0;
    for (var i = 0; i < word.length; i++) {
        if (letter == word[i]) {
            counts++;
        }
    }

    console.log(counts);
}