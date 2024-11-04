import AsyncStorage from '@react-native-async-storage/async-storage';
import { useEffect, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';

export default function App() {
  const storeData = async (value) => {
    try {
      const jsonValue = JSON.stringify(value);
      await AsyncStorage.setItem('szemely', jsonValue);
    } catch (e) {
      // saving error
    }
  };

  useEffect(()=>{
    let szemely ={
      "id":0,
      "nev":"Szemely1",
      "email":"pelda@gmail.com"
    }
    storeData(szemely)
  },[])

  return (
    <View style={styles.container}>
      <Text>Hello!</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});