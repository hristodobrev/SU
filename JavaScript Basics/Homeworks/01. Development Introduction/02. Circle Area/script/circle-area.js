function typeRadius() {
    var radius = prompt("Please type a radius", "7");
    calcCircleArea(radius);
}

function calcCircleArea(r) {
    var area = Math.PI * r * r;
    document.getElementsByTagName("p")[0].innerHTML += "r = " + r + "; " + "area = " + area + "<br>";
}