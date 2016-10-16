function ajaxRequestValidator(lines) {
    let hashPattern = lines[lines.length - 1];

    for (let i = 0; i < lines.length - 1; i += 3) {
        let code = 200;
        let methodTokens = lines[i].split(': ');
        let credentialsTokens = lines[i + 1].split(': ');
        let contentTokens = lines[i + 2].split(': ');
        let method = methodTokens[1];
        let credentials = credentialsTokens[1];
        let content = contentTokens[1];
        let credentialRegex = /^[A-Za-z0-9]+$/;
        let contentRegex = /^[A-Za-z0-9\.]+$/;
        let charsCount = new Map();
        for (let char of credentials.split(' ')[1]) {
            if (!charsCount.has(char)) {
                charsCount.set(char, 1);
            } else {
                charsCount.set(char, charsCount.get(char) + 1);
            }
        }

        let isValid = false;
        let hashRegex = /([0-9]+)([A-Za-z])/g;
        let match;
        while(match = hashRegex.exec(hashPattern)) {
            let char = match[2];
            let count = Number(match[1]);
            if (charsCount.get(char) === Number(count)) {
                isValid = true;
                break;
            }
        }

        if (!credentialRegex.test(credentials.split(' ')[1]) || !contentRegex.test(content) || methodTokens[0] != 'Method' ||
        credentialsTokens[0] != 'Credentials' || contentTokens[0] != 'Content' || (
            method != 'GET' && method != 'POST' && method != 'PUT' && method != 'DELETE'
            )) {
            code = 400;
        } else if (credentials.split(/\s+/)[0] === 'Basic' && method !== 'GET') {
            code = 401;
        }  else if (!isValid) {
            code = 403;
        }

        if (code === 200) {
            console.log(`Response-Method:${method}&Code:200&Header:${credentials.split(' ')[1]}`);
        } else if (code === 400) {
            console.log('Response-Code:400');
        } else if (code === 401) {
            console.log(`Response-Method:${method}&Code:401`);
        } else {
            console.log(`Response–Method:${method}&Code:403`);
        }
    }
}

ajaxRequestValidator([
    'Method: GET',
    'Credentials: Basic qafAGFtaatgvaaacccccaaaaa',
    'Content: users.asd.1782452.278asd',
    '10a5c'
]);