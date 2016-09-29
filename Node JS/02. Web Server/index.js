let http = require('http')
let homePageHandler = require('./handlers/home-page')

http.createServer((req, res) => {
  homePageHandler(req, res)
}).listen(8081)

console.log('Listening on url localhost:8081...')