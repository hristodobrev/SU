function uniqueSequences(arrays) {
    function equals(some, other) {
        if (some.length !== other.length) {
            return false;
        }

        for (let i = 0; i < other.length; i++) {
            if (some[i] instanceof Array && other[i] instanceof Array) {
                if (!some[i].equals(other[i])) {
                    return false;
                }
            } else if (some[i] !== other[i]) {
                return false;
            }
        }

        return true;
    };

    function contains(some, other) {
        for (let currentArr of some) {
            if (equals(currentArr, other)) {
                return true;
            }
        }

        return false;
    };

    let uniqueArrays = [];
    for (let arr of arrays) {
        arr = JSON.parse(arr);
        arr.sort((a, b) => {
            return Number(b) - Number(a);
        });
        if (!contains(uniqueArrays, arr)) {
            uniqueArrays.push(arr);
        }
    }

    uniqueArrays.sort((a, b) => {
        return a.length > b.length;
    });

    for (let arr of uniqueArrays) {
        console.log(`[${arr.join(', ')}]`);
    }
}

uniqueSequences([
    '[-3, -2, -1, 0, 1, 2, 3, 4]',
    '[10, 1, -17, 0, 2, 13]',
    '[4, -3, 3, -2, 2, -1, 1, 0]'
]);

// uniqueSequences([
//     '[7.14, 7.180, 7.339, 80.099]',
//     '[7.339, 80.0990, 7.140000, 7.18]',
//     '[7.339, 7.180, 7.14, 80.099]'
// ]);