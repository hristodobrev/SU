function updateResult() {
    var result = document.getElementById("result");

    var a = document.getElementById("a").value;
    var b = document.getElementById("b").value;
    var c = document.getElementById("c").value;

    var descriminant = (b * b) - (4 * a * c);

    var firstRoot;
    var secondRoot;
    var noRoots = true;

    if(descriminant >= 0) {
        firstRoot = (Math.sqrt(descriminant) - b) / (2 * a);
        secondRoot = (-Math.sqrt(descriminant) - b) / (2 * a);
        noRoots =  false;
    }

    firstRoot = Math.round(firstRoot * 1000000) / 1000000;
    secondRoot = Math.round(secondRoot * 1000000) / 1000000;

    if(noRoots) {
        result.innerHTML = "No real roots."
    }
    else {
        result.innerHTML = "x<sub>1</sub> = " + firstRoot + "<br> x<sub>2</sub> = " + secondRoot;
    }
}