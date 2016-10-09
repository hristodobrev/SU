function usernames(usernamesArr) {
    let uniqueUsernames = [];
    for (let username of usernamesArr) {
        if (uniqueUsernames.indexOf(username) === -1) {
            uniqueUsernames.push(username);
        }
    }

    uniqueUsernames.sort((a, b) => {
        if (a.length > b.length) return 1;
        if (a.length < b.length) return -1;
        if (a > b) return 1;
        return -1;
    });

    console.log(uniqueUsernames.join('\n'));
}

usernames([
    'Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot'
]);