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
        database: 'karacsonyidiszek'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/diszeklista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT * FROM diszek order by nap', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })
 

  app.get('/ujdiszeklista', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query('SELECT * FROM ujdiszek order by nap', (err, rows, fields) => {
        if (err) throw err    
        console.log(rows)
        res.send(rows)
      })    
      connection.end()
    })

      //INSERT INTO `diszek`(`nap`, `keszharang`, `eladottharang`, `keszangyal`, `eladottangyal`, `keszfenyo`, `eladottfenyo`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]')
  app.post('/ujdiszekfelvitel', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`INSERT INTO ujdiszek  VALUES (${req.body.nap},${req.body.keszharang},${req.body.eladottharang},${req.body.keszangyal},${req.body.eladottangyal},${req.body.keszfenyo},${req.body.eladottfenyo})`, (err, rows, fields) => {
        if (err) 
          res.send("Hiba") 
        else 
        res.send("A díszek felvitele sikerült")
      })    
      connection.end()
    })

   
    
app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})


