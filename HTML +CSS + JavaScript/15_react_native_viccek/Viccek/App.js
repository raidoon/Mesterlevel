import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, Button } from 'react-native';
import { useState, useEffect } from 'react';

export default function App() {
  const [vicc,setVicc] = useState("")
  const [chuckNorrisAdatok,setChuckNorrisAdatok] = useState([])

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

  useEffect(()=>{
    sorsol()
    letoltes()
  },[])

  return (
    <View
      style={[
        styles.container,
        {
          flexDirection: 'column',
        },
      ]}>
      <View style={{flex: 2, backgroundColor: 'darkorange',padding:20}}>
        <Button style={styles.gomb} title='Új vicc' onPress={()=>sorsol()}/>
        <Text style={{fontSize:20,flex:2}}>{vicc}</Text>
      </View>
      <View style={{flex: 3, backgroundColor: 'green',padding:20}}>
        <Button style={styles.gomb} title='Új Chuck Norris poén' onPress={()=>letoltes()}></Button>
        <Text style={styles.kek}>{chuckNorrisAdatok.value}</Text>
      </View>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding:20,
    backgroundColor: '#fff',
    justifyContent: 'center',
    width:'100%',
    marginTop:30
  },
  kek:{
    color:"white",
    fontSize:20
  },
  gomb:{
    width:50
  }
});
