const express = require("express");
var multer = require("multer");
var cors = require("cors");
const mysql = require("mysql");
const app = express();
const port = 3000;
app.use(cors());
app.use(express.json());
app.use(express.static("kepek"));
function kapcsolat() {
  connection = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "",
    database: "movarosai",
  });
}
app.get("/varostipusLista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query("SELECT * from varostipus", (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});
app.get("/megyeLista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query("SELECT * from megye", (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});
app.get("/varosLista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query("SELECT varos_id, vnev, vtip, mnev, jaras, kisterseg, nepesseg, terulet from megye inner join varos on megye_id=megyeid inner join varostipus on vtip_id=vtipid", (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});
app.post('/felvitel',(req,res)=>{
  kapcsolat()
  connection.connect()
  connection.query(`insert into varos values(${req.body.varos_id},"${req.body.vnev}",${req.body.vtipid},${req.body.megyeid},"${req.body.jaras}","${req.body.kisterseg}",${req.body.nepesseg},${req.body.terulet})`, (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});
app.delete('/torles',(req,res)=>{
  kapcsolat()
  connection.connect()
  connection.query(`delete from varos where varos_id=${req.body.varos_id}`, (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});
app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});