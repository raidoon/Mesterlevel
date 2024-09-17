/*JS-HTML-DOM használata(design nélkül)
-domhasznalat.html

3. Készíts tömböt, amely a tejtermék, pékáru, édesség, fûszer, tisztítószer szavakat tartalmazza, majd lenyíló listában megjeleníti Javascript programmal (createelement...appendchild)*/
var termekTomb=["tejtermék","pékáru","édesség","fűszer","tisztítószer"]

var select=document.createElement("select")
for (const elem of termekTomb) {
    var option = document.createElement("option")
    option.value=`${elem}`
    option.innerHTML=`${elem}`
    select.appendChild(option)
}
document.getElementsByTagName("body")[0].appendChild(select)

//Készíts alatta az 5 szóval radio gombokat, csak 1-et lehessen kiválasztani (createelement...appendchild)

var form = document.createElement("form")

for (const elem of termekTomb) {
    var input = document.createElement("input")
    input.type="radio"
    input.name="csakEgyetValaszthatsz"
    form.appendChild(input)
    var span = document.createElement("span")
    span.innerHTML =`${elem}`
    span.value=`${elem}`
    form.appendChild(span)
    form.appendChild(document.createElement("br"))
}

document.getElementsByTagName("body")[0].appendChild(form)

/* */