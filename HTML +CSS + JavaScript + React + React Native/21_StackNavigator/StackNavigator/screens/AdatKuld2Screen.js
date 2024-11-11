import React from 'react';
import { View, Text, Button} from 'react-native';

export default function AdatKuld2Screen({navigation,route}) {
    const {atkuld} = route.params
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text style={{marginBottom:30}}>Adat küldés 2. képernyő</Text>
      <Text>{atkuld}</Text>
    </View>
  );
}