import { useState, useEffect } from 'react';
import { StyleSheet, Text, View, Image } from 'react-native';

export default function App() {
  const [adatok,setAdatok] = useState([])
  const letoltes=async()=>{
    const x = await fetch("http:192.168.10.57:3000/film")
    const y = await x.json()
    setAdatok(y)
    //alert(JSON.stringify(y))
  }

  useEffect(()=>{
    letoltes()
  },[])
  return (
    <View style={styles.container}>
      <Text>Marvel filmek</Text>
      <Image source={{uri: 'http:192.168.10.57:3000/kep1.jpg'}} style={{height: 500, width: 300, marginTop: 50}}/>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    marginTop: 50
  },
});
