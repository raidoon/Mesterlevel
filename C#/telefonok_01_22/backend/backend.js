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
        database: 'telefonok'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/lista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT * FROM telefonok', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })
 



      //INSERT INTO `telefonok`(`modell`, `gyarto`, `eladasiar`, `kiadaseve`, `kepes5g`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]')
  app.post('/felvitel', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`INSERT INTO telefonok  VALUES ("${req.body.modell}","${req.body.gyarto}",${req.body.eladasiar},${req.body.kiadaseve},"${req.body.kepes5g}")`, (err, rows, fields) => {
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


