import kep from "./1.jpg";
import barossKep from "./baross_logo.png";
import './App.css';
import Uzenet from "./Uzenet";
import Keruld from "./Keruld";
import Taplalkozas from "./Taplalkozas";
import Konyvek from "./Konyvek";

const lapKeszitoje={
  "nev":"raidoon",
  "iskola":"DSZC Baross"
}

function NevjegyKiir(){
  return (
    <div className="keret1">
      <p>Készítette: {lapKeszitoje.nev}</p>
      <p>{lapKeszitoje.iskola}</p>
      <img src={barossKep} alt="logo" className="kepkinezet"/>
    </div>
  )
}

//utazz!! felsorolás - sima fv
//olvass könyveket felsorolás - nyilfv
function UtazasKiir(){
  return(
    <div className="keret2 keretLila">
      <p style={{fontSize:20,textAlign:"center",fontWeight:"bold"}}>Utazz el például ide:</p>
      <ul>
        <li>Olaszország</li>
        <li>Spanyolország</li>
        <li>Norvégia</li>
      </ul>
    </div>
  )
}

var KonyvKiir=()=>{
  return(
    <div className="keret2 keretLila">
      <p style={{fontSize:20,textAlign:"center",fontWeight:"bold"}}>Olvasd el például:</p>
      <ul>
        <li>Harry Potter</li>
        <li>Trónok Harca</li>
        <li>Gyűrűk Ura</li>
        <li>Dan Brown könyvek</li>
      </ul>
    </div>
  )
}

function App() {
  return (
    <div>
      <div className="keret1">
        <h1>Élj boldogan!</h1>
        <h2>Pozitív gondolatok a boldog élethez!</h2>
        <img src={kep} alt="Smiley" className="kepkinezet"/>
      </div>
      <KonyvKiir/>
      <Uzenet/>
      <Keruld/>
      <UtazasKiir/>
      <Konyvek/>
      <Taplalkozas/>
      <NevjegyKiir/>
    </div>
  );
}
export default App;