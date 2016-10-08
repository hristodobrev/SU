function addRemoveElementsFromArray(commands) {
    let arr = [];
    let num = 1;

    for (let command of commands) {
        if (command === 'add') {
            arr.push(num);
        } else if (command === 'remove') {
            arr.pop();
        }

        num++;
    }

    return arr.length !== 0 ? arr.join('\n') : 'Empty';
}