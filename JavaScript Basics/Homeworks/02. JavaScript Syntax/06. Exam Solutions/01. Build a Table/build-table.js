function solve(args) {
    var start = Number(args[0]);
    var end = Number(args[1]);

    var result = '<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n';

    for(var num = start; num <= end; num++) {
        var a = 0;
        var b = 1;
        var sum = 1;
        while(b < num) {
            sum = a + b;
            a = b;
            b = sum;
        }
        var isFib = sum === num ? 'yes' : 'no';
        result += '<tr><td>' + num + '</td><td>' + num * num + '</td><td>' + isFib + '</td></tr>\n';
    }

    result += '</table>';

    return result;
}