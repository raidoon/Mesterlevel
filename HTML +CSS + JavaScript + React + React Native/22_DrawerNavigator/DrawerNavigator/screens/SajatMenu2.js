import React from 'react';
import { View, Text, Button } from 'react-native';
export default function SajatMenu2({navigation, route}) {
    const {id} = route.params
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Saját Menü 2</Text>
      <Text>{id}</Text>
      <Button title="Új hívás" onPress={() => navigation.navigate('UjhivasScreen')} />
      <Button title="Egy újabb hívás, hogy gyakoroljak" onPress={() => navigation.navigate('Ujhivas2Screen')} />
    </View>
  );
}
