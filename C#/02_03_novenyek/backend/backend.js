const express = require('express');
var multer = require('multer');
var cors = require('cors');
const mysql = require('mysql');
const app = express();
const port = 3000;
app.use(cors());
app.use(express.json());
app.use(express.static('kepek'));

function kapcsolat()
{
     connection = mysql.createConnection({
        host: 'localhost',
        user: 'root',
        password: '',
        database: 'novenyek'
      })
}
app.get('/lista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT * FROM novenyek', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })
  app.post('/felvitel', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`INSERT INTO novenyek  VALUES ("${req.body.nev}","${req.body.tipus}",${req.body.ar},"${req.body.vizigeny}")`, (err, rows, fields) => {
        if (err) 
          res.send("Hiba") 
        else 
        res.send("Az adatok felvitele sikerült")
      })    
      connection.end()
    })
app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})