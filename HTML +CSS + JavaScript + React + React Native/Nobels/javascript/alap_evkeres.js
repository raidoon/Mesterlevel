function kattintevkeres() {
    var bekeres = document.getElementById("bekeres").value
    if (isNaN(bekeres)) { document.getElementById("kiiras").innerHTML = "Kérlek számot adj meg!" }
    else {
        var utolsoev = parseInt(prizes.prizes[0].year)
        if (bekeres > utolsoev || bekeres < 1901) { document.getElementById("kiiras").innerHTML = "Kérlek adj meg létező évszámot(2023 és 1901)!" }
        else {
            //adatok keresése az adott évre
            var szovegecske = ""
            szovegecske += `<ul> `
            for (const elem of prizes.prizes) {
                if (elem.year == bekeres) {
                    szovegecske += `<li>${elem.category}</li>`

                    //___Nobelesek nevei___\\
                    if (elem.laureates == undefined)
                        szovegecske = "Nem ismert!"
                    else
                        for (const elem1 of elem.laureates) {
                            szovegecske += `<div style="font-weight:bold;">`
                            if (elem1.firstname != undefined)
                                szovegecske += `${elem1.firstname}`
                            if (elem1.surnamre != undefined)
                                szovegecske += `${elem1.surname}`
                            szovegecske += `</div>`

                            szovegecske +=
                                `<div style="font-style:italic;">
                            ${elem1.motivation} 
                        </div><br>`
                        }
                }
                szovegecske += `</ul> `
                document.getElementById("kiiras").innerHTML = szovegecske
            }
        }
    }
}