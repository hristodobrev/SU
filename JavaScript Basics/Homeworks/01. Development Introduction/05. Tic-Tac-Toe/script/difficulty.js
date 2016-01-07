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