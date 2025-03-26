// Selenium Webdriver könyvtár importálása
const { Builder, By } = require('selenium-webdriver');

// Teszt függvény definíciója async módban
async function openOrigo() {
  // Selenium Webdriver inicializálása
  let drivers = [];
  let numTabs = 5;
  try {
    // 100-szor ismételt Origo.hu megnyitása
    for (let i = 0; i < numTabs; i++) {
      // Minden egyes iterációban egy új WebDriver-t hozunk létre és tárolunk
      drivers.push(new Builder().forBrowser('chrome').build());
    }

    // Az összes WebDriver-rel egyidejűleg nyissuk meg az Origo.hu-t
    await Promise.all(drivers.map(async (driver, index) => {
      await driver.get('https://www.origo.hu/');
      console.log(`Opened Origo.hu in tab ${index + 1}`);
    }));
  } finally {
    // Minden WebDriver bezárása
    await Promise.all(drivers.map(async (driver) => {
      await driver.quit();
    }));
  }
}

// Teszt függvény meghívása
openOrigo();
