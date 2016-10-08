function modifyAverage([num]) {
    while (getAverage() <= 5) {
        num += '9';
    }

    function getAverage() {
        num += '';
        let sum = 0;
        for (let i = 0; i < num.length; i++) {
            sum += Number(num[i]);
        }
        return sum / num.length;
    }

    console.log(num);
}