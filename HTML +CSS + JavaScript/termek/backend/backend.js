const express = require('express')
const mysql = require('mysql')
const app = express()
const port = 3000

var connection;

function kapcsolat(){
    connection = mysql.createConnection
    (
        {
            host: 'localhost',
            user: 'root',
            password: '',
            database: 'termek2024'
        }
    )
    connection.connect()
}

app.get('/', (req, res) => {
    res.send('Hello World!') //result send --> visszaküldi a hívónak
})

//--------------------------------------------tipus lekerdezes
app.get('/tipusLekerdez', (req, res) => {
    kapcsolat()
    connection.query('SELECT * from tipus', (err, rows, fields) => 
    {
        if (err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
}) 
//---------------------------------------------------------termék lekérdezése
app.get('/termekLekerdez', (req, res) => 
{
    kapcsolat()
    connection.query('SELECT * from termek', (err, rows, fields) => 
    {
        if (err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})
//---------------------------------------------------------200Ft-nál drágább termékek
app.get('/dragabbMint200Lekerdez', (req, res) => 
{
    kapcsolat()
    connection.query('SELECT * from termek where termek.termek_ar>200', (err, rows, fields) => 
    {
        if (err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})
//---------------------------------------------------------összes termék: neve, ára, típusának neve jelenjen meg
app.get('/osszesTermekLekerdez', (req, res) => 
{
    kapcsolat()
    connection.query(`SELECT *
                        from termek 
                        inner join tipus 
                        on termek.termek_tipus=tipus.tipus_id`, (err, rows, fields) => 
        {
            if (err) throw err
            console.log(rows)
            res.send(rows)
        }
    )
    connection.end()
})

//---------------------------------------------------------app.listen
app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})