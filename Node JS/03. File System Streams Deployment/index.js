let http = require('http')
let fs = require('fs')

let port = 8081;

http.createServer((req, res) => {
    if (req.method === 'GET') {
        let body = fs.readFileSync('./index.html');
        
    }
}).listen(port);

console.log('Listening on localhost:' + port);