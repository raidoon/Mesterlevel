const express = require('express')
const mysql = require('mysql')
var cors = require('cors')
const app = express()
const port = 3000
app.use(express.json())
app.use(cors())

var connection;
function kapcsolat() {
  connection = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'termek2024'
  })
  connection.connect()
}

app.get('/', (req, res) => {
  res.send('Hello World!')
})

//-----------------------------------------------------tipus lekérdezése
app.get('/tipusLekerdez', (req, res) => {
  kapcsolat()
  connection.query('SELECT * from tipus', (err, rows, fields) => {
    if (err) throw err

    console.log(rows)
    res.send(rows)
  })
  connection.end()
})
//----------------------------------------------------termek lekerdezese
app.get('/termekLekerdez', (req, res) => {
  kapcsolat()
  connection.query('SELECT * from termek', (err, rows, fields) => {
    if (err) throw err

    console.log(rows)
    res.send(rows)
  })
  connection.end()
})
//----------------------------------------------200Ft-nál drágább termékek
app.get('/termekLekerdez200', (req, res) => {
  kapcsolat()
  connection.query('SELECT * from termek where termek.termek_ar>200', (err, rows, fields) => {
    if (err) throw err

    console.log(rows)
    res.send(rows)
  })
  connection.end()
})
//---------------------------------------------összes termék : neve, ara, típusának neve
app.get('/termekTipusLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
        SELECT * from termek 
        inner join tipus 
        on termek.termek_tipus=tipus.tipus_id`, (err, rows, fields) => {
    if (err) throw err

    console.log(rows)
    res.send(rows)
  })
  connection.end()
})
//--------------------------------------péksütemények adatai

app.get('/peksutiLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
      SELECT * from termek 
      inner join tipus 
      on termek.termek_tipus=tipus.tipus_id
       where tipus.tipus_nev = "pékáru";`, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      //res.status(500)
      //res.send("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      //res.status(200)
      //res.send(rows)
      res.status(200).send(rows)
    }


  })
  connection.end()
})
//--------------------------------------t betűt tartalmazó termékek adatai
app.get('/tbetusLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * from termek 
      inner join tipus 
      on termek.termek_tipus=tipus.tipus_id
       where termek.termek_nev LIKE "%t%";
      `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})
//--------------------------hibás végpont
app.get('/hibas', (req, res) => {
  kapcsolat()
  connection.query(`
  SELECT hülyeség
      `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})
//-------------------------------------post-os lekérdezés
app.post('/dragabbLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    where termek.termek_ar>${req.body.bevitel1}`, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})
//-------------------------------KÉT ÁR KÖZÖTTI
app.post('/kozottLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    where termek.termek_ar BETWEEN ${req.body.bevitel1} AND ${req.body.bevitel2}`, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})
//-----------------------------------------BETŰT LEKÉRDEZ
app.post('/betuLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    where termek.termek_nev LIKE "%${req.body.bevitel1}%"`, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})
//-------------------------------------DRÁGÁBBAK LEKÉRDEZÉSE 2-ES
app.post('/dragabbLekerdez2', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    where termek.termek_ar>?`, [req.body.bevitel1], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})
//--------------------------------------------két érték között lekérdez, ? használatával
app.post('/kozottLekerdez2', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    where termek.termek_ar>? and termek.termek_ar<?`, [req.body.bevitel1, req.body.bevitel2], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})
//---------------------------termék nevében benne van egy betű és ára határ feletti, típusat is írjuk
app.post('/betuArLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    inner join tipus 
    on termek.termek_tipus=tipus.tipus_id
    where termek.termek_ar>${req.body.bevitel1} 
    and termek.termek_nev like "%${req.body.bevitel2}%"`, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})

//-------------------------------------------------termék típus-ra keress rá

app.post('/tipusRakerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    inner join tipus 
    on termek.termek_tipus=tipus.tipus_id
    where tipus.tipus_nev like "%${req.body.bevitel1}%"
    `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})

//--------------------------------------------------------kérdezzük le az átlagát

app.get('/atlagLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT AVG(termek.termek_ar) AS Atlag
    FROM termek
    `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})

//------------------------------------------------------betű keresés mindenhol

app.post('/mindentLekerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * 
    from termek 
    inner join tipus 
    on termek.termek_tipus=tipus.tipus_id
    where tipus.tipus_nev like ? OR termek.termek_nev like ?
    
    `, [req.body.bevitel1, req.body.bevitel1], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})

