import React from 'react';
import { useState, useEffect } from 'react';
import { View, Text, Button, TouchableOpacity, FlatList } from 'react-native';

export default function SajatMenu({ navigation }) {
  const [adatok,setAdatok]=useState([])
  const letoltes=async ()=>{
      const x=await fetch("http://192.168.10.57:3000/film")
      const y=await x.json()
      setAdatok(y)
      alert(JSON.stringify(y))
  }
  useEffect(()=>{
      letoltes()
  },[])
  const reszletekFv=(id,cim)=>{
    //alert(id)
    navigation.navigate('SajatMenu2',{id:id,cim:cim})
  }

  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Saját menü</Text> 
      <Button title="Átmegyünk Saját menü 2-re" onPress={() => navigation.navigate('SajatMenu2')} />
      <FlatList
        data={adatok}
        renderItem={({item}) => (
            <View>
                <Text>{item.film_cim}</Text>
                <TouchableOpacity 
                    style={{backgroundColor:"#0000ff"}} 
                    onPress={()=>reszletekFv(item.film_id, item.film_cim)}>
                  <Text style={{color:"white"}}>Részletek</Text>
                </TouchableOpacity>
            </View>
          )
        }
        keyExtractor={item => item.film_id}
      />
      <Button title='Menj az adat beírós részhez:' onPress={()=> navigation.navigate('AdatAtvitel')}/>
    </View>
  );
}