// Selenium Webdriver könyvtár importálása
const { Builder, By, Key, until } = require('selenium-webdriver');

// Teszt függvény definíciója async módban
async function googleSearchTest() {
  // Selenium Webdriver inicializálása
  let driver = await new Builder().forBrowser('chrome').build();

  try {
    // A böngésző megnyitása és a Google főoldalra navigálás
    await driver.get('https://www.google.com/');

    // Keresőmező kiválasztása az input elem alapján az "input" elem név attribútuma alapján
    let searchBox = await driver.findElement(By.name('q'));

    // Keresőmezőbe szöveg beírása
    await searchBox.sendKeys('Selenium testing', Key.RETURN);

    // Keresés eredményének megvárása és a találatok kinyerése
    await driver.wait(until.titleContains('Selenium testing'), 10000);

    // Találatok számának ellenőrzése
    let searchResults = await driver.findElements(By.css('h3'));
    console.log('Number of search results:', searchResults.length);
  } finally {
    // Böngésző bezárása
    await driver.quit();
  }
}

// Teszt függvény meghívása
googleSearchTest();