//-----------------------------------------------------Csoportosítás termék típusonként
app.get('/tipusCsoportosit', (req, res) => {
  kapcsolat()
  connection.query(`
      SELECT tipus.tipus_nev, COUNT(termek.termek_id) AS Darabszam
      FROM termek
      INNER JOIN tipus
      ON tipus.tipus_id=termek.termek_tipus
      GROUP BY termek_tipus;
    
    `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})

//------------------------------------------------------Tipus felvitele kérdőjellel


app.post('/tipusFelvitel2', (req, res) => {
  kapcsolat()
  connection.query(`
    INSERT INTO tipus VALUES (NULL, ? );
    
    `, [req.body.bevitel1], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres felvitel!")
      res.status(200).send("Sikeres felvitel!")
    }
  })
  connection.end()
})

//------------------------------------------------------Ugyanez kérdőjelesen

app.post('/tipusFelvitel', (req, res) => {
  kapcsolat()
  connection.query(`
    INSERT INTO tipus VALUES (NULL,"${req.body.bevitel1}");
    
    `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres felvitel!")
      res.status(200).send("Sikeres felvitel!")
    }
  })
  connection.end()
})


//---------------------------------------------------------Termék felvitele

app.post('/termekFelvitel', (req, res) => {
  kapcsolat()
  connection.query(`
    INSERT INTO termek VALUES (NULL, ?, ?, ? );
    
    `, [req.body.bevitel1, req.body.bevitel2, req.body.bevitel3], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres felvitel!")
      res.status(200).send("Sikeres felvitel!")
    }
  })
  connection.end()
})

//--------------------------------------------------------------Nem kérdőjellel

app.post('/termekFelvitel2', (req, res) => {
  kapcsolat()
  connection.query(`
    INSERT INTO termek VALUES (NULL, "${req.body.bevitel1}", ${req.body.bevitel2}, ${req.body.bevitel3} );
    
    `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres felvitel!")
      res.status(200).send("Sikeres felvitel!")
    }
  })
  connection.end()
})
//--------------------------------------------------------- típus törlése
//
app.delete('/tipusTorles', (req, res) => {
  kapcsolat()
  connection.query(`
    DELETE FROM tipus WHERE tipus.tipus_id = ?
    `,[req.body.bevitel1], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres törlés!")
      res.status(200).send("Sikeres törlés!")
    }
  })
  connection.end()
})
//------------------------------------------------termék törlés
app.delete('/termekTorles', (req, res) => {
  kapcsolat()
  connection.query(`
    DELETE FROM termek WHERE termek.termek_id = ?
    `,[req.body.bevitel1], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres törlés!")
      res.status(200).send("Sikeres törlés!")
    }
  })
  connection.end()
})
//-----------------------------------------10000 feletti törlés
app.post('/dragaTorles', (req, res) => {
  kapcsolat()
  connection.query(`
    DELETE FROM termek WHERE termek.termek_ar > ?
    `,[req.body.bevitel1], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres törlés!")
      res.status(200).send("Sikeres törlés!")
    }
  })
  connection.end()
})
//---------------------------------------------------update termékek ára növekszik 10%-al
app.put('/arModosit', (req, res) => {
  kapcsolat()
  connection.query(`
    UPDATE termek SET termek_ar = termek_ar * 1.1; 
    `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres módosítás!")
      res.status(200).send("Sikeres módosítás!")
    }
  })
  connection.end()
})
//--------------------------------------------------csak egy termék átírása név & ár
app.put('/termekModosit', (req, res) => {
  kapcsolat()
  connection.query(`
    UPDATE termek SET termek_nev = ?, termek_ar = ? where termek_id = ?; 
    `,[req.body.bevitel1, req.body.bevitel2, req.body.bevitel3], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres módosítás!")
      res.status(200).send("Sikeres módosítás!")
    }
  })
  connection.end()
})
//----------------------------------------------- adott típusnevű termékek árának csökkentése 10%-al
app.put('/tipusarModosit', (req, res) => {
  kapcsolat()
  connection.query(`
    UPDATE termek SET termek_ar = termek_ar * 0.9 where termek.termek_tipus = (SELECT tipus.tipus_id FROM tipus WHERE tipus.tipus_nev = ?); 
    `,[req.body.bevitel1], (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      console.log(err)
      res.status(500).send("Hiba")
    }
    else {
      console.log("Sikeres módosítás!")
      res.status(200).send("Sikeres módosítás!")
    }
  })
  connection.end()
})






app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})

