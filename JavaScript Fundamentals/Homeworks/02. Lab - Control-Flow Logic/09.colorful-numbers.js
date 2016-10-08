function colorfulNumbers([n]) {
    console.log('<ul>');
    for (let i = 1; i <= n; i++) {
        console.log('<li><span style="color:' + (i % 2 == 1 ? 'green' : 'blue') + '">' + i + '</span></li>');
    }
    console.log('</ul>');
}