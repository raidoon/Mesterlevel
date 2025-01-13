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
        database: 'movies'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/filmeklista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT * FROM movies', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })
 



      //INSERT INTO `movies`(`id`, `nev`, `kiadaseve`, `bevetel`, `ertekeles`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]')
  app.post('/ujfilmfelvitel', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`INSERT INTO movies  VALUES (null,"${req.body.nev}",${req.body.kiadaseve},${req.body.bevetel},${req.body.ertekeles})`, (err, rows, fields) => {
        if (err) 
          res.send("Hiba") 
        else 
        res.send("A film felvitele sikerült")
      })    
      connection.end()
    })

   
    
app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})


