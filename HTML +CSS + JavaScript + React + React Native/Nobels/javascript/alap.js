fetch("https://api.nobelprize.org/v1/prize.json")
.then(x => x.json())
.then(y => megjelenites(y))

function megjelenites(y){
    prizes=y
    console.log(prizes)
    var szoveg = ""
        
    for (let i = 0; i < prizes.prizes.length; i++) {
        //console.log(prizes.prizes[i].category)
        szoveg += 
        `<div class="col-sm-4">
                <div class="szepites" data-bs-toggle="modal" data-bs-target="#myModal" onclick="kattintas(${i})">
                ${prizes.prizes[i].category}
                <br>
                ${prizes.prizes[i].year}
            </div>    
        </div>`
    }
    document.getElementById("gridecske").innerHTML = szoveg
}

function kattintas(parameter) {
    document.getElementById("cim").innerHTML = 
        `${prizes.prizes[parameter].category} ${prizes.prizes[parameter].year}`
        var szovegecske = ""
        if (prizes.prizes[parameter].laureates==undefined)
                szovegecske="Nem ismert!"
        else {
            for (const elem of prizes.prizes[parameter].laureates) {
                szovegecske+=`<div>`
                if(elem.firstname!=undefined)
                    szovegecske+=`${elem.firstname} `
                if(elem.surname!=undefined)
                    szovegecske+=`${elem.surname}`     
                szovegecske+=`</div>`            
                szovegecske+=
                `<div style="font-style:italic;">
                    ${elem.motivation} 
                </div><br>`
            }
        }
    modalistest.innerHTML=szovegecske
}