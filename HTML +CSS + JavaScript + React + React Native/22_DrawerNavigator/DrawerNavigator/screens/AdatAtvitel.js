import React from "react";
import { useState } from "react";
import { View, Text, Button, TextInput } from "react-native";

export default function AdatAtvitel({ navigation }) {
  const [szoveg, setSzoveg] = useState("");
  return (
    <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
      <Text>Adat küldés egyik screenről a másikra</Text>
      <TextInput
        value={szoveg}
        onChangeText={setSzoveg}
        style={{
          backgroundColor: "grey",
          width: 250,
          margin: 30,
          color: "white",
        }}
      />
      <Button
        title="Adat fogadós képernyő meghívása"
        onPress={() => navigation.navigate("AdatFogad", { atkuld: szoveg })}
      />
    </View>
  );
}
