function solveMee(input) {
    console.log('<table>');
    console.log('<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');
    var splited = input.split('\n');
    var regex = /<tr><td>.+?<\/td><td>(.+?)<\/td><td>.+?<\/td><\/tr>/;
    var objects = new Array();
    var match;
    for (var i = 2; i < splited.length; i++) {
        match = regex.exec(splited[i]);
        var priceMatch = match[1];
        var object = {'price' : priceMatch, 'textValue' : splited[i]};
        objects[i] = object;
    }

    objects.sort(function (a, b) {
        return a.priceMatch > b.priceMatch;
    });

    for (var index in objects) {
        console.log(objects[index].textValue);
    }

    console.log('</table>');
}