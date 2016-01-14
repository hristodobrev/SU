function calcCylinderVol(arr) {
    var radius = arr[0];
    var height = arr[1];

    var volume = radius * radius * Math.PI * height;

    return Math.round(volume * 1000) / 1000;
}

function element(id) {
    return document.getElementById(id);
}