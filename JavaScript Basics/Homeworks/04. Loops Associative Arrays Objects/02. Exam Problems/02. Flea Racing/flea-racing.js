function solve(input) {
    var jumpsAllowed = (Number)(input[0]);
    var trackLength = (Number)(input[1]);
    var fleas = [];
    for(var fleaIndex = 2; fleaIndex < input.length; fleaIndex++) {
        var flea = {name: input[fleaIndex].split(', ')[0], jumps: (Number)(input[fleaIndex].split(', ')[1]), currentPosition: 1};
        fleas.unshift(flea);
    }

    var reversedFleas = fleas.reverse();

    var winner;
    for(var move = 0; move <= jumpsAllowed; move++) {
        var hasBreak = false;
        for(var fleaInd in reversedFleas) {
            var currentFlea = reversedFleas[fleaInd];
            currentFlea.currentPosition += currentFlea.jumps;
            if(currentFlea.currentPosition >= trackLength) {
                currentFlea.currentPosition = trackLength;
                winner = currentFlea;
                hasBreak = true;
                break;
            }
        }
        if(hasBreak) {
            break;
        }
    }

    if(winner == undefined) {
        var maxDistance = 0;
        for(var ind in fleas) {
            if(flea[ind].currentPosition >= maxDistance) {
                winner = flea[ind];
            }
        }
    }

    var audience = Array(trackLength + 1).join('#');
    console.log(audience);
    console.log(audience);
    for(var fleaInd in fleas) {
        var currentFlea = reversedFleas[fleaInd];
        console.log(Array(currentFlea.currentPosition).join('.') + currentFlea.name.toUpperCase()[0] + Array(trackLength + 1 - currentFlea.currentPosition).join('.'));
    }
    console.log(audience);
    console.log(audience);
    console.log('Winner: ' + winner.name);
}