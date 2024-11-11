import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import HomeScreen from './screens/HomeScreen';
import DetailsScreen from './screens/DetailsScreen';
import SajatScreen from './screens/SajatScreen';

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Home">
        <Stack.Screen name="Home" component={HomeScreen} options={{ title: 'Főoldal' }} />
        <Stack.Screen name="Details" component={DetailsScreen} options={{ title: 'Részletek' }} />
        <Stack.Screen name="Sajat" component={SajatScreen} options={{ title: 'Saját' }} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}