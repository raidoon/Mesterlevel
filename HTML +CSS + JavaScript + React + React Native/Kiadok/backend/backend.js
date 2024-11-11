const express = require('express');
var multer = require('multer');
var cors = require('cors');
const mysql = require('mysql');
const app = express();
const port = 3000;
app.use(cors());

app.use(express.json());
app.use(express.static('kepek'));

//kép feltöltése
const storage = multer.diskStorage({
  destination(req, file, callback) {
    callback(null, './kepek');
  },
  filename(req, file, callback) {
    //callback(null, `${file.originalname}`);
    callback(null, `${file.fieldname}_${Date.now()}_${file.originalname}`);
  },
});

const upload = multer({ storage });

app.post('/upload', upload.array('photo', 3), (req, res) => {
  const uploadedFileName = req.files[0].filename; // Ez a feltöltött fájl neve
  console.log('file', req.files);
  console.log('body', req.body);

  res.status(200).json({
    message: 'success!',
    fileName: uploadedFileName // Adjuk hozzá a válaszhoz a fájl nevét
  });
});

function kapcsolat()
{
     connection = mysql.createConnection({
        host: 'localhost',
        user: 'root',
        password: '',
        database: 'kiadok'
      })
}

app.get('/', (req,res)=>{
    res.send('Hello World!')
})

app.get('/kiado',(req,res)=>{
    kapcsolat()
    connection.connect()
    connection.query('select * from kiado',(err,rows,fields)=>{
        if(err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})

app.get('/kettabla',(req,res)=>{
    kapcsolat()
    connection.connect()
    connection.query('select * from kiado inner join konyv on kiado.id=konyv.kiado_id',(err,rows,fields)=>{
        if(err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})
app.get('/keresek/:kereses',(req,res)=>{
    kapcsolat()
    connection.connect()
    connection.query('select * from kiado inner join konyv on kiado.id=konyv.kiado_id where (konyv.szerzo like"%'+req.params,kereses+'%" or konyv.konyvcim like "%'+req.params.kereses+'%" or konyv.leiras like"%'+req.params.kereses+'%")',(err,rows,fields)=>{
        if(err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})
app.post('/modositas',(req,res)=>{
    kapcsolat()
    connection.connect()
    connection.query(`update konyv set szerzo="${req.body.szerzo}",konyvcim="${req.body.konyvcim}",isbn="${req.body.isbn}",ar=${req.body.ar},kiado_id=${req.body.kiado_id},kep="${req.body.kep}",leiras="${req.body.leiras}" where konyv_id=${req.body.konyv_id}`,(err,rows,fields)=>{
        if(err)
            res.send("Hiba")
        else
            res.send("A módosítás sikeres volt!")
    })
    connect.end()
})
app.delete('/torles',(req,res)=>{
    kapcsolat()
    connection.connect()
    connection.query(`delete from konyv where konyv_id=${req.body.konyv_id}`,(err,rows,fields)=>{
        if(err)
            res.send("Hiba")
        else
            res.send("A törlés sikeres volt!")
    })
    connection.end()
})
/*
app.post('/felvitel',(req,res)=>{
    kapcsolat()
    connection.connect()
})
*/
app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
  })