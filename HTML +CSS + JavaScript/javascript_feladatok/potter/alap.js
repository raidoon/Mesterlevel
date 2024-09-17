/**Fetch,  dizájnolás Bootstrap-el
-potter mappába dolgozz! Open folder , index.html, alap.js

https://github.com/Laboratoria/LIM011-data-lovers/blob/master/src/data/potter/potter.json

4. Érd el fetch-el az adatokat, írasd ki konzolra!
(bootstrapes, netes hivatkozas)!*/

/*fetch('https://raw.githubusercontent.com/Laboratoria/LIM011-data-lovers/master/src/data/potter/potter.json')
.then(x => x.json())
.then(y => megjelenites(y))*/

async function getJson() {
    let x = await fetch("https://raw.githubusercontent.com/Laboratoria/LIM011-data-lovers/master/src/data/potter/potter.json")
    let y = await x.json();
    megjelenites(y)


    function megjelenites(adatok){
        console.log(adatok)

        var select = document.createElement("select")
        
        //Írasd ki a szereplõk nevét Weblapra, lenyíló listába
        for (const elem of adatok) {
            var option = document.createElement("option")
            option.innerHTML=`${elem.name}`
            select.appendChild(option)
        }    
        document.body.appendChild(select)

        //Alatta írasd ki a szereplõket táblázatba(bootstrap)(neve, neme, háza, színészt)
        /*<table>
            <tr>
                <th>Neve</th>
                <th>Neme</th>
                <th>Háza</th>
                <th>Színész</th>
            </tr>
        </table>*/

        var table = document.createElement("table")
        for (let i = 0; i < adatok.length; i++) {
            var tr = document.createElement("tr")
            tr.id=`try${i}` 
        }
        var i = 0
            for (const elem of adatok) {
                var td_neve = document.createElement("td")
                var td_neme = document.createElement("td")
                var td_haza = document.createElement("td")
                var td_szinesz = document.createElement("td")

                td_neve.innerHTML=`${elem.name}`
                td_neme.innerHTML=`${elem.gender}`
                td_haza.innerHTML=`${elem.house}`
                td_szinesz.innerHTML=`${elem.actor}`

                var trs = document.getElementById(`try${i}`)

                trs.appendChild(td_neve)
                trs.appendChild(td_neme)
                trs.appendChild(td_haza)
                trs.appendChild(td_szinesz)
                
                table.appendChild(trs)
                i++
            }
            
        document.body.appendChild(table)

        //Alatta rakd ki az összes képet, egyéni elrendezésben! 


    }
}
getJson();