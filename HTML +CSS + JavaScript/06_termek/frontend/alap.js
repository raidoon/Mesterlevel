/*termékek neve p-kben || új termék felvitele, formmal, gombbal, mindennel*/

/*
fetch('http://localhost:3000/termekLekerdez')
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
tipusLekerdez()

async function termekLekerdez() {
    let x = await fetch('http://localhost:3000/termekLekerdez');
    let y = await x.json();
    termekMegjelenites(y);
}

async function tipusLekerdez() {
    let x = await fetch('http://localhost:3000/tipusLekerdez');
    let y = await x.json();
    tipusMegjelenites(y);
}

//lenyilo listába tesszük a típusokat
function tipusMegjelenites(y){
    for (const elem of y) {
        document.getElementById("lenyilo").innerHTML+= `<option value="${elem.tipus_id}">${elem.tipus_nev}</option>`
    }
}

//lekérdezzük a termékeket
function termekMegjelenites(y){
    console.log(y)
    for (const elem of y) {
        document.getElementById("tartalom").innerHTML += `<p>${elem.termek_nev}</p>`
    }    
} 