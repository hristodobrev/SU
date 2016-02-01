function solve(input) {
    var maxSum = Number.NEGATIVE_INFINITY;
    for(var index = 2; index < input.length - 1; index++) {
        var line = input[index];
        var matches = line.match(/<td>(.*?)<\/td>/g);
        var sum = 0, values = [];
        for(var matchIndex = 1; matchIndex < matches.length; matchIndex++) {
            var currentMatch = matches[matchIndex];
            var value = currentMatch.substring(4).substring(0, currentMatch.length - 9);
            var num = Number(value.trim());
            if(!isNaN(num)) {
                sum += num;
                values.push(value);
            }
        }
        if(sum > maxSum && values.length > 0) {
            maxSum = sum;
            var output = sum + ' = ' + values.join(' + ');
        }
    }

    if(maxSum != Number.NEGATIVE_INFINITY) {
        console.log(output);
    } else {
        console.log('no data');
    }
}

solve(['<table>',
        '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
        '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
        '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
        '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
        '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
    '</table>']);