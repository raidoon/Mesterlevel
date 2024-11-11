import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import HomeScreen from './screens/HomeScreen';
import DetailsScreen from './screens/DetailsScreen';
import SajatScreen from './screens/SajatScreen';
import Hivas1Screen from './screens/Hivas1Screen';
import Hivas2Screen from './screens/Hivas2Screen';
import AdatKuld1Screen from './screens/AdatKuld1Screen';
import AdatKuld2Screen from './screens/AdatKuld2Screen';

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Home">
        <Stack.Screen name="Home" component={HomeScreen} options={{ title: 'Főoldal' }} />
        <Stack.Screen name="Details" component={DetailsScreen} options={{ title: 'Részletek' }} />
        
        <Stack.Screen name="Sajat" component={SajatScreen} options={{ title: 'Saját' }} />
        
        <Stack.Screen name="Hivas1" component={Hivas1Screen} options={{ title: 'Hívás1' }} />
        <Stack.Screen name="Hivas2" component={Hivas2Screen} options={{ title: 'Hívás2' }} />
        
        <Stack.Screen name="AdatKuld1" component={AdatKuld1Screen} options={{ title: 'AdatKüld1' }} />
        <Stack.Screen name="AdatKuld2" component={AdatKuld2Screen} options={{ title: 'AdatKüld2' }} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}