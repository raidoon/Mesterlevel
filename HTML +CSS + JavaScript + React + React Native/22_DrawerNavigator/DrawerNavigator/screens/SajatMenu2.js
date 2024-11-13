import React from "react";
import { useState, useEffect } from "react";
import { View, Text, Button } from "react-native";
import SzavazatFelvitel from "./szavazatFelvitel";

export default function SajatMenu2({ navigation, route }) {
  const { id, cim } = route.params;
  const [adatok, setAdatok] = useState([]);
  const letoltes = async () => {
    var adatok = {
      bevitel1: id,
    };
    const x = await fetch("http://192.168.10.57:3000/szavazatDb", {
      method: "POST",
      body: JSON.stringify(adatok),
      headers: { "Content-type": "application/json; charset=UTF-8" },
    });
    const y = await x.json();
    setAdatok(y);
    alert(JSON.stringify(y));
  };
  useEffect(() => {
    letoltes();
  }, []);
  return (
    <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
      <Text>Saját Menü 2</Text>
      <Text>{id}</Text>
      <Text>{cim}</Text>
      {/* Conditional rendering: Check if adatok[0] exists before accessing its properties */}
      {adatok[0] ? <Text>{adatok[0].db}</Text> : <Text>Loading data...</Text>}
      <Button
        title="Új hívás" 
        onPress={() => navigation.navigate("UjhivasScreen")}
      />
      <Button
        title="Egy újabb hívás, hogy gyakoroljak"
        onPress={() => navigation.navigate("Ujhivas2Screen")}
      /> 
      <SzavazatFelvitel/>
    </View>
  );
}
