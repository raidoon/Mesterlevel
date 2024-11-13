import React from "react";
import { View, Text, Button } from "react-native";

export default function SzavazatFelvitel({ navigation }) {
  return (
    <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
      <Text>Új szavazat felvitele az adatbázisba</Text>
      <Button
        title="Új hívás"
        onPress={() => navigation.navigate("UjhivasScreen")}
      />
    </View>
  );
}
