fetch("https://api.nobelprize.org/v1/prize.json")
.then(x => x.json())
.then(y => megjelenites(y))

function megjelenites(y){
    console.log(y)
    prizes=y
}