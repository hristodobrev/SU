function rollDices() {
    var firstNum = getRandomNumberInRange(6);
    var secondNum = getRandomNumberInRange(6);
    var log = document.getElementById('log');

    drawNumber(firstNum, 'first-dice');
    drawNumber(secondNum, 'second-dice');

    log.innerText = 'Score: ' + (firstNum + secondNum);

    if(firstNum === secondNum) {
        log.innerText = 'Congratulations, you have rolled a pair!'
    }

    if(firstNum + secondNum === 12) {
        log.innerText = 'WOW!!! YOU HAVE WON THE JACKPOT!'
    }
}

function getRandomNumberInRange(range) {
    var randomNumber = Math.floor(Math.random() * range) + 1;

    return randomNumber;
}

function drawNumber(num, diceId) {
    var canvas = document.getElementById(diceId);
    var ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    if (num === 1) {
        var coords = [[30, 30]];
        drawOnCanvas(ctx, coords);
    } else if (num === 2) {
        var coords = [[45, 15], [15, 45]];
        drawOnCanvas(ctx, coords);
    } else if (num === 3) {
        var coords = [[45, 15], [15, 45], [30, 30]];
        drawOnCanvas(ctx, coords);
    } else if (num === 4) {
        var coords = [[45, 15], [15, 45], [15, 15], [45, 45]];
        drawOnCanvas(ctx, coords);
    } else if (num === 5) {
        var coords = [[45, 15], [15, 45], [15, 15], [45, 45], [30, 30]];
        drawOnCanvas(ctx, coords);
    } else if (num === 6) {
        var coords = [[45, 15], [15, 45], [15, 15], [45, 45], [15, 30], [45, 30]];
        drawOnCanvas(ctx, coords);
    }
}

function drawOnCanvas(ctx, coords) {
    for(var i = 0; i < coords.length; i++){
        ctx.beginPath();
        ctx.arc(coords[i][0], coords[i][1], 5, 0, Math.PI * 2, true);
        ctx.fill();
    }
}