import React from 'react';
import { useState } from 'react';
import { View, Text, Button, TextInput } from 'react-native';

export default function AdatKuld1Screen({navigation,route}) {
  const {atkuld} = route.params
  const [szoveg,setSzoveg] = useState("")
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Adat küldés egyik screenről a másikra 1.</Text>
      <Text>{atkuld}</Text>
      <TextInput value={szoveg} 
            onChangeText={setSzoveg} 
            style={{
                backgroundColor:"grey",
                width:250,
                margin: 30,
                color:'white'}}/>
      <Button
        title="Adat küldés 2 képernyő meghívása"
        onPress={() => navigation.navigate('AdatKuld2',{atkuld:szoveg})}
      />
    </View>
  );
}