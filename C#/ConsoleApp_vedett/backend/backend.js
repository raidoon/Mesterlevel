const express = require('express')
var cors = require('cors')
const app = express()
const port = 3000
app.use(cors())

const mysql = require('mysql')
app.use(express.json());

function kapcsolat()
{
     connection = mysql.createConnection({
        host: 'localhost',
        user: 'root',
        password: '',
        database: 'vedett'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
  console.log('Hello Borsos Lajos!')
})

app.get('/vedettallatoklista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT faj,eszmeiertek,kategoria FROM vedett', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })



app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})