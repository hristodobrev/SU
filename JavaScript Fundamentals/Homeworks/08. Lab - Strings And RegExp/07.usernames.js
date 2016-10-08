function extractUsername(emails) {
    let results = [];
    for (let email of emails) {
        let [username, domain] = email.split('@');
        username += '.';
        for (let i of domain.split('.')) {
            username += i[0];
        }

        results.push(username);
    }
    console.log(results.join(', '));
}