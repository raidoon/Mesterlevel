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
        database: 'berek2024'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/reszlegek_lekerdez', (req, res) => {
    kapcsolat()
    connection.connect()
    connection.query('SELECT * from reszlegek', (err, rows, fields) => {
        if (err) throw err
        console.log(rows)
        res.send(rows)
  })
connection.end()
})

app.get('/dolgozok_lekerdez', (req, res) => {
    kapcsolat()
    connection.connect()
    connection.query('SELECT dolgozoid,nev,neme,reszlegid,reszleg,belepeseve,ber from dolgozok inner join reszlegek on reszlegid=berekreszleg', (err, rows, fields) => {
        if (err) throw err
        console.log(rows)
        res.send(rows)
  })
connection.end()
})

app.get('/keresek/:kereses', (req, res) => {
    kapcsolat()
    connection.connect()
    connection.query(`SELECT dolgozoid,nev,neme,reszlegid,reszleg,belepeseve,ber from dolgozok inner join reszlegek on reszlegid=berekreszleg where nev like "%${req.params.kereses}%" or neme like "%${req.params.kereses}%" or reszleg like "%${req.params.kereses}%" or belepeseve like "%${req.params.kereses}%"`, (err, rows, fields) => {
        if (err) throw err
        console.log(rows)
        res.send(rows)
  })
connection.end()
})
app.get('/szures/:kereses', (req, res) => {
    kapcsolat()
    connection.connect()
    connection.query(`SELECT dolgozoid,nev,neme,reszlegid,reszleg,belepeseve,ber from dolgozok inner join reszlegek on reszlegid=berekreszleg where  berekreszleg=${req.params.kereses} `, (err, rows, fields) => {
        if (err) throw err
        console.log(rows)
        res.send(rows)
  })
connection.end()
})


app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})