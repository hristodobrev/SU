function solve(input) {
    var start = Number(input[0]);
    var end = Number(input[1]);
    console.log('<ul>');

    for(var num = start; num <= end; num++) {
        if (!isDoubleNum(num)) {
            console.log("<li><span class='num'>" + num + "</span></li>");
        }
        else {
            console.log("<li>" +
                "<span class='rakiya'>" + num + "</span>" +
                "<a href=\"view.php?id=" + num +">View</a>" +
                "</li>");
        }
    }

    console.log('</ul>');

    function isDoubleNum(num) {
        var numStr = '' + num;
        var existingPairs = {};
        for(var i = 1; i < numStr.length; i++) {
            var pair = numStr.substr(i - 1, 2);
            if(existingPairs[pair]) {
                if (i - existingPairs[pair] >= 2) {
                    return true;
                }
            } else {
                existingPairs[pair] = i;
            }
        }
        return false;
    }
}