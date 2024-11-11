import React from 'react';
import { View, Text, Button } from 'react-native';

export default function Hivas1Screen({navigation}) {
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Hívás 1.</Text>
      <Button
        title="Hívás 2 képernyő meghívása"
        onPress={() => navigation.navigate('Hivas2')}
      />
    </View>
  );
}