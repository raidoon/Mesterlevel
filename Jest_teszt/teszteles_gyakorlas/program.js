function add(a, b) {
    return a + b;
  }

function visszaAdSzo(szoveg,szam){
    var kecske = szoveg.split(" ")
    if(szam>0 && szam<kecske.length+1)
        return kecske[szam-1]
    else
        return ""
}
module.exports = { add, visszaAdSzo };