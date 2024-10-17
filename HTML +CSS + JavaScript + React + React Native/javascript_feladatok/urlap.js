/*Ûrlapok-Weblapon(design nélkül)
-urlap.html fájlba dolgozz!

2. Kérd be termék nevét, árát, készeleten lévõ darabszámát, lenyílóban jelenjen meg, hogy tejtermék/pékáru/édesség

A termék neve beviteli mezõjének háttere legyen sárga, ha belelépünk, és fehér, ha kilépünk. */

function kiSzinezes(elem){
    elem.style.backgroundColor="yellow"
}

function visszaSzinez(elem){
    elem.style.backgroundColor="white"
}

function kattintas(){
    console.log("a kattintás függvény lefutott!")
    var kiiratos_div = document.getElementById("kiiratos_div")
    var termek_neve = document.getElementById("termek_neve").value
    var termek_ara = document.getElementById("termek_ara").value
    var termek_tipusa = document.getElementById("termek_tipusa").value
    var termek_db = document.getElementById("termek_db").value

    //Gombnyomásra írja vissza a gomb alá a termék nevét, árát, darabszámát, típusát, majd alá az összértéket (ár*darab)
    kiiratos_div.innerHTML=`
    <br> Termék neve: ${termek_neve} <br> Termék ára: ${termek_ara} Ft
    <br> Termék darabszáma: ${termek_db} db
    <br> Termék típusa: ${termek_tipusa}
    <br> Termék összértéke: ${termek_ara*termek_db} Ft`
}