import React from "react";
import { View, Text, Button } from "react-native";

export default function DetailsScreen({ navigation }) {
  return (
    <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
      <Text>Details Screen</Text>
      <Button
        title="Új hívás"
        onPress={() => navigation.navigate("UjhivasScreen")}
      />
      <Button
        title="Egy újabb hívás, hogy gyakoroljak"
        onPress={() => navigation.navigate("Ujhivas2Screen")}
      />
    </View>
  );
}
