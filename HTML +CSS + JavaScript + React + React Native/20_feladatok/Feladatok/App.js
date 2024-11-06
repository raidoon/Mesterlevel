import { useState,useEffect } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { StyleSheet, Text, View, Button, FlatList,TextInput } from 'react-native';
import DateTimePicker from '@react-native-community/datetimepicker';

export default function App() {
  const [adatTomb,setAdatTomb] = useState([])
  const [szoveg,setSzoveg] = useState("")
  const [date, setDate] = useState(new Date());
  const [mode, setMode] = useState('date');
  const [show, setShow] = useState(false); //datetimepicker nem látható eredetileg

  const onChange = (event, selectedDate) => {
    const currentDate = selectedDate;
    setShow(false);
    setDate(currentDate);
  };

  const showMode = () => {
    setShow(true);
    setMode("date");
  };

  const storeData = async (value) => {
    try {
      const jsonValue = JSON.stringify(value);
      await AsyncStorage.setItem('feladatok', jsonValue);
    } catch (e) {
      // saving error
    }
  };

  const getData = async () => {
    try {
      const jsonValue = await AsyncStorage.getItem('feladatok');
      return jsonValue != null ? JSON.parse(jsonValue) : []; //null helyett üres tömb, hogy akkor is tudjon pusholni, ha nincs bent adat
    } catch (e) {
      // error reading value
    }
  };

  useEffect(()=>{
    /*
      let szemely={
        "id":0,
        "nev":"Raidoon",
        "email":"pelda@gmail.com"
      }
      storeData(szemely)
      */
     /*
      let tomb=[
        {
          "id":0,
          "feladat":"verseny Debrecen",
          "datum":"2024.11.08",
          "kesz":0
        },
        {
          "id":1,
          "feladat":"fogászat Debrecen",
          "datum":"2024.11.12",
          "kesz":0
        }
     ]
     storeData(tomb)*/

    getData().then(adat=>{
      alert(JSON.stringify(adat))
      setAdatTomb(adat)
    })
  },[])

  const felvitel=()=>{
    let uj = adatTomb
    uj.push({
      "id":uj.length,
      "feladat":szoveg,
      "datum":"2024/11/20",
      "kesz":0
    })
    setAdatTomb(uj)
    storeData(uj)
    alert("Új feladat hozzáadva!")
  }

  const torles=()=>{
    let uj=[]
    setAdatTomb(uj)
    storeData(uj)
    alert("Sikeres törlés!")
  }

  return (
    <View style={styles.container}>
      <Text  style={{marginTop: 30, color: "blue", fontSize: 18}}>Feladat:</Text>

      <TextInput 
      style={styles.input}
      onChangeText={setSzoveg}
      value={szoveg}
      />

      <Button title='DÁTUM' onPress={showMode}></Button>

      <Button title='ÚJ FELADAT' onPress={felvitel}></Button>


      <Text style={{fontSize: 13, marginTop: 5, marginBottom: 10}}>korábbiak</Text>

      <Button title='Feladatok törlése' onPress={torles}></Button>

      <FlatList
        data={adatTomb}
        renderItem={({item,index}) => 
        <View style={styles.keret}>
          <Text style={styles.Datum}>{item.datum}</Text>
          <Text style= {styles.Feladat}>{item.feladat}</Text>
        </View>
        }
        keyExtractor={(item,index) => index.toString()}
      />

      {show && (
        <DateTimePicker
          testID="dateTimePicker"
          value={date}
          mode={mode}
          is24Hour={true}
          onChange={onChange}
        />
      )}

    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    marginTop: 50,
    marginLeft: 30,
    marginRight: 30,
    backgroundColor: '#fff',
  },
  keret: {
    margin: 5,
    borderWidth: 2,
    padding: 5,
    borderColor: "grey",
    borderRadius: 10
  },
  Datum:{
    fontStyle: 'italic',
    color: 'blue',
    marginBottom: 5,
    marginTop:5
  },
  Feladat: {
    marginBottom: 5,
    fontSize: 20
  },
  input: {
    fontSize: 18,
    borderWidth: 1,
    borderColor: 'blue',
    margin: 5,
    padding: 5,
    borderRadius: 10,
    marginBottom: 15
  }
});