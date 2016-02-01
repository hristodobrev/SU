function solve(input) {
    var numbers = input.map(Number);

    console.log('<table>\n<tr><th>Price</th><th>Trend</th></tr>');

    var previous = numbers.firstChild;
    for (var index in numbers) {
        var current = numbers[index].toFixed(2);
        if(previous == undefined) {
            previous = current;
        }

        if(current < previous) {
            console.log('<tr><td>' + current + '</td><td><img src="down.png"/></td></td>');
        } else if (current > previous) {
            console.log('<tr><td>' + current + '</td><td><img src="up.png"/></td></td>');
        } else {
            console.log('<tr><td>' + current + '</td><td><img src="fixed.png"/></td></td>');
        }

        previous = current;
    }

    console.log('</table>');
}