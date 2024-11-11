import React from 'react';
import { View, Text, Button } from 'react-native';

export default function AdatKuld1Screen({navigation,route}) {
  const {atkuld} = route.params
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Adat küldés egyik screenről a másikra 1.</Text>
      <Text>{atkuld}</Text>
      <Button
        title="Adat küldés 2 képernyő meghívása"
        onPress={() => navigation.navigate('AdatKuld2')}
      />
    </View>
  );
}