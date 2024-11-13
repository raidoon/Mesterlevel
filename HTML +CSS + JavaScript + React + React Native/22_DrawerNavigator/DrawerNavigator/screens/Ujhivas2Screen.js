import React from "react";
import { View, Text, Button } from "react-native";

export default function Ujhivas2Screen({ navigation }) {
  return (
    <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
      <Text>Még egy új hívás</Text>
      <Button
        title="Vissza a Részletekhez"
        onPress={() => navigation.navigate("Részletek")}
      />
    </View>
  );
}
