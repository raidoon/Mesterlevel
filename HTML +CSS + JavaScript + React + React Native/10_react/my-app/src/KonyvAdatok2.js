const KonyvAdatok2 = ({
    kivalasztottCim,
    kivalasztottHossz,
    kivalasztottAr,
    kivalasztottIroja,
}) => {
    return (
        <div>
            <p>Ez a könyv lett kiválasztva: {kivalasztottCim}</p>
            <p>Hossza: {kivalasztottHossz} oldal</p>
            <p>Ára: {kivalasztottAr} Ft</p>
            <p>Írója: {kivalasztottIroja}</p>
        </div>
    )
}
export default KonyvAdatok2
