function listProcessor(commands) {
    let processor = (function () {
        let list = [];

        let add = (word) => {
            list.push(word);
        };
        let remove = (word) => {
            list = list.filter(x => x != word);
        };
        let print = () => {
            console.log(list.join(','));
        };

        return {add, remove, print};
    })();

    for (let commandTokens of commands) {
        let [command, arg] = commandTokens.split(' ');
        processor[command](arg);
    }
}

listProcessor(['add pesho', 'add gosho', 'add pesho', 'remove pesho','print'])