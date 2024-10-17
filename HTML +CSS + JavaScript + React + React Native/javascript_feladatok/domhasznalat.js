/*JS-HTML-DOM használata(design nélkül)
-domhasznalat.html
3. Készíts tömböt, amely a tejtermék, pékáru, édesség, fûszer, tisztítószer szavakat tartalmazza, majd lenyíló listában megjeleníti Javascript programmal (createelement...appendchild)*/
var body = document.getElementsByTagName("body")[0]
var termekTomb=["tejtermék","pékáru","édesség","fűszer","tisztítószer"]

var select=document.createElement("select")
select.id="bemenet1"
for (const elem of termekTomb) {
    var option = document.createElement("option")
    option.value=`${elem}`
    option.innerHTML=`${elem}`
    select.appendChild(option)
}
body.appendChild(select)

//Készíts alatta az 5 szóval radio gombokat, csak 1-et lehessen kiválasztani (createelement...appendchild)
var form = document.createElement("form")
form.id="sajt"
for (const elem of termekTomb) {
    var input = document.createElement("input")
    input.type="radio"
    input.name="csakEgyetValaszthatsz"
    input.id=`${elem}`
    form.appendChild(input)
    var span = document.createElement("span")
    span.innerHTML =`${elem}`
    span.value=`${elem}`
    form.appendChild(span)
    form.appendChild(document.createElement("br"))
    input.addEventListener("change",kattintas)
}
document.getElementsByName(termekTomb[0]).checked=true
body.appendChild(form)

//gombnyomásra irassuk vissza
var gomb = document.createElement("button")
gomb.innerHTML="Kattintás"
gomb.addEventListener("click",kattintas)
body.appendChild(gomb)

//divben a select adata
var select_div = document.createElement("div")
var radio_div = document.createElement("div")

function kattintas(){
    console.log("a gomb működik")
    var select = document.getElementById("bemenet1").value
    var radio = document.getElementsByName("csakEgyetValaszthatsz")
    select_div.innerHTML = select
    for (const elem of radio) {
        if(elem.checked==true){
            radio_div.innerHTML=elem.id
        }
    }
}
body.appendChild(select_div)
body.appendChild(radio_div)

//nem gombnyomásra irassuk vissza
document.getElementById("bemenet1").addEventListener("change",kattintas)
kattintas()