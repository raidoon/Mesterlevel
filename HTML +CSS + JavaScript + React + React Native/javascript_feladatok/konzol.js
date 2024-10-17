//1. Hozz létre json tömböt termékek nevével, árával, min.5db! 
var ruhakTomb=[
    {
        "nev":"póló",
        "ar":2000
    },
    {
        "nev":"pulcsi",
        "ar":6000
    },
    {
        "nev":"nadrág",
        "ar":10000
    },
    {
        "nev":"cipő",
        "ar":20000
    },
    {
        "nev":"sapka",
        "ar":2000
    }
]

//Írasd ki konzolra a tömböt!
console.log(ruhakTomb)

//Készíts függvényt, amely a paramétereként megadott számnál drágább termékeket megszámolja! Írasd ki konzolra!
function dragabbTermek(megadottOsszeg){
    var db = 0
    for (const elem of ruhakTomb) {
        if(elem.ar>megadottOsszeg) db++
    }
    return db
}   
console.log(`1. verzió: 5000 Ft-tól drágább termékek száma: ${dragabbTermek(5000)} db`)

//ugyanez másképpen! :)

function dragabbTermek2(megadottOsszeg){
    var db = 0
    for (const elem of ruhakTomb) {
        if(elem.ar>megadottOsszeg) db++
    }
    console.log(`2. verzió: 5000 Ft-tól drágább termékek száma: ${db} db`)
}
dragabbTermek2(5000)

//3000 Ft alatti 
function olcsobbTermek(megadottOsszeg){
    var db = 0
    for (const elem of ruhakTomb) {
        if(elem.ar<megadottOsszeg) db++
    }
    return db
}   
console.log(`3000 Ft-tól olcsóbb termékek száma: ${olcsobbTermek(3000)} db`)

//Készíts függvényt, paraméter nélkül, amely a termékek nevét összefûzi egy szöveggé, aláhúzásjellel elválasztva. Írasd ki konzolra!
function osszefuzes(){
    var osszefuzottSzoveg = ""
    for (const elem of ruhakTomb) {
        osszefuzottSzoveg+=elem.nev+"_"
    }
    return osszefuzottSzoveg
}

console.log(`Termékek neve összefűzve: \n${osszefuzes()}`)

//Készíts NYÍL függvényt, amely a paramétereként megadott terméknévre visszaadja, logikai értékként, hogy benne van vagy nincs! Írasd ki!
var termekSzerepel=(termekNev)=>{
    for (const elem of ruhakTomb) {
        if(elem.nev==termekNev){
            return true
        }
    }
    return false
}

console.log(`Alsó nadrág szerepel benne?: ${termekSzerepel("alsonadrag")}`)
console.log(`Póló szerepel benne?: ${termekSzerepel("póló")}`)
//Készíts NYÍL függvényt, paraméter nélkülit, amely visszaadja a termékek átlagárát! Írasd ki! 
var atlagol = () => {
    var osszeg = 0
    for (const elem of ruhakTomb) {
        osszeg += elem.ar
    }
    return osszeg/ruhakTomb.length
}
console.log(`A termékek átlagára: ${atlagol()} Ft`)