const express = require('express')
var cors = require('cors')
const app = express()
const port = 3000
app.use(cors())

const mysql = require('mysql')
const { connect } = require('http2')
app.use(express.json());

function kapcsolat()
{
    connection = mysql.createConnection({
        host: 'localhost',
        user:'root',
        password:'',
        database:'kisallatkereskedes'
    })
}
app.get('/',(req,res)=>{
    res.send('Hello World!')
})

app.get('/tipus', (req,res)=>{
    kapcsolat()
    connection.connect()
    connection.query('select * from tipus', (err, rows, fields)=>{
        if (err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})

app.get('/kettabla', (req,res)=>{
    kapcsolat()
    connection.connect()
    connection.query('select * from allat inner join tipus on allat.allat_tipus=tipus.tipus_id',(err,rows,fields)=>{
        if (err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})

app.get('/keresek/:kereses', (req,res) =>{
    kapcsolat()
    connection.connect()
    connection.query(`select * from allat inner join tipus on allat.allat_tipus=tipus.tipus_id where allat_nev like "%${req.params.kereses}%" or tipus_nev like "%${req.params.kereses}%"`, (err,rows,fields)=>{
        if(err) throw err
        console.log(rows)
        res.send(rows)
    })
    connection.end()
})

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
})