function adatokbetoltese(){
    fetch('http://localhost:3000/tipus')
    .then(x=>x.json())
    .then(y=>tipusok(y));
    fetch('http://localhost:3000/kettabla')
    .then(x=>x.json())
    .then(y=>allatok(y));
}
adatokbetoltese();

function tipusok(adatok){
    console.log(adatok)
    var sz="";
    for (var elem of adatok) {
        sz+=`
        <option value="">${elem.tipus_nev}</option>
        `
    }
    document.getElementById("kisallatok_tipusai").innerHTML=sz;
}

function allatok(adatok){
    console.log(adatok)
    var sz="";
    for (var elem of adatok) {
        sz+=`
        <div class="col-sm-6 col-lg-4">
            ${elem.allat_nev}
            <br>
            ${elem.allat_ar} Ft
            <br>
            ${elem.tipus_nev}
            <img src="kepek/${elem.allat_kep}" alt="${elem.allat_nev}" class="img-fluid rounded-circle">
          </div> 
        `
    }
    document.getElementById("doboz").innerHTML=sz;
}

function kereses(){
    var keresett_adat = document.getElementById("keresett_adat").value
    if(keresett_adat=="")adatokbetoltese()
    else{
        fetch("http://localhost:3000/keresek/"+keresett_adat)
        .then(x=>x.json())
        .then(y=>allatok(y));
    }
}