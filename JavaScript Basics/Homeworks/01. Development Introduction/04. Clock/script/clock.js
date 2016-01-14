var counter = 0;

function updateTime() {
    var time = new Date();
    var hours = time.getHours();
    var minutes = time.getMinutes();
    var seconds = time.getSeconds();

    if (hours < 10) {
        hours = "0" + hours;
    }
    if (minutes < 10) {
        minutes = "0" + minutes;
    }
    if (seconds < 10) {
        seconds = "0" + seconds;
    }

    document.getElementById("clock").innerHTML = hours + ":" + minutes + ":" + seconds;
}

var clock = setInterval(updateTime, 1000);