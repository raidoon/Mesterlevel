const express = require('express')
var multer = require('multer');
var cors = require('cors')
const app = express()
const port = 3000
app.use(cors())

app.use(express.static('festmenykepek'))

const mysql = require('mysql')
app.use(express.json());

function kapcsolat()
{
     connection = mysql.createConnection({
        host: 'localhost',
        user: 'root',
        password: '',
        database: 'ehfestmenyek'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
  console.log('Hello Ecsedi!')
})
//--------------------------------------------- összes festmény
app.get('/festmenyeklista', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query('SELECT eh_id,eh_nev,eh_festo,eh_evszam,eh_szelesseg,eh_magassag,eh_kep FROM festmenyek', (err, rows, fields) => {
        if (err) throw err    
        console.log(rows)
        res.send(rows)
      })    
      connection.end()
    })
//--------------------------------------------- kiválasztott festmény törlése
app.delete('/torles', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`DELETE FROM festmenyek WHERE eh_id=${req.body.eh_id}`, (err, rows, fields) => {
        if (err) 
          res.send("Hiba") 
        else 
        res.send("A törlés sikerült")
    })    
    connection.end()
})
//-------------------------------------------- kiválasztott festmény adatainak módosítása
app.post('/modositas', (req, res) => {
    kapcsolat()
    connection.connect()    
    connection.query(`UPDATE festmenyek SET eh_nev="${req.body.eh_nev}",eh_festo="${req.body.eh_festo}",eh_evszam=${req.body.eh_evszam},eh_szelesseg=${req.body.eh_szelesseg},eh_magassag=${req.body.eh_magassag},eh_kep="${req.body.eh_kep}" WHERE eh_id=${req.body.eh_id}`, (err, rows, fields) => {
        if (err) 
          res.send("Hiba") 
        else 
        res.send("A módosítás sikerült")
    })    
    connection.end()
})
//-------------------------- INSERT INTO `festmenyek`(`eh_id`, `eh_nev`, `eh_festo`, `eh_evszam`, `eh_szelesseg`, `eh_magassag`, `eh_kep`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]')
app.post('/felvitel', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`INSERT INTO festmenyek VALUES(null,"${req.body.eh_nev}","${req.body.eh_festo}",${req.body.eh_evszam},${req.body.eh_szelesseg},${req.body.eh_magassag},"${req.body.eh_kep}")`, (err, rows, fields) => {
        if (err) 
          res.send("Hiba") 
        else 
        res.send("A felvitel sikerült")
    })    
    connection.end()
})
app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
  })