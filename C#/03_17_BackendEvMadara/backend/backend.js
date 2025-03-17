const express = require('express')
var cors = require('cors')
var mysql = require('mysql')
const app = express()
const port = 3000

app.use(cors())
app.use(express.json())
app.use(express.static('kepek'))

var connection

function kapcsolat(){
    connection = mysql.createConnection({
      host: 'localhost',
      user: 'root',
      password: '',
      database: 'vedettmadarakab'
    })

    connection.connect()
}

app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/rendlista', (req, res) => {
  kapcsolat()
  connection.query('select * from rend', (err, rows)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{
        console.log(rows)
        res.status(200).send(rows)
      }    
  })
 connection.end()
 })

 app.get('/csaladlista', (req, res) => {
  kapcsolat()
  connection.query('select * from csalad order by csalad_nev', (err, rows)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{
        console.log(rows)
        res.status(200).send(rows)
      }    
  })
 connection.end()
 })
 
 app.get('/vedettmadaraklista', (req, res) => {
  kapcsolat()
  connection.query('select faj_id,rend_nev,csalad_nev,faj_nev,faj_latin,faj_ertek,faj_evszam from faj inner join csalad on faj.faj_csaladid=csalad.csalad_id inner join rend on csalad.csalad_rendid=rend.rend_id order by faj_nev', (err, rows)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{
        console.log(rows)
        res.status(200).send(rows)
      }    
  })
 connection.end()
 })
 app.post('/kereses', (req, res) => {
  kapcsolat()
  const keresettadat = `%${req.body.keresettadatok}%`;
  connection.query('select faj_id,rend_nev,csalad_nev,faj_nev,faj_latin,faj_ertek,faj_evszam from rend inner join csalad on rend.rend_id=csalad.csalad_rendid inner join faj on csalad.csalad_id=faj.faj_csaladid where faj_nev like ? or csalad_nev like ? or rend_nev like ?',[keresettadat,keresettadat,keresettadat],  (err,rows)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{        
        res.status(200).send(rows)
      }    
  })
 connection.end()
 })

 app.post('/keresesmodositas', (req, res) => {
  kapcsolat()
  const {faj_id}=req.body
  connection.query('select faj_id,rend_nev,csalad_nev,faj_nev,faj_latin,faj_ertek,faj_evszam from rend inner join csalad on rend.rend_id=csalad.csalad_rendid inner join faj on csalad.csalad_id=faj.faj_csaladid where faj_id=?',[faj_id],  (err,rows)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{        
        res.status(200).send(rows)
      }    
  })
 connection.end()
 })

 app.post('/csaladszures', (req, res) => {
  kapcsolat()
  const {csalad_nev}=req.body
  connection.query('select faj_id,rend_nev,csalad_nev,faj_nev,faj_latin,faj_ertek,faj_evszam from rend inner join csalad on rend.rend_id=csalad.csalad_rendid inner join faj on csalad.csalad_id=faj.faj_csaladid where csalad_nev like ? order by faj_nev',[csalad_nev],  (err,rows)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{        
        res.status(200).send(rows)
      }    
  })
 connection.end()
 })

 
//SELECT faj_id,faj_nev,faj_latin,faj_csaladid,faj_ertek,faj_evszam FROM faj
 app.post('/felvitel', (req, res) => {
  kapcsolat()
  console.log(`${req.body.faj_nev},${req.body.faj_latin},${req.body.faj_csaladid},${req.body.faj_ertek},${req.body.faj_evszam}`)
  const {faj_nev,faj_latin,faj_csaladid,faj_ertek,faj_evszam}=req.body
  connection.query('INSERT INTO faj(faj_id, faj_nev, faj_latin, faj_csaladid, faj_ertek, faj_evszam) VALUES (null, ?,?,?,?,?)',[faj_nev,faj_latin,faj_csaladid,faj_ertek,faj_evszam],  (err)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{        
        res.status(200).send("Sikeres felvitel")
      }    
  })
 connection.end()
 })

 app.put('/modositas', (req, res) => {
  kapcsolat()
  console.log(`${req.body.faj_ertek},${req.body.faj_id}`)
  const {faj_nev,faj_latin,faj_csaladid,faj_ertek,faj_evszam,faj_id}=req.body
  connection.query('UPDATE faj SET faj_nev=?,faj_latin=?,faj_csaladid=?, faj_ertek=?, faj_evszam=? WHERE faj_id=?',[faj_nev,faj_latin,faj_csaladid,faj_ertek,faj_evszam,faj_id],  (err)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{        
        res.status(200).send("Sikeres módosítás")
      }    
  })
 connection.end()
 })
 
 app.delete('/torles', (req, res) => {
  kapcsolat()
  console.log(`,${req.body.faj_id}`)
  const {faj_id}=req.body
  connection.query(' DELETE FROM faj WHERE faj_id=?',[faj_id],  (err)=> {
    if (err) 
      {
        console.log(err);
        res.status(500).send("Hiba")
      }
      else{        
        res.status(200).send("Sikeres törlés!")
      }    
  })
 connection.end()
 })

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})