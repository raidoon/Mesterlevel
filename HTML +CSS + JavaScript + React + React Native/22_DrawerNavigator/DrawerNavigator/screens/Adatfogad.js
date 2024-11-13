import React from "react";
import { View, Text } from "react-native";

export default function AdatFogad({ route }) {
  const { atkuld } = route.params;
  return (
    <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
      <Text style={{ marginBottom: 30 }}>Adat fogadós képernyő</Text>
      <Text>{atkuld}</Text>
    </View>
  );
}
