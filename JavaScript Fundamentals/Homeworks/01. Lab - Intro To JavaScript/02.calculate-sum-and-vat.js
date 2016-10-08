function calculateSum(nums) {
    var sum = 0;
    for (var num of nums) {
        sum += Number(num);
    }
    console.log('sum = ' + sum);
    console.log('VAT = ' + sum * 0.2);
    console.log('total = ' + sum * 1.2);
}