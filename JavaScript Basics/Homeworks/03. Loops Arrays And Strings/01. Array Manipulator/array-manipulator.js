function manipulateArray(arr) {
    var filteredNumbers = arr.filter(function(num) {
        return typeof num == 'number';
    });

    var map = {};
    var mostFrequentNumber = filteredNumbers[0];
    var maxCount = 1;
    for(var index = 0; index < filteredNumbers.length; index++) {
        var element = filteredNumbers[index];
        if(map[element] == null) {
            map[element] = 1;
        }
        else {
            map[element]++;
        }
        if(map[element] > maxCount) {
            maxCount = map[element];
            mostFrequentNumber = element;
        }
    }

    var minNumber = Math.min.apply(Math, filteredNumbers);
    var maxNumber = Math.max.apply(Math, filteredNumbers);

    var sortedNumbers = filteredNumbers.sort(function(a, b){
        return a < b;
    });

    console.log('Min number: ' + minNumber);
    console.log('Max number: ' + maxNumber);
    console.log('Most frequent number: ' + mostFrequentNumber);
    console.log(sortedNumbers);
}