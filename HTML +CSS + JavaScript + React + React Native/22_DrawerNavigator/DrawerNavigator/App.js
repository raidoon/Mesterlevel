import * as React from "react";

import { NavigationContainer } from "@react-navigation/native";
import { createDrawerNavigator } from "@react-navigation/drawer";
import { createStackNavigator } from "@react-navigation/stack";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";

import HomeScreen from "./screens/HomeScreen";
import SettingsScreen from "./screens/SettingsScreen";
import DetailsScreen from "./screens/DetailsScreen";
import SajatMenu from "./screens/SajatMenu";
import UjhivasScreen from "./screens/UjhivasScreen";
import Ujhivas2Screen from "./screens/Ujhivas2Screen";
import AdatAtvitel from "./screens/AdatAtvitel";
import AdatFogad from "./screens/Adatfogad";
import Ionicons from "react-native-vector-icons/Ionicons";
import SajatMenu2 from "./screens/SajatMenu2";

const Drawer = createDrawerNavigator();
const Stack = createStackNavigator();
const Tab = createBottomTabNavigator(); // Tab Navigator létrehozása

function DetailsStack() {
  return (
    <Stack.Navigator>
      <Stack.Screen name="Részletek" component={DetailsScreen} />
      <Stack.Screen name="UjhivasScreen" component={UjhivasScreen} />
      <Stack.Screen name="Ujhivas2Screen" component={Ujhivas2Screen} />
    </Stack.Navigator>
  );
}

function SajatMenusStack() {
  return (
    <Stack.Navigator>
      <Stack.Screen name="SajatMenu" component={SajatMenu} />
      <Stack.Screen name="SajatMenu2" component={SajatMenu2} />
      <Stack.Screen name="AdatAtvitel" component={AdatAtvitel} />
      <Stack.Screen name="AdatFogad" component={AdatFogad} />
    </Stack.Navigator>
  );
}

// Fő alkalmazás a Drawer Navigatorral
export default function App() {
  return (
    <NavigationContainer>
      <Drawer.Navigator initialRouteName="Home">
        <Drawer.Screen name="Home" component={HomeTabs} />
        <Stack.Screen name="Details" component={DetailsStack} />
        <Drawer.Screen name="Settings" component={SettingsScreen} />
        <Drawer.Screen name="Saját menüm" component={SajatMenusStack} />
      </Drawer.Navigator>
    </NavigationContainer>
  );
}

// Tab Navigator funkció a Home és Settings képernyőkhöz
function HomeTabs() {
  return (
    <Tab.Navigator
      screenOptions={({ route }) => ({
        tabBarIcon: ({ focused, color, size }) => {
          let iconName;

          if (route.name === "Kezdőlap") {
            iconName = focused ? "home" : "home-outline";
          } else if (route.name === "Settings") {
            iconName = focused ? "settings" : "settings-outline";
          } else if (route.name === "SajatMenu") {
            iconName = focused ? "boat" : "boat-outline";
          }
          // Az ikon komponens renderelése
          return <Ionicons name={iconName} size={size} color={color} />;
        },
        tabBarActiveTintColor: "tomato",
        tabBarInactiveTintColor: "gray",
      })}
    >
      <Tab.Screen name="Kezdőlap" component={HomeScreen} />
      <Tab.Screen name="Settings" component={SettingsScreen} />
      <Tab.Screen name="SajatMenu" component={SajatMenusStack} />
    </Tab.Navigator>
  );
}
