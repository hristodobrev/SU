function commandProcessor(commands) {
    let processor = (function () {
        let value = '';

        return {
            append: function (str) {
                value += str;
            },
            removeStart: function (count) {
                value = value.substr(count);
            },
            removeEnd: function (count) {
                value = value.substr(0, value.length - count);
            },
            print: function () {
                console.log(value);
            }
        };
    })();

    for (let commandTokens of commands) {
        let [command, arg] = commandTokens.split(' ');
        processor[command](arg);
    }
}

commandProcessor(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']);