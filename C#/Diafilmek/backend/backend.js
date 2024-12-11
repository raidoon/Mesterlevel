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
    database: "diafilmekab",
  });
}
app.get("/kiadolista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    "SELECT * FROM kiado order by kiadonev",
    (err, rows, fields) => {
      if (err) throw err;
      console.log(rows);
      res.send(rows);
    }
  );
  connection.end();
});
app.get("/filmlista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query("SELECT * FROM film order by cim", (err, rows, fields) => {
    if (err) throw err;
    console.log(rows);
    res.send(rows);
  });
  connection.end();
});
app.get("/adatoklista", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    "SELECT * FROM kiado inner join film on kiadoid=filmkiadoid",
    (err, rows, fields) => {
      if (err) throw err;
      console.log(rows);
      res.send(rows);
    }
  );
  connection.end();
});
app.post("/kiadofelvitel", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    `INSERT INTO kiado  VALUES (null,"${req.body.kiadonev}")`,
    (err, rows, fields) => {
      if (err) res.send("Hiba");
      else res.send("A kiadó felvitel sikerült");
    }
  );
  connection.end();
});
app.post("/filmfelvitel", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    `INSERT INTO film VALUES (null,"${req.body.cim}",${req.body.kiadasiev},${req.body.kocka},${req.body.szinese},${req.body.filmkiadoid})`,
    (err, rows, fields) => {
      if (err) res.send("Hiba");
      else res.send("A film felvitel sikerült");
    }
  );
  connection.end();
});
app.put("/kiadomodositas", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    `UPDATE kiado SET kiadonev="${req.body.kiadonev}" WHERE kiadoid=${req.body.kiadoid}`,
    (err, rows, fields) => {
      if (err) res.send("Hiba");
      else res.send("A kiadó módosítása sikerült");
    }
  );
  connection.end();
});
app.put("/filmmodositas", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    `UPDATE film  SET cim="${req.body.cim}",kiadasiev=${req.body.kiadasiev},kocka=${req.body.kocka},szinese=${req.body.szinese},filmkiadoid=${req.body.filmkiadoid} where filmid=${req.body.filmid}`,
    (err, rows, fields) => {
      if (err) res.send("Hiba");
      else res.send("A film módosítás sikerült");
    }
  );
  connection.end();
});
app.delete("/filmtorles", (req, res) => {
  kapcsolat();
  connection.connect();
  connection.query(
    `DELETE FROM film  WHERE filmid=${req.body.filmid}`,
    (err, rows, fields) => {
      if (err) res.send("Hiba");
      else res.send("A film törlése sikerült");
    }
  );
  connection.end();
});
app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});
