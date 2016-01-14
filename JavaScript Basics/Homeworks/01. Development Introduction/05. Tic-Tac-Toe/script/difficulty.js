var difficulty = "Medium";

function changeDifficulty() {
    writeOnLog("Let's stay on medium for now. :D");
}

function changeDifficultyBACKUP() {
    var button = document.getElementById("difficultyButton");

    if (difficulty == "Easy") {
        difficulty = "Medium";
    }
    else if (difficulty == "Medium") {
        difficulty = "Hard";
    }
    else {
        difficulty = "Easy";
    }

    button.innerHTML = difficulty;
}

function writeOnLog(message) {
    var log = document.getElementById("log");
    log.innerHTML = message;
}

var clock = setInterval(updateTime, 1000);

function updateTime() {
    var time = new Date("January, 8, 2016, 16:00:00");

    var difInMiliseconds = Math.abs(time - new Date());

    var dif = new Date(difInMiliseconds);

    var hours = dif.getHours() - 2;
    var minutes = dif.getMinutes();
    var seconds = dif.getSeconds();

    if (hours < 10) {
        hours = "0" + hours;
    }
    if (minutes < 10) {
        minutes = "0" + minutes;
    }
    if (seconds < 10) {
        seconds = "0" + seconds;
    }

    document.getElementById("clock").innerHTML = "Time left: " + hours + ":" + minutes + ":" + seconds;
}