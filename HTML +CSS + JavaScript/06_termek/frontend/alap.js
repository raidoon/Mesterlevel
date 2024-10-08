/*fetch('http://localhost:3000/termekLekerdez')
.then(x=>x.json())
.then(y=>megjelenites(y))

function megjelenites(y){
    console.log(y)
    for (const elem of y) {
        document.getElementById("tartalom").innerHTML += `<p>${elem.termek_nev}</p>`
    }
} 
*/
termekLekerdez() //------------------------elindítjuk az indítás functiont
async function termekLekerdez() {
    let x = await fetch('http://localhost:3000/termekLekerdez');
    let y = await x.json();
    termekMegjelenites(y);
}
//-------------------------------------------- lekérdezzük a termékeket
function termekMegjelenites(y){
    console.log(y)
    for (const elem of y) {
        document.getElementById("tartalom").innerHTML += `<p>${elem.termek_nev}</p>`
    }    
} 
//-------------------------------------------- új termék típus felvitele az adatbázisba
function tipusFelvitel(){
    var bevitel1 = document.getElementById("bevitel1").value
    var adatok = {
        "bevitel1" : bevitel1
    }

    fetch('http://localhost:3000/tipusFelvitel2',{
        method:"POST",
        body: JSON.stringify(adatok), //bodyba küldjük
        headers:{"Content-type":"application/json; charset=UTF-8"}
    })
    .then(x=> x.text())
    .then(y=> {
        document.getElementById("visszajelzes").innerHTML = y
    });
}
//-------------------------------------------- lenyilo listába tesszük a típusokat
tipusLekerdez()
async function tipusLekerdez() {
    let x = await fetch('http://localhost:3000/tipusLekerdez');
    let y = await x.json();
    tipusMegjelenites(y);
}
function tipusMegjelenites(y){
    for (const elem of y) {
        document.getElementById("lenyilo").innerHTML+= `<option value="${elem.tipus_id}">${elem.tipus_nev}</option>`
    }
}
//-------------------------------------------- új termék felvitele az adatbázisba
function TermekFelvitel(){
    var adatok = {
        "bevitel1" : document.getElementById("ujTermek_neve").value,
        "bevitel2" : document.getElementsById("ujTermek_ara").value,
        "bevitel3" : document.getElementsById("lenyilo").value
    }
    fetch("http://localhost:3000/termekFelvitel",{
        method:"POST",
        body: JSON.stringify(adatok),
        headers:{"Content-type":"application/json; charset=UTF-8"}
    })
    .then(x=> x.text())
    .then(y=> {
        document.getElementById("visszajelzes2").innerHTML = y
    });
}