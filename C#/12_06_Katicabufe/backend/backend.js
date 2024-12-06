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
        database: 'katicabufeab'
      })
}

app.get('/', (req, res) => {
  res.send('Hello World!')
})


app.get('/kategorialista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT * FROM kategoria order by kategorianev', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })
  app.get('/forgalomlista', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query('SELECT * FROM forgalom order by termek', (err, rows, fields) => {
        if (err) throw err    
        console.log(rows)
        res.send(rows)
      })    
      connection.end()
    })

    app.get('/adatoklista', (req, res) => {
      kapcsolat()
        connection.connect()    
        connection.query('SELECT * FROM kategoria INNER JOIN forgalom ON kategoriaid=forgalomkategoriaid', (err, rows, fields) => {
          if (err) throw err    
          console.log(rows)
          res.send(rows)
        })    
        connection.end()
      })

      //UPDATE `kategoria` SET `kategoriaid`='[value-1]',`kategorianev`='[value-2]' WHERE 1
      app.put('/kategoriamodositas', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query(`UPDATE kategoria SET kategorianev= "${req.body.kategorianev}" WHERE kategoriaid= ${req.body.kategoriaid}`, (err, rows, fields) => {
        if (err) 
          res.send("Hiba") 
        else 
        res.send("A kategoria módosítás sikerült")
      })    
      connection.end()
    })

    //INSERT INTO `kategoria`(`kategoriaid`, `kategorianev`) VALUES ('[value-1]','[value-2]')
    app.post('/kategoriafelvitel', (req, res) => {
      kapcsolat()
        connection.connect()    
        connection.query(`INSERT INTO kategoria VALUES (null,"${req.body.kategorianev}")`, (err, rows, fields) => {
          if (err) 
            res.send("Hiba") 
          else 
          res.send("A kategoria felvitel sikerült")
        })    
        connection.end()
      })

      //UPDATE `forgalom` SET `forgalomid`='[value-1]',`termek`='[value-2]',`vevo`='[value-3]',`forgalomkategoriaid`='[value-4]',`egyseg`='[value-5]',`nettoar`='[value-6]',`mennyiseg`='[value-7]',`kiadva`='[value-8]' WHERE 1
      app.put('/forgalommodositas', (req, res) => {
        kapcsolat()
          connection.connect()    
          connection.query(`UPDATE forgalom SET termek= "${req.body.termek}",vevo= "${req.body.vevo}",forgalomkategoriaid= ${req.body.forgalomkategoriaid},egyseg= "${req.body.egyseg}",nettoar= ${req.body.nettoar},mennyiseg= ${req.body.mennyiseg},kiadva= ${req.body.kiadva} WHERE forgalomid= ${req.body.forgalomid}`, (err, rows, fields) => {
            if (err) 
              res.send("Hiba") 
            else 
            res.send("A forgalom módosítás sikerült")
          })    
          connection.end()
        })
    app.put('/gyrosmodositas', (req, res) => {
        kapcsolat()
          connection.connect()    
          connection.query(`UPDATE forgalom  SET termek = "Gyros tál"  WHERE termek = "Gyrostál"`, (err, rows, fields) => {
            if (err) 
              res.send("Hiba") 
            else 
            res.send("A Gyrostál módosítás sikerült Gyros tál-ra")
          })    
          connection.end()
        })
        //INSERT INTO `forgalom`(`forgalomid`, `termek`, `vevo`, `forgalomkategoriaid`, `egyseg`, `nettoar`, `mennyiseg`, `kiadva`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]','[value-8]')
        app.post('/forgalomfelvitel', (req, res) => {
          kapcsolat()
            connection.connect()    
            connection.query(`INSERT INTO forgalom VALUES (null,"${req.body.termek}","${req.body.vevo}",${req.body.forgalomkategoriaid},"${req.body.egyseg}",${req.body.nettoar},${req.body.mennyiseg},${req.body.kiadva})`, (err, rows, fields) => {
              if (err) 
                res.send("Hiba") 
              else 
              res.send("A forgalom felvitel sikerült")
            })    
            connection.end()
          })

          //DELETE FROM `forgalom` WHERE 0
          app.delete('/forgalomtorles', (req, res) => {
            kapcsolat()
              connection.connect()    
              connection.query(`DELETE FROM forgalom WHERE forgalomid= ${req.body.forgalomid}`, (err, rows, fields) => {
                if (err) 
                  res.send("Hiba") 
                else 
                res.send("A forgalom törlés sikerült")
              })    
              connection.end()
            })

     

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})