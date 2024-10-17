const etelTomb = [
    {
        nev: 'tökfőzelék',
        ido: 20,
    },
    {
        nev: 'gombás rakott tészta',
        ido: 120,
    },
    {
        nev: 'rakott karfiol',
        ido: 100,
    },
    {
        nev: 'zöldséges tojásmuffin',
        ido: 20,
    },
    {
        nev: 'édes-savanyú ropogós tofu recept',
        ido: 45,
    },
]

const Taplalkozas = () => {
    return (
        <div className="keret2 keretZold">
            <p style={{ fontSize: 20, textAlign: 'center' }}>
                Egyél sok gyümölcsöt és zöldséget!
            </p>
            <p style={{ fontSize: 20, textAlign: 'center' }}>
                Igyál sok vizet!
            </p>
            <ul>
                {etelTomb.map((item) => (
                    <li>
                        {item.nev} ({item.ido} perc)
                    </li>
                ))}
            </ul>
            <p>Rövid idő alatt elkészíthető ételek:</p>
            <ul>
                {etelTomb.map((item) =>
                    item.ido < 30 ? (
                        <li>
                            {item.nev} ({item.ido} perc)
                        </li>
                    ) : null
                )}
            </ul>
        </div>
    )
}
export default Taplalkozas
