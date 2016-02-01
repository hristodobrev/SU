function sortLetters(word, reversed) {
    var sorted = word.split('').sort(function (a, b) {
        return a.toLowerCase() > b.toLowerCase();
    });

    if(!reversed) {
        return sorted.reverse().join("");
    } else {
        return sorted.join("");
    }
}

console.log(sortLetters('HelloWorld', true));
console.log(sortLetters('HelloWorld', false));