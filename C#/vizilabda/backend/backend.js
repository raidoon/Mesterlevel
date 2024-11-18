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
    database: "vizilabda",
  });
}

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.get("/kapitanyLista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query("SELECT * FROM kapitany", (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});
app.get("/bajnoksagLista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query("SELECT * FROM bajnoksag", (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});

app.get("/adatokLista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    "SELECT * FROM bajnoksag INNER JOIN kapitany ON kapitanyid=kapitany_id ",
    (err, rows, fields) => {
      if (err) throw err;
      console.log(rows);
      res.send(rows);
    }
  );
  connection.end();
});

//INSERT INTO `varos`(`varos_id`, `vnev`, `vtipid`, `megyeid`, `jaras`, `kisterseg`, `nepesseg`, `terulet`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]','[value-8]')
app.put("/modositas", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    `update kapitany set meghalt=${req.body.meghalt} where kapitany_id=${req.body.kapitany_id}`,
    (err, rows, fields) => {
      if (err) res.send("Hiba");
      else res.send("A módosítás sikerült");
    }
  );
  connection.end();
});
app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});
