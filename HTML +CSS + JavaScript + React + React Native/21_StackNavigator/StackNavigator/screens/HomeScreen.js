// screens/HomeScreen.js
import React from 'react';
import { View, Text, Button } from 'react-native';

export default function HomeScreen({ navigation }) {
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Kezdőlap</Text>
      <Button
        title="Részletek megtekintése"
        onPress={() => navigation.navigate('Details')}
      />
      <Button
        title="Saját oldal meghívása"
        onPress={() => navigation.navigate('Sajat')}
      />
    </View>
  );
}