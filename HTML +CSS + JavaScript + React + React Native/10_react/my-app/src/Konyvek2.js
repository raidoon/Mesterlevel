import { useState } from 'react'
import KonyvAdatok2 from './KonyvAdatok2'
const konyvTomb = [
    {
        cim: 'Harry Potter',
        hossz: 400,
        ar: 3000,
        iro: 'J.K. Rowling',
    },
    {
        cim: 'Gyűrűk Ura',
        hossz: 500,
        ar: 4000,
        iro: 'J.R.R. Tolkien',
    },
    {
        cim: 'Trónok harca',
        hossz: 816,
        ar: 4799,
        iro: 'George R.R. Martin',
    },
]
const Konyvek2 = () => {
    const [kivalasztottSzama, setKivalasztottSzama] = useState(0)
    return (
        <div className="keret keretZold doboz">
            <div className="oszlop">
                <select
                    value={kivalasztottSzama}
                    onChange={(be) => setKivalasztottSzama(be.target.value)}
                    style={{ width: 'auto', fontSize: '20px' }}
                >
                    {konyvTomb.map((item, index) => (
                        <option value={index}>
                            {item.iro}: {item.cim}
                        </option>
                    ))}
                </select>
            </div>

            <div className="oszlop">
                <KonyvAdatok2
                    kivalasztottCim={konyvTomb[kivalasztottSzama].cim}
                    kivalasztottSzama={konyvTomb[kivalasztottSzama]}
                    kivalasztottHossz={konyvTomb[kivalasztottSzama].hossz}
                    kivalasztottAr={konyvTomb[kivalasztottSzama].ar}
                    kivalasztottIroja={konyvTomb[kivalasztottSzama].iro}
                />
            </div>
        </div>
    )
}
export default Konyvek2
