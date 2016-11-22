let data = require('./data');

function sort(property) {
    let sortedArr = data.sort((a, b) => {
        if (a[property] > b[property]) {
            return 1;
        } else if (a[property] < b[property]) {
            return -1;
        } else {
            return 0;
        }
    });
    return sortedArr;
}

function filter(property, value) {
    let filtered = data.filter(a => a[property] == value);
    return filtered;
}

result.sort = sort;
result.filter = filter;