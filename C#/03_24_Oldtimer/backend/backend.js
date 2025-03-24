const express = require("express");
var cors = require("cors");
var mysql = require("mysql");
const app = express();
const port = 3000;

app.use(cors());
app.use(express.json());
app.use(express.static("kepek"));

var connection;

function kapcsolat() {
  connection = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "",
    database: "oldtimer",
  });

  connection.connect();
}

app.get("/", (req, res) => {
  res.send("Hello World!");
});

//SELECT `kategoriakid`, `kategoriaknev` FROM `kategoriak`
app.get("/kategoriaklista", (req, res) => {
  kapcsolat();
  connection.query(
    "SELECT kategoriakid,kategoriaknev FROM kategoriak order by kategoriaknev",
    (err, rows) => {
      if (err) {
        console.log(err);
        res.status(500).send("Hiba");
      } else {
        console.log(rows);
        res.status(200).send(rows);
      }
    }
  );
  connection.end();
});

app.get("/autoklista", (req, res) => {
  kapcsolat();
  connection.query(
    "SELECT autokid,autokrendszam,autokszin,autoknev,autokevjarat,autokar,autokkategoriaid FROM autok ORDER BY autoknev",
    (err, rows) => {
      if (err) {
        console.log(err);
        res.status(500).send("Hiba");
      } else {
        console.log(rows);
        res.status(200).send(rows);
      }
    }
  );
  connection.end();
});

//3 táblás
app.get("/berleseklista", (req, res) => {
  kapcsolat();
  connection.query(
    "SELECT kategoriaknev,autokid,autokrendszam,autokszin,autoknev,autokevjarat,autokar,autokkategoriaid, berlesekid,berlesekmennyiseg,berlesekbiztositas,berlesekdatum FROM kategoriak INNER JOIN autok ON kategoriak.kategoriakid=autok.autokkategoriaid INNER JOIN berlesek ON autok.autokid=berlesek.berlesekautoid",
    (err, rows) => {
      if (err) {
        console.log(err);
        res.status(500).send("Hiba");
      } else {
        console.log(rows);
        res.status(200).send(rows);
      }
    }
  );
  connection.end();
});

//INSERT INTO `kategoriak`(`kategoriakid`, `kategoriaknev`) VALUES ('[value-1]','[value-2]')
app.post("/kategoriakfelvitel", (req, res) => {
  kapcsolat();
  console.log(`${req.body.kategoriakid},${req.body.kategoriaknev}`);
  const { kategoriakid, kategoriaknev } = req.body;
  connection.query(
    "INSERT INTO kategoriak (kategoriakid,kategoriaknev) VALUES(?,?)",
    [kategoriakid, kategoriaknev],
    (err) => {
      if (err) {
        console.log(err);
        res.status(500).send("Hiba történt az adatok mentésekor");
      } else {
        res.status(200).send("Sikeres kategória felvitel");
      }
    }
  );
  connection.end();
});

//INSERT INTO `autok`( `autokrendszam`, `autokszin`, `autoknev`, `autokevjarat`, `autokar`, `autokkategoriaid`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]')
app.post("/autofelvitel", (req, res) => {
  kapcsolat();
  console.log(
    `${req.body.autokrendszam},${req.body.autokszin},${req.body.autoknev},${req.body.autokevjarat},${req.body.autokar},${req.body.autokkategoriaid}`
  );
  const {
    autokrendszam,
    autokszin,
    autoknev,
    autokevjarat,
    autokar,
    autokkategoriaid,
  } = req.body;
  connection.query(
    "INSERT INTO autok (autokrendszam,autokszin,autoknev,autokevjarat,autokar,autokkategoriaid) VALUES(?,?,?,?,?,?)",
    [
      autokrendszam,
      autokszin,
      autoknev,
      autokevjarat,
      autokar,
      autokkategoriaid,
    ],
    (err) => {
      if (err) {
        console.log(err);
        res.status(500).send("Hiba történt az adatok mentésekor");
      } else {
        res.status(200).send("Sikeres autó felvitel");
      }
    }
  );
  connection.end();
});

//INSERT INTO `berlesek`(`berlesekid`, `berlesekautoid`, `berlesekmennyiseg`, `berlesekbiztositas`, `berlesekdatum`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]')
app.post("/berlesekfelvitel", (req, res) => {
  kapcsolat();
  console.log(
    `${req.body.berlesekid},${req.body.berlesekautoid},${req.body.berlesekmennyiseg},${req.body.berlesekbiztositas},${req.body.berlesekdatum}`
  );
  const {
    berlesekid,
    berlesekautoid,
    berlesekmennyiseg,
    berlesekbiztositas,
    berlesekdatum,
  } = req.body;
  connection.query(
    "INSERT INTO berlesek (berlesekid,berlesekautoid,berlesekmennyiseg,berlesekbiztositas,berlesekdatum) VALUES(?,?,?,?,?)",
    [
      berlesekid,
      berlesekautoid,
      berlesekmennyiseg,
      berlesekbiztositas,
      berlesekdatum,
    ],
    (err) => {
      if (err) {
        console.log(err);
        res.status(500).send("Hiba történt az adatok mentésekor");
      } else {
        res.status(200).send("Sikeres bérlés felvitel");
      }
    }
  );
  connection.end();
});

app.delete("/torles", (req, res) => {
  kapcsolat();
  console.log(`${req.body.autokid}`);
  const { autokid } = req.body;
  connection.query("DELETE FROM autok WHERE autokid=?", [autokid], (err) => {
    if (err) {
      console.log(err);
      res.status(500).send("Hiba történt az adatok törlésekor");
    } else {
      res.status(200).send("Sikeres autó törlés");
    }
  });
  connection.end();
});

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`);
});
