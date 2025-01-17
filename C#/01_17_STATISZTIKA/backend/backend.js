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
        database: 'statisztika'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/lista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT * FROM statisztika', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })
 



      //INSERT INTO `statisztika`(`Azonosito`, `Atlag`, `Hianyzas`, `Tavolsag`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]')
  app.post('/felvitel', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`INSERT INTO statisztika  VALUES ("${req.body.Azonosito}",${req.body.Atlag},${req.body.Hianyzas},${req.body.Tavolsag})`, (err, rows, fields) => {
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


