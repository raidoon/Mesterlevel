import React from 'react';
import { useState } from 'react';
import { View, Text, Button} from 'react-native';

export default function AdatKuld2Screen({navigation,route}) {
    const {atkuld} = route.params
    const [visszakuld,setVisszakuld] = useState("zsaluzás")
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text style={{marginBottom:30}}>Adat küldés 2. képernyő</Text>
      <Text>{atkuld}</Text>
      <Text>{visszakuld}</Text>
      <Button
        title="Vissza az első oldalra"
        onPress={() => navigation.navigate('Home',{visszakuld:visszakuld})}
      />
    </View>
  );
}