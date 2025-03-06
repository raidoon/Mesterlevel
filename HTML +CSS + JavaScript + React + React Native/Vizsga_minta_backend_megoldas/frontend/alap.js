//1.feladat
fetch("http://localhost:3000/szakmaLekerdez")
  .then((x) => x.json())
  .then((y) => Feladat_1(y));

fetch("http://localhost:3000/verSzakLek")
  .then((x) => x.json())
  .then((y) => Feladat_2(y));

fetch("http://localhost:3000/szakmaLekerdez")
  .then((x) => x.json())
  .then((y) => Feladat_4(y));

fetch("http://localhost:3000/orszagLekerdez")
  .then((x) => x.json())
  .then((y) => Feladat_4_2(y));

fetch("http://localhost:3000/versenyzo")
  .then((x) => x.json())
  .then((y) => Feladat_5(y));

function Feladat_1(adatok) {
  let sz = "<ul>";
  for (const elem of adatok) {
    sz += `<li class="szakma">${elem.szakmaNev}</li>`;
  }
  sz += "</ul>";
  document.getElementById("felsorolas").innerHTML = sz;
}
function Feladat_4(adatok) {
  let sz = `<select id="selectSzakma">`;
  for (const elem of adatok) {
    sz += `<option value="${elem.id}">${elem.szakmaNev}</option>`;
  }
  sz += "</select>";
  document.getElementById("szakmaLenyilo").innerHTML = sz;
}
function Feladat_5(adatok) {
  let sz = `<select id="selectVersenyzo">`;
  for (const elem of adatok) {
    sz += `<option value="${elem.id}">${elem.nev}</option>`;
  }
  sz += "</select>";
  document.getElementById("versenyzoLenyilo").innerHTML = sz;
}
function Feladat_4_2(adatok) {
  let sz = `<select id="selectOrszag">`;
  for (const elem of adatok) {
    sz += `<option value="${elem.id}">${elem.orszagNev}</option>`;
  }
  sz += "</select>";
  document.getElementById("orszagLenyilo").innerHTML = sz;
}
function Feladat_2(adatok) {
  let sz = "";
  for (const elem of adatok) {
    sz += `
        <div class="col-lg-3 col-md-4 col-sm-6 versenyzo-box">
            <p class="versenyzoNev">${elem.nev} </p>
            <p class="versenyzoSzakma">(${elem.szakmaNev})</p>
        </div>`;
  }
  document.getElementById("versenyzo_lista").innerHTML = sz;
}
function szakmaFelvitel() {
  let beid = document.getElementById("id").value;
  let beSzakmaNev = document.getElementById("szakmaNev").value;
  let adatok = {
    bevitel1: beid,
    bevitel2: beSzakmaNev,
  };
  fetch("http://localhost:3000/szakmaFelvitel", {
    method: "POST",
    body: JSON.stringify(adatok),
    headers: { "Content-type": "application/json;charset=UTF-8" },
  })
    .then((x) => x.text())
    .then((y) => {
      if (y == "Hiba") {
        document.getElementById(
          "valaszP"
        ).innerHTML = `<p class="hiba">Minden megadása kötelező!</p>`;
      } else {
        document.getElementById("valaszP").innerHTML = `
            <p class="ok">
               Sikeres felvitel!
            </p>`;
      }
    });
}
function versenyzoFelvitel() {
  let benev = document.getElementById("versenyzoNeve").value;
  let bepont = document.getElementById("versenyzoPontja").value;
  let orszag = document.getElementById("selectOrszag").value;
  let szakma = document.getElementById("selectSzakma").value;

  let adatok = {
    bevitel1: benev,
    bevitel2: szakma, //szakmaId,
    bevitel3: orszag, //orszagId
    bevitel4: bepont,
  };
  fetch("http://localhost:3000/versenyzoFelvitel", {
    method: "POST",
    body: JSON.stringify(adatok),
    headers: { "Content-type": "application/json;charset=UTF-8" },
  })
    .then((x) => x.text())
    .then((y) => {
      if (y == "Hiba") {
        document.getElementById(
          "versenyzoValasz"
        ).innerHTML = `<p class="hiba">Minden megadása kötelező!</p>`;
      } else {
        document.getElementById("versenyzoValasz").innerHTML = `
            <p class="ok">
               Sikeres felvitel!
            </p>`;
      }
    });
}
function versenyzoTorlese() {
  let versenyzoId = document.getElementById("selectVersenyzo").value;
  let adatok = {
    bevitel1: versenyzoId,
  };
  fetch("http://localhost:3000/versenyzoTorles", {
    method: "DELETE",
    body: JSON.stringify(adatok),
    headers: { "Content-type": "application/json;charset=UTF-8" },
  })
    .then((x) => x.text())
    .then((y) => {
      if (y == "Hiba") {
        document.getElementById(
          "torlesValasz"
        ).innerHTML = `<p class="hiba">Minden megadása kötelező!</p>`;
      } else {
        document.getElementById("torlesValasz").innerHTML = `
            <p class="ok">
               Sikeres törlés!
            </p>`;
      }
    });
}
function pontModositas() {
  let ujpontszam = document.getElementById("ujpontszamInput").value;
  let versenyzo_id = document.getElementById("selectVersenyzo").value;
  let adatok = {
    bevitel1: ujpontszam,
    bevitel2: versenyzo_id,
  };
  if (ujpontszam < 200 || ujpontszam > 1200) {
    document.getElementById(
      "modositValasz"
    ).innerHTML = `<p class="hiba">Az új pontszámnak 200 és 1200 között kell lennie!</p>`;
  } else if (!Number.isInteger(parseInt(ujpontszam))) {
    document.getElementById(
      "modositValasz"
    ).innerHTML = `<p class="hiba">Az új pontszámnak számnak kell lennie!</p>`;
  } else {
    fetch("http://localhost:3000/pontModosit", {
      method: "PUT",
      body: JSON.stringify(adatok),
      headers: { "Content-type": "application/json;charset=UTF-8" },
    })
      .then((x) => x.text())
      .then((y) => {
        if (y == "Hiba") {
          document.getElementById(
            "modositValasz"
          ).innerHTML = `<p class="hiba">Minden megadása kötelező!</p>`;
        } else {
          document.getElementById("modositValasz").innerHTML = `
              <p class="ok">
                 Sikeres módosítás!
              </p>`;
        }
      });
  }
}
