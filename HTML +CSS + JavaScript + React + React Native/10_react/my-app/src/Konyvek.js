import { useState } from 'react'
import KonyvAdatok from './KonyvAdatok'
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
const Konyvek = () => {
    const [kivalasztottCim, setKivalasztottCim] = useState('')
    return (
        <div className="keret keretZold doboz">
            <div className="oszlop">
                <select
                    value={kivalasztottCim}
                    onChange={(be) => setKivalasztottCim(be.target.value)}
                    style={{ width: 'auto', fontSize: '20px' }}
                >
                    {konyvTomb.map((item) => (
                        <option value={item.cim}>
                            {item.iro}: {item.cim}
                        </option>
                    ))}
                </select>
            </div>

            <div className="oszlop">
                <KonyvAdatok kivalasztottCim={kivalasztottCim} />
            </div>
        </div>
    )
}
export default Konyvek
