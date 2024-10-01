const konyvTomb=[
    {
        "cim":"Harry Potter",
        "hossz":400,
        "ar":3000,
        "iro":"J.K. Rowling"
    },
    {
        "cim":"Gyűrűk Ura",
        "hossz":500,
        "ar":4000,
        "iro":"J.R.R. Tolkien"
    },
    {
        "cim":"Trónok harca",
        "hossz":816,
        "ar":4799,
        "iro":"George R.R. Martin"
    }
]
const Konyvek = () =>{
    return(
        <div className="lenyiloDiv">
            <select style={{width:"200px",fontSize:"20px"}}>
                {konyvTomb.map(item=>(
                    <option>{item.iro}:{item.cim}</option>
                ))}
            </select>
        </div>
    )
}
export default Konyvek