function adatokbetoltese()
{
    fetch("http://localhost:3000/reszlegek_lekerdez")
    .then(x=>x.json())
    .then(y=>reszlegek(y));
    fetch("http://localhost:3000/dolgozok_lekerdez")
    .then(x=>x.json())
    .then(y=>dolgozok(y));
}
adatokbetoltese();
function reszlegek(adatok){
    console.log(adatok);
    var sz="";
    for(var elem of adatok)
    {
        sz+=`
        <option value="${elem.reszlegid}">${elem.reszleg}</option>
        `
    }
     document.getElementById("reszlegeklista").innerHTML=sz;

}
function dolgozok(adatok){
    console.log(adatok);
    var sz="";
    var sz2="";
    for(var elem of adatok)
    {
        sz+=`
        <div class="col-sm-4">
            <div class="keret">
                <h2>${elem.nev}</h2>
                <p>${elem.neme}</p>
                <p>${elem.reszleg}</p>
                <p>${elem.belepeseve}</p>
                <p>${elem.ber}</p>
            </div>
        </div>
        `
        sz2+=`
        <tr>
                <th>${elem.nev}</th>
                <th>${elem.neme}</th>
                <th>${elem.reszleg}</th>
                <th>${elem.belepeseve}</th>
                <th>${elem.ber}</th>
            </tr>
        `
    }
     document.getElementById("doboz").innerHTML=sz;
     document.getElementById("tablazat").innerHTML=sz2;
}
function kereses()
{
    var keresettadat=document.getElementById("keresettadat").value;
    if(document.getElementById("keresettadat").value=="")adatokbetoltese();
    else dolgozokkeresese(keresettadat);
}
function dolgozokkeresese(kulcsszo){
    fetch("http://localhost:3000/keresek/"+kulcsszo)
    .then(x=>x.json())
    .then(y=>dolgozok(y));
}
function kereses2()
{
    var keresettadat2=document.getElementById("reszlegeklista").value;
     dolgozokszurese(keresettadat2);
}
function dolgozokszurese(kulcsszo){
    fetch("http://localhost:3000/szures/"+kulcsszo)
    .then(x=>x.json())
    .then(y=>dolgozok(y));
}