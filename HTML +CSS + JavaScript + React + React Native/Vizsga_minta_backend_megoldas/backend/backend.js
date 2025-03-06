const express = require('express')
const mysql = require('mysql')
var cors = require('cors')
const app = express()
const port = 3000
app.use(express.json())
app.use(cors())
app.use(express.urlencoded({ extended: true }));
app.use(express.static('kepek'))

var connection;
function kapcsolat() {
  connection = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'euroskills'
  })
  connection.connect()
}



app.get('/', (req, res) => {
  res.send('Hello World!')
})



app.get('/versenyzo', (req, res) => {
kapcsolat()
  connection.query(`
    SELECT * from versenyzo
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

app.get('/szakmaLekerdez', (req, res) => {
  kapcsolat()
    connection.query(`
      SELECT * from szakma Order By szakmaNev
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
  app.get('/orszagLekerdez', (req, res) => {
    kapcsolat()
      connection.query(`
        SELECT * from orszag Order By orszagNev
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

  app.post('/szakmaFelvitel', (req, res) => {
    kapcsolat()
      connection.query(`
      INSERT INTO szakma  VALUES (?,?);
          `,[req.body.bevitel1,req.body.bevitel2], (err, rows, fields) => {
        if (err) {
          console.log("Hiba")
          res.status(500).send("Hiba")
        }
        else {
          console.log("A felvitel sikeres!")
          res.status(200).send("A felvitel sikeres!")
        }
      })
      connection.end()
    })

    app.post('/versenyzoFelvitel', (req, res) => {
      kapcsolat()
        connection.query(`
        INSERT INTO versenyzo  VALUES (NULL, ?, ?, ?, ?);
            `,[req.body.bevitel1,req.body.bevitel2,req.body.bevitel3,req.body.bevitel4], (err, rows, fields) => {
          if (err) {
            console.log("Hiba")
            res.status(500).send("Hiba")
          }
          else {
            console.log("A felvitel sikeres!")
            res.status(200).send("A felvitel sikeres!")
          }
        })
        connection.end()
      })

      app.delete('/versenyzoTorles', (req, res) => {
        kapcsolat()
          connection.query(`
          DELETE FROM versenyzo WHERE id = ?; 
              `,[req.body.bevitel1], (err, rows, fields) => {
            if (err) {
              console.log("Hiba")
              res.status(500).send("Hiba")
            }
            else {
              console.log("A törlés sikeres!")
              res.status(200).send("A törlés sikeres!")
            }
          })
          connection.end()
        })

        app.delete('/versenyzoTorles2', (req, res) => {
          const {bevitel1}=req.body
          kapcsolat()
            connection.query(`
            DELETE FROM versenyzo WHERE id = ?; 
                `,[bevitel1], (err, rows, fields) => {
              if (err) {
                console.log("Hiba")
                res.status(500).send("Hiba")
              }
              else {
                console.log("A törlés sikeres!")
                res.status(200).send("A törlés sikeres!")
              }
            })
            connection.end()
          })
  
          app.delete('/versenyzoTorles3/:bevitel1', (req, res) => {
            const {bevitel1}=req.params
            kapcsolat()
              connection.query(`
              DELETE FROM versenyzo WHERE id = ?; 
                  `,[bevitel1], (err, rows, fields) => {
                if (err) {
                  console.log("Hiba")
                  res.status(500).send("Hiba")
                }
                else {
                  console.log("A törlés sikeres!")
                  res.status(200).send("A törlés sikeres!")
                }
              })
              connection.end()
            })


            app.delete('/szakmaTorles', (req, res) => {
              kapcsolat()
                connection.query(`
                DELETE FROM szakma WHERE id = ?; 
                    `,[req.body.bevitel1], (err, rows, fields) => {
                  if (err) {
                    console.log("Hiba")
                    res.status(500).send("Hiba")
                  }
                  else {
                    console.log("A törlés sikeres!")
                    res.status(200).send("A törlés sikeres!")
                  }
                })
                connection.end()
              })


  app.get('/VerSzakLek', (req, res) => {
  kapcsolat()
    connection.query(`
    SELECT versenyzo.nev,szakma.szakmaNev FROM versenyzo INNER JOIN szakma ON versenyzo.szakmaId = szakma.id ORDER BY versenyzo.nev; 
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

  app.put('/pontModosit', (req, res) => {
    const {bevitel1,bevitel2}=req.body
    kapcsolat()
      connection.query(`
      Update  versenyzo Set pont =? WHERE id = ?; 
          `,[bevitel1,bevitel2], (err, rows, fields) => {
        if (err) {
          console.log("Hiba")
          res.status(500).send("Hiba")
        }
        else {
          console.log("A módosítás sikeres!")
          res.status(200).send("A módosítás sikeres!")
        }
      })
      connection.end()
    })
          
    app.post('/VerSzakOrLek', (req, res) => {
      kapcsolat()
        connection.query(`
        SELECT versenyzo.nev, szakma.szakmaNev, orszag.orszagNev FROM versenyzo INNER JOIN szakma ON szakma.id = versenyzo.szakmaId INNER JOIN orszag ON orszag.id = versenyzo.orszagId WHERE versenyzo.id = ?; 
            `,[req.body.bevitel1], (err, rows, fields) => {
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

      app.post('/NevPontLek', (req, res) => {
        kapcsolat()
          connection.query(`
          SELECT versenyzo.nev,versenyzo.pont From versenyzo where versenyzo.pont > ? 
              `,[req.body.bevitel1], (err, rows, fields) => {
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


        app.put('/pontOrszagNovel', (req, res) => {
          const {bevitel1,bevitel2}=req.body
          kapcsolat()
            connection.query(`
            UPDATE versenyzo SET pont=pont *(?/100+1) WHERE versenyzo.orszagId =(SELECT orszag.id FROM orszag WHERE orszag.orszagNev = ?);  
                `,[bevitel1,bevitel2], (err, rows, fields) => {
              if (err) {
                console.log("Hiba")
                res.status(500).send("Hiba")
              }
              else {
                console.log("A módosítás sikeres!")
                res.status(200).send("A módosítás sikeres!")
              }
            })
            connection.end()
          })
    
          app.post('/OrszagCount', (req, res) => {
            const{bevitel1}=req.body
            kapcsolat()
              connection.query(`
              SELECT Count(versenyzo.id) From versenyzo Where versenyzo.orszagId = ?
                  `,[bevitel1], (err, rows, fields) => {
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

//12.feladat
            app.delete('/versenyzoPontOrszagTorles', (req, res) => {
              const {pont, orszagNev}=req.body;
              kapcsolat()
                connection.query(`
                DELETE FROM versenyzo WHERE pont < ? and orszagId IN (SELECT id FROM orszag WHERE orszagNev=?) 
                    `,[pont, orszagNev], (err, rows, fields) => {
                  if (err) {
                    console.log("Hiba")
                    res.status(500).send("Hiba")
                  }
                  else {
                    console.log("A törlés sikeres!")
                    res.status(200).send("A törlés sikeres!")
                  }
                })
                connection.end()
              })

              app.get('/versenyzoIdLek/:id', (req, res) => {
                const id = req.params.id;
                kapcsolat()
                  connection.query(`
                  SELECT id,nev,pont FROM versenyzo where id=?
                      `,[id], (err, rows, fields) => {
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

                app.get('/versenyzoIdTorles/:id', (req, res) => {
                  const id = req.params.id;
                  kapcsolat()
                    connection.query(`
                    DELETE FROM versenyzo WHERE id=? 
                        `,[id], (err, rows, fields) => {
                      if (err) {
                        console.log("Hiba")
                        res.status(500).send("Hiba")
                      }
                      else {
                        console.log("A törlés sikeres!")
                        res.status(200).send("A törlés sikeres!")
                      }
                    })
                    connection.end()
                  })                

/*
app.get('/versenyzo', (req, res) => {

  kapcsolat()
  connection.query('SELECT * from versenyzo', function (err, rows, fields) {
    if (err) throw err

    console.log(rows)
    res.send(rows)
  })
  connection.end()
})
*/
/*
app.get('/versenyzo', (req, res) => {
  kapcsolat();
  connection.query('SELECT * from versenyzo', (err, result) => {
    if(err) {
      res.status(500).json('Hiba');
    }
    res.status(200).json(result);
  });
  connection.end();
});
*/



app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})

