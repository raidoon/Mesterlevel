/**Fetch,  dizájnolás Bootstrap-el
-potter mappába dolgozz! Open folder , index.html, alap.js

https://github.com/Laboratoria/LIM011-data-lovers/blob/master/src/data/potter/potter.json

4. Érd el fetch-el az adatokat, írasd ki konzolra!
Írasd ki a szereplõk nevét Weblapra, 
lenyíló listába(bootstrapes, netes hivatkozas)!
Alatta írasd ki a szereplõket táblázatba(bootstrap)(neve, neme, háza, színészt)
Alatta rakd ki az összes képet, egyéni elrendezésben! */

fetch('https://github.com/Laboratoria/LIM011-data-lovers/blob/master/src/data/potter/potter.json')
.then(x => x.text())
.then(y => myDisplay(y));