class MailBox {
    constructor() {
        this._messages = [];
    }

    get messageCount() {
        return this._messages.length;
    }

    addMessage(subject, text) {
        let msg = {subject, text};
        this._messages.push(msg);

        return this;
    }

    deleteAllMessages() {
        this._messages = [];
    }

    findBySubject(substr) {
        let messages = [];
        for (let msg of this._messages) {
            if (msg.subject.indexOf(substr) != -1) {
                messages.push(msg);
            }
        }

        return messages;
    }

    toString() {
        if (this._messages.length == 0) {
            return '* (empty mailbox)';
        }

        let result = '';
        for (let msg of this._messages) {
            result += `* ${msg.subject} ${msg.text}\n`;
        }

        return result;
    }
}

let mailbox = new MailBox();
console.log(mailbox.toString());
mailbox.addMessage('Test', 'Some text');
mailbox.addMessage('Another Test', 'Some another text');
mailbox.addMessage('Subject', 'Text');
console.log(mailbox.messageCount);
console.log(mailbox.toString());

console.log();
console.log(mailbox.findBySubject('Test'));