import React from "react";
import { View, Text, Button } from "react-native";

export default function UjhivasScreen({ navigation }) {
  return (
    <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
      <Text>Új hívás !!</Text>
      <Button
        title="Vissza a kezdőlapra"
        onPress={() => navigation.navigate("Home")}
      />
    </View>
  );
}
