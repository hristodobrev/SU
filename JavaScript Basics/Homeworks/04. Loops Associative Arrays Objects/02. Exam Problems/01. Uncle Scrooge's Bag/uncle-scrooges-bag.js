function solve(input) {
    var sum = 0;
    for(var index in input) {
        var coin = input[index].split(' ')[0];
        var coinValue = (Number)(input[index].split(' ')[1]);

        if(coin.toLowerCase() == 'coin' && coinValue % 1 == 0 && coinValue > 0) {
            sum += coinValue;
        }
    }

    var gold = Math.floor(sum / 100);
    var silver = Math.floor((sum - gold * 100) / 10);
    var bronze = (sum - gold * 100) - silver * 10;
    console.log('gold : ' + gold);
    console.log('silver : ' + silver);
    console.log('bronze : ' + bronze);
}