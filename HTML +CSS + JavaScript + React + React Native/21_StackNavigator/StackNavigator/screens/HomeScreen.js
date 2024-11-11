// screens/HomeScreen.js
import { useState } from 'react';
import React from 'react';
import { View, Text, Button } from 'react-native';

export default function HomeScreen({ navigation,route }) {
  const {visszakuld}=route.params
  const [vissza,setVissza] = useState("sajt")
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Kezdőlap</Text>
      <Text>{vissza}</Text>
      <Button
        title="Részletek megtekintése"
        onPress={() => navigation.navigate('Details')}
      />
      <Button
        title="Saját oldal meghívása"
        onPress={() => navigation.navigate('Sajat')}
      />
      <Button
        title="Hívás 1 képernyő meghívása"
        onPress={() => navigation.navigate('Hivas1')}
      />
      <Button
        title="Adat küldés 1. képernyő meghívása"
        onPress={() => navigation.navigate('AdatKuld1',{atkuld:"ez egy átküldött adat"})} //vessző után megadhatjuk az adato(ka)t ami(ke)t át akarunk vinni a képernyők között
      />
    </View>
  );
}