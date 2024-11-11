import React from 'react';
import { View, Text, Button} from 'react-native';

export default function Hivas2Screen({navigation}) {
  return (
    <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
      <Text>Hívás 2.</Text>
      <Button onPress={()=> navigation.navigate("Home")} title='Vissza a kezdő képernyőre'/>
    </View>
  );
}