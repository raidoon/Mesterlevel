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
        database: 'dolgozokab'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
})
app.get('/reszleglista', (req, res) => {
    kapcsolat()
    connection.connect()
    connection.query('SELECT * from reszleg order by reszleg', (err, rows, fields) => {
        if (err) throw err
        console.log(rows)
        res.send(rows)
  })
connection.end()
})
app.get('/dolgozolista', (req, res) => {
    kapcsolat()
    connection.connect()
    connection.query('SELECT * from dolgozo order by nev', (err, rows, fields) => {
        if (err) throw err
        console.log(rows)
        res.send(rows)
  })
connection.end()
})
app.get('/adatoklista', (req, res) => {
  kapcsolat()
  connection.connect()
  connection.query('SELECT * from reszleg inner join dolgozo on reszlegid=dolgozoreszlegid', (err, rows, fields) => {
      if (err) throw err
      console.log(rows)
      res.send(rows)
})
connection.end()
})
app.put('/reszlegmodositas', (req, res) => {
  kapcsolat()
  connection.connect()
  connection.query(`update reszleg set reszleg="${req.body.reszleg}" where reszlegid=${req.body.reszlegid}`, (err, rows, fields) => {
      if (err)
      res.send("Hiba")
    else
    res.send("A részleg módosítás sikerült")
})
connection.end()
})
app.post('/reszlegfelvitel', (req, res) => {
  kapcsolat()
  connection.connect()
  connection.query(`insert into reszleg velues (null,"${req.body.reszleg}")`, (err, rows, fields) => {
      if (err)
      res.send("Hiba")
    else
    res.send("A részleg felvétele sikerült")
})
connection.end()
})
app.put('/dolgozomodositas', (req, res) => {
  kapcsolat()
  connection.connect()
  connection.query(`update dolgozo set nev="${req.body.nev}",neme="${req.body.neme}",dolgozoreszlegid=${req.body.dolgozoreszlegid},belepes=${req.body.belepes},ber=${req.body.ber} where dolgozoid=${req.body.dolgozoid}`, (err, rows, fields) => {
      if (err)
      res.send("Hiba")
    else
    res.send("A dolgozó módosítás sikerült")
})
connection.end()
})
app.post('/dolgozofelvitel', (req, res) => {
  kapcsolat()
  connection.connect()
  connection.query(`insert into dolgozo velues (null,"${req.body.nev}","${req.body.neme}",${req.body.dolgozoreszlegid},${req.body.belepes},${req.body.ber})`, (err, rows, fields) => {
      if (err)
      res.send("Hiba")
    else
    res.send("A dolgozó felvétel sikerült")
})
connection.end()
})
app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})