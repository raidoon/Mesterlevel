import { useState } from 'react' //a state egy változót jelent, amit a "set"-el állítunk be

const halaTomb = ['Egészség', 'Család']

const Halas = () => {
    const [szoveg, setSzoveg] = useState('')
    const [szam, setSzam] = useState(0)
    const [nyugiSzam, setNyugiSzam] = useState(0)
    function valtoztat(event) {
        setSzoveg(event.target.value)
    }
    function kattintas() {
        return setNyugiSzam(nyugiSzam + 1)
    }
    return (
        <div className="keret1" style={{ paddingBottom: '30px' }}>
            <h2>Hála</h2>
            <p>Írd be mi miatt vagy hálás!</p>
            <input type="text" value={szoveg} onChange={valtoztat} />
            <p>Emiatt vagy hálás: {szoveg}</p>
            <span>Írj be egy számot: </span>
            <input
                type="number"
                value={szam}
                onChange={(bemenet) => {
                    setSzam(bemenet.target.value)
                }}
            />
            <p>Ezt a számot adtad meg: {szam} </p>
            <p>Ezért vagyok hálás: {halaTomb[szam]}</p>
            <button onClick={kattintas}>Nyugi gomb</button>
            <p>Ennyiszer kattintottál: {nyugiSzam}</p>
        </div>
    )
}
export default Halas
