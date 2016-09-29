let url = require('url')
let fs = require('fs')

module.exports = (req, res) => {
  req.pathname = req.pathname || url.parse(req.url).pathname
  if (req.pathname === '/home') {
    let htmlFile = fs.readFileSync('./views/index.html')
    res.writeHead(200, 'Content-Type', 'text/html')
    res.write(htmlFile.toString())
    res.end()

    return true
  }

  return false
}
