function kepfeltoltes() {
    var input = document.querySelector('input[type="file"]')
    var data = new FormData()
    data.append('photo', input.files[0])
    data.append('user', '')

    fetch("http://localhost:3000/upload", {
        method: "POST",
        body: data
    })
    .then(response => response.json())
    .then(data => {
        document.getElementById("kepfeltoltesstatus").innerHTML = input.files[0].name + " Képfeltöltés sikerült!";
        document.getElementById('kepnev').value = data.fileName; // Állítsd be a fájl nevét a kepnev mezőben
    })
    .catch(error => console.error('Error:', error));
     
    document.getElementById('kepfeltoltesstatus').innerHTML = "";
}
function kiadolekerdezes(){
    fetch("http://localhost:3000/kiado")
    .then(x=>x.json())
    .then(y=>kiadok(y));
}
kiadolekerdezes();
function kiadok(adatok){
    console.log(adatok)
    let sz=""
    let sz2=""
    adatok.forEach(item=>{
        sz+=`
        <tr>
            <td>${item.cim}</td>
            <td>${item.nev}</td>
            <td><a href="${item.www}" target="_blank">${item.www}</a></td>
        </tr>`
        sz2+=`
        <option value="${elem.id}">${elem.nev}</option>`
    })
    document.getElementById("tablazat").innerHTML=sz
    document.getElementById("kiadoid").innerHTML=sz2
}
function konyvlekerdezes(){
    fetch("http://localhost:3000/kettabla")
    .then(x=>x.json())
    .then(y=>konyvek(y))
}
konyvlekerdezes()
function konyvek(adatok){
    console.log(adatok)
    let sz=""
    let sz2=""
    adatok.forEach(item=>{
        sz+=`<div class="col-sm-6 col-lg-2">
        <div class="szegely">
        <a href="#${item.konyv_id}"><img src="http://localhost:3000/${item.kep}" class="img-fluid kepek" alt="${item.kep}" title="${item.kep}"></a>
        <p>${item.szerzo}</p>
        <p>${item.konyvcim}</p>
        <p>${item.ar} Ft</p>

        <button class="btn btn-danger" type="button" onclick="torles(${item.konyv_id})">törlés</button>
        <a href="#adatfelvitel"><button class="btn btn-primary" type="button" onclick="szerkesztes(${item.konyv_id})">Módosítás</button></a>
        </div>
        </div>
        `
        sz2+=`<div class="col-12 col-sm-4 dobozok">
        <img src="http://localhost:3000/${item.kep}" id="${item.konyv_id}" class="img-fluid kepek" alt="${item.kep}" title="${item.kep}">
        </div>
        <div class="col-12 col-sm-8 dobozok">
        <p><span class="felkover">Szerző:</span>${item.szerzo}</p>
        <p><span class="felkover">Könyv címe:</span>${item.konyvcim}</p>
        <p><span class="felkover">Leírás:</span>${item.leiras}</p>
        <p><span class="felkover">Ár:</span>${item.ar}</p>
        <p><span class="felkover">ISBN szám:</span>${item.isbn}</p>
        <p><span class="felkover">Kiadó neve:</span>${item.nev}</p>
        <p><span class="felkover">Kiadó webcíme:</span><a href="${item.www} target="_blank">${item.www} alt="${item.www}""></a></p>
        </div>
        `
    })
    document.getElementById("doboz").innerHTML=sz
    document.getElementById("reszletek").innerHTML=sz2
}
function szerkesztes(kulcs){
    fetch("http://localhost:3000/keresekmodosit/"+kulcs)
    .then(x=>x.json())
    .then(y=>konyvadatokmodosit(y))
}
function konyvadatokmodosit(adatok){
    console.log(adatok)
    for(var item of adatok){
        document.getElementById("id").value=item.konyv_id
        document.getElementById("szerzo").value=item.szerzo
        document.getElementById("konyvcim").value=item.konyvcim
        document.getElementById("isbn").value=item.isbn
        document.getElementById("ar").value=item.ar
        document.getElementById("kiadoid").value=item.kiadoid
        document.getElementById("kepnev").value=item.kepnev
        document.getElementById("leiras").value=item.leiras
    }
}
function ellenorzesmodositas(){
    document.getElementById("feltoltesuzenet").innerHTML="";
    if(document.getElementById("szerzo").value!=""&&document.getElementById("konyvcim").value!=""&&document.getElementById("isbn").value!=""&&document.getElementById("ar").value!=""&&document.getElementById("kepnev").value!=""&&document.getElementById("leiras").value!="")
    {
        konyvmodositas()
    }
    else document.getElementById("feltoltesuzenet").innerHTML="Minden adat kötelező!"
}
function setkereses(){
    var bevitelimezo=document.getElementById("bevitel0").value
    if(document.getElementById("bevitel0").value==""){
        konyvlekerdezes();
        window.location.reload();
    }
    else konyvekkeresese(bevitelimezo)
}
function konyvekkeresese(kulcsszo){
    fetch("http://localhost:3000/keresek"+kulcsszo+"")
    .then(x=>x.json())
    .then(y=>{
        konyvek(y)
    })
}
function konyvellenorzes(){
    document.getElementById("feltoltesuzenet").innerHTML="";
    if(document.getElementById("szerzo").value!=""&&document.getElementById("konyvcim").value!=""&&document.getElementById("isbn").value!=""&&document.getElementById("ar").value!=""&&document.getElementById("kepnev").value!=""&&document.getElementById("leiras").value!="")
    {
        konyvfelvitel()
    }
    else document.getElementById("kiadofeltoltesuzenet").innerHTML="Minden adat kötelező"
}
function kiadoellenorzes(){
    document.getElementById("kiadofeltoltesuzenet").innerHTML=""
    if(document.getElementById("cim").value!=""&&document.getElementById("nev").value!=""&&document.getElementById("www").value!="")
    {
        ujkiadofelvitel()
    }
    else document.getElementById("kiadofeltoltesuzenet").innerHTML="Minden adat kötelező!"
}
function ujkiadofelvitel(){
    var bemenet={
        cim:document.getElementById("cim").value,
        nev:document.getElementById("nev").value,
        www:document.getElementById("www").value
    }
    fetch("http://localhost:3000/kiadofelvitel",{
        method:"POST",
        body:JSON.stringify(bemenet),
        headers:{"Content-type":"application/json;charset=UTF-8"}
    })
    .then(x=>x.text())
    .then(y=>{
        document.getElementById("kiadofeltoltesuzenet").innerHTML="Feltöltés sikerült";
        kiadolekerdezes()
    })
}
function konyvfelvitel(){
    var bemenet={
        szerzo:document.getElementById("szerzo").value,
        konyvcim:document.getElementById("konyvcim").value,
        isbn:document.getElementById("isbn").value,
        ar:document.getElementById("ar").value,
        kiado_id:document.getElementById("kiado_id").value,
        kep:document.getElementById("kep").value,
        leiras:document.getElementById("leiras").value
    }
    fetch("http://localhost:3000/felvitel",{
        method:"POST",
        body:JSON.stringify(bemenet),
        headers:{"Content-type":"application/json;charset=UTF-8"}
    })
    .then(x=> x.text())
    .then(y=>{
        document.getElementById("feltoltesuzenet").innerHTML="Feltöltés sikerült";
        konyvlekerdezes()
    })
}
function torles(kulcs){
    var bemenet={
        konyv_id:kulcs,
    }
    fetch("hettp://localhost:3000/torles",{
        method:"DELETE",
        body:JSON.stringify(bemenet),
        headers:{"Content-type":"application/json;charset=UTF-8"}
    })
    .then(x=>x.text())
    .then(y=>{
        alert("A könyv törlése sikerült!");
        konyvlekerdezes()
    })
}