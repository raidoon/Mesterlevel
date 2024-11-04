const express = require('express')
var multer = require('multer');
var cors = require('cors')
const app = express()
const port = 3000
app.use(cors())

app.use(express.static('hirdeteskepek'))

const mysql = require('mysql')
app.use(express.json());

function kapcsolat()
{
     connection = mysql.createConnection({
        host: 'localhost',
        user: 'root',
        password: '',
        database: 'hirdetesekab'
      })
}
app.get('/', (req, res) => {
  res.send('Hello World!')
  console.log('Hello Borsos Lajos!')
})

app.get('/hirdeteseklista', (req, res) => {
  kapcsolat()
    connection.connect()    
    connection.query('SELECT hirdetesekid,szobaszam,szelesseg,hosszusag,emelet,alapterulet,hirdetesszoveg,tehermentes,kepnev,hirdetesdatum,hirdetoid,hirdetonev,hirdetotelefon,kategoriaid,kategorianev FROM kategoriak INNER JOIN hirdetesek ON kategoriaid=kategoriakid INNER JOIN hirdetok ON hirdetoid=hirdetokid', (err, rows, fields) => {
      if (err) throw err    
      console.log(rows)
      res.send(rows)
    })    
    connection.end()
  })
  app.get('/kategoriaklista', (req, res) => {
    kapcsolat()
      connection.connect()    
      connection.query('SELECT kategoriakid,kategorianev FROM kategoriak order by kategorianev', (err, rows, fields) => {
        if (err) throw err    
        console.log(rows)
        res.send(rows)
      })    
      connection.end()
    })
    app.get('/hirdetoklista', (req, res) => {
      kapcsolat()
        connection.connect()    
        connection.query('SELECT hirdetokid,hirdetonev,hirdetotelefon FROM hirdetok order by hirdetonev', (err, rows, fields) => {
          if (err) throw err    
          console.log(rows)
          res.send(rows)
        })    
        connection.end()
      })

    //INSERT INTO `hirdetesek`(`hirdetesekid`, `szobaszam`, `szelesseg`, `hosszusag`, `emelet`, `alapterulet`, `hirdetesszoveg`, `tehermentes`, `kepnev`, `hirdetesdatum`, `hirdetoid`, `kategoriaid`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]','[value-8]','[value-9]','[value-10]','[value-11]','[value-12]')
    app.post('/felvitel', (req, res) => {
      kapcsolat()
        connection.connect()    
        connection.query(`INSERT INTO hirdetesek VALUES(${req.body.hirdetesekid},${req.body.szobaszam},${req.body.szelesseg},${req.body.hosszusag},${req.body.emelet},${req.body.alapterulet},"${req.body.hirdetesszoveg}","${req.body.tehermentes}","${req.body.kepnev}","${req.body.hirdetesdatum}",${req.body.hirdetoid},${req.body.kategoriaid})`, (err, rows, fields) => {
          if (err) 
            res.send("Hiba") 
          else 
          res.send("A felvitel sikerült")
        })    
        connection.end()
      })
      //DELETE FROM `hirdetesek` WHERE 0
      app.delete('/torles', (req, res) => {
        kapcsolat()
          connection.connect()    
          connection.query(`DELETE FROM hirdetesek WHERE hirdetesekid=${req.body.hirdetesekid}`, (err, rows, fields) => {
            if (err) 
              res.send("Hiba") 
            else 
            res.send("A törlés sikerült")
          })    
          connection.end()
        })
//UPDATE `hirdetesek` SET `hirdetesekid`='[value-1]',`szobaszam`='[value-2]',`szelesseg`='[value-3]',`hosszusag`='[value-4]',`emelet`='[value-5]',`alapterulet`='[value-6]',`hirdetesszoveg`='[value-7]',`tehermentes`='[value-8]',`kepnev`='[value-9]',`hirdetesdatum`='[value-10]',`hirdetoid`='[value-11]',`kategoriaid`='[value-12]' WHERE 1
        app.post('/modositas', (req, res) => {
          kapcsolat()
            connection.connect()    
            connection.query(`UPDATE hirdetesek SET hirdetesekid=${req.body.hirdetesekid},szobaszam=${req.body.szobaszam},szelesseg=${req.body.szelesseg},hosszusag=${req.body.hosszusag},emelet=${req.body.emelet},alapterulet=${req.body.alapterulet},hirdetesszoveg="${req.body.hirdetesszoveg}",tehermentes="${req.body.tehermentes}",kepnev="${req.body.kepnev}",hirdetesdatum="${req.body.hirdetesdatum}",hirdetoid=${req.body.hirdetoid},kategoriaid=${req.body.kategoriaid} WHERE hirdetesekid=${req.body.hirdetesekid}`, (err, rows, fields) => {
              if (err) 
                res.send("Hiba") 
              else 
              res.send("A módosítás sikerült")
            })    
            connection.end()
          })

//UPDATE 'kategoriak' set 'kategoriakid' = '[value]'
app.post('/kategoriamodositas',(req,res)=> {
  kapcsolat()
  connection.connect()
  connection.query(`UPDATE kategoriak SET kategoriakid=${req.body.kategoriakid},"kategorianev=${req.body.kategorianev}" WHERE kategoriakid=${req.body.kategoriakid}`,(err,rows,fields)=>{
    if(err)
      res.send("Hiba!")
    else
      res.send("A módosítás sikerült!")
  })
  connection.end()
})
//UPDATE 'hirdetok' set 'hirdetokid' = '[value]'
app.post('/hirdetomodositas',(req,res)=> {
  kapcsolat()
  connection.connect()
  connection.query(`UPDATE hirdetok SET hirdetokid=${req.body.hirdetokid},"hirdetonev=${req.body.hirdetonev}, hirdetotelefon=${req.body.hirdetotelefon}" WHERE hirdetokid=${req.body.hirdetokid}`,(err,rows,fields)=>{
    if(err)
      res.send("Hiba!")
    else
      res.send("A módosítás sikerült!")
  })
  connection.end()
})
//UPDATE 'hirdetok'
app.post('/hirdetonevmodositas',(req,res)=> {
  kapcsolat()
  connection.connect()
  connection.query(`UPDATE hirdetok SET hirdetokid=${req.body.hirdetokid},"hirdetonev=${req.body.hirdetonev}" WHERE hirdetokid=${req.body.hirdetokid}`,(err,rows,fields)=>{
    if(err)
      res.send("Hiba!")
    else
      res.send("A módosítás sikerült!")
  })
  connection.end()
})
          
app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})