import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, Button, ImageBackground, TouchableOpacity, Pressable, TextInput, Alert } from 'react-native';
import { useState, useEffect } from 'react';


export default function App() {
  const [vicc,setVicc] = useState("")
  const [chuckNorrisAdatok,setChuckNorrisAdatok] = useState([])
  const [szoveg, setSzoveg] = useState("")

  const tomb = [
    {
      "szoveg" : "There are only three types of people on this Earth: those who can count, and those who can't.",
      "tipus" : "favicc"
    },
    {
      "szoveg" : "Once upon a time a smart chinese man said: 精神和平永遠是重要的",
      "tipus" : "favicc"
    },
    {
      "szoveg" : "Hogy hívják a japán agglegényt? Maradoka Magamura",
      "tipus" : "favicc"
    },
    {
      "szoveg" : "Mi lesz Süsüből, ha megfőzik? Zöldbábfőzelék.",
      "tipus" : "favicc"
    },
    {
      "szoveg" : "Mi a közös a férfiakban és a reklámokban? \nEgyikük sem azt nyújtja, amit ígér.",
      "tipus" : "férfivicc"
    },
    {
      "szoveg" : "Miért nem szeretik a férfiak az útmutatókat? \nMert jobban szeretnek hibázni, meint utasításokat követni.",
      "tipus" : "férfivicc"
    },
    {
      "szoveg" : "Mi a különbség egy GPS és egy férfi között? \nA GPS képes beismerni, ha rossz úton jár.",
      "tipus" : "férfivicc"
    },
    {
      "szoveg" : "Miért nem tanulnak a férfiak az előző kapcsolataik hibáiból? \nMert mindig úgy gondolják, hogy 'az ex volt a probléma, nem én'.",
      "tipus" : "férfivicc"
    },
    {
      "szoveg" : "Hogy hívják azt a férfit, aki félreteszi a telefonját és a párjára figyel? \nNem tudom, még nem találkoztam ilyennel!",
      "tipus" : "férfivicc"
    }
  ]

  const sorsol=()=>{
    let veletlenSzam = Math.floor(Math.random()*tomb.length)
    //alert(veletlenSzam)
    setVicc(tomb[veletlenSzam].szoveg)
  }

  const letoltes = async () =>{
    let x = await fetch("https://api.chucknorris.io/jokes/random")
    let y = await x.json()
    setChuckNorrisAdatok(y)
  }

  const udvozles=()=>{
    Alert.alert("Üdvözlés","Szia "+szoveg+"!")
  }

  useEffect(()=>{
    sorsol()
    letoltes()
  },[])

  return (
    <ImageBackground source={require("./assets/appbg.jpg")} style={styles.hatterkep}>
      <View
        style={[
          styles.container,
          {
            flexDirection: 'column',
          },
        ]}>

        <View style={{flex: 2, padding:20}}>
          <Pressable onPress={() => {
            sorsol()
          }}
          style={({pressed}) => [
            {
              backgroundColor: pressed ? 'rgb(210, 230, 255)' : 'violet',
              alignItems: 'center',
              padding: 10,
              marginLeft: 30,
              marginRight: 30,
              borderRadius:20,
              fontWeight: 'bold'
            },
            styles.wrapperCustom,
          ]}>
          {({pressed}) => (
            <Text style={styles.text}>{pressed ? 'Nesze neked új poén!' : 'Új vicc'}</Text>
          )}
        </Pressable>
          <Text style={{fontSize:20,flex:2}}>{vicc}</Text>
        </View>

        <View style={{flex: 3, padding:20}}>
          <TouchableOpacity style={styles.gomb} onPress={()=>letoltes()}>
            <Text style={{fontWeight:'bold',fontSize:20,color:"white"}}>Új Chuck Norris poén</Text>
          </TouchableOpacity>
          <Text style={styles.kek}>{chuckNorrisAdatok.value}</Text>

          <TextInput
          style={styles.input}
          onChangeText={setSzoveg}
          value={szoveg}
          placeholder='írj be a neved...'/>
          <TouchableOpacity style={styles.gomb} onPress={()=>udvozles()}>
            <Text style={{fontWeight:'bold',fontSize:20,color:"white"}}>Köszönés</Text>
          </TouchableOpacity>
        </View>

        <StatusBar style="auto" />
      </View>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding:20,
    justifyContent: 'center',
    width:'100%',
    marginTop:50
  },
  kek: {
    marginTop: 10,
    color:"blue",
    fontSize:20
  },
  hatterkep: {
    resizeMode:"cover",
    justifyContent:"center",
    flex:1
  },
  gomb:{
    alignItems: 'center',
    backgroundColor: 'blue',
    padding: 10,
    marginLeft: 30,
    marginRight: 30,
    borderRadius:20,
    fontWeight: 'bold'
  },
  text:{
    fontSize:20,
    color:'white'
  },
  input:{
    marginTop: 40,
    height:40,
    margin:12,
    borderWidth: 1,
    padding:10,
    fontSize: 18
  }
});