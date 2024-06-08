fetch("https://api.nobelprize.org/v1/prize.json")
    .then(x => x.json())
    .then(y => megjelenites(y))

function megjelenites(y) {
    console.log(y)
    prizes = y
    var utolsoev = parseInt(prizes.prizes[0].year)
    for (let i = utolsoev; i > 1900; i--) {
        document.getElementById("lenyilo").innerHTML += `
        <option value="${i}">${i}</option>`
    }
}

function kereses() {
    //alert(lenyilo.value)
    var szovegecske = ""
    for (const elem of prizes.prizes) {
        if (elem.year == lenyilo.value) {
            szovegecske += `
            <button type="button" class="btn btn-success" data-bs-toggle="collapse" data-bs-target="#${elem.category}"> 
                ${elem.year} ${elem.category}
            </button>  
            <br>    
            <div id="${elem.category}" class="collapse">`
            if (elem.laureates == undefined)
                szovegecske += "Nem ismert!"
            else
                for (const elemDijazott of elem.laureates) {
                    szovegecske += `<div>`
                    if (elemDijazott.firstname != undefined)
                        szovegecske += `${elemDijazott.firstname}`
                    if (elemDijazott.surname != undefined)
                        szovegecske += `${elemDijazott.surname}`
                    szovegecske += `</div>`
                    szovegecske +=
                        `<div style="font-style:italic;">
                            ${elemDijazott.motivation} 
                        </div><br>`
                }
            szovegecske += `</div>`
            keresesDiv.innerHTML = szovegecske
        }
    }
}