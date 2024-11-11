-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Okt 09. 14:05
-- Kiszolgáló verziója: 10.4.6-MariaDB
-- PHP verzió: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kiadok`
--
CREATE DATABASE IF NOT EXISTS `kiadok` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `kiadok`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kiado`
--

CREATE TABLE `kiado` (
  `id` int(11) NOT NULL,
  `cim` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `nev` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `www` varchar(50) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=4096 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `kiado`
--

INSERT INTO `kiado` (`id`, `cim`, `nev`, `www`) VALUES
(1, '1066 Budapest, Nyugati tér 1.', 'Libri Könyvkiadó Kft.', 'http://libri.libricsoport.hu'),
(2, '1024 Budapest, Fillér u. 9-11.', 'Typotex Elektronikus Kiadó Kft.', 'https://www.typotex.hu'),
(3, '1134 Budapest, Csángó u. 8.', 'Kiskapu Kiadó, Kereskedelmi és Szolgáltató Kft.', 'http://www.kiskapu.hu'),
(4, '1086 Budapest, Dankó u. 4-8.', 'Líra Könyv Zrt.', 'https://www.lira.hu'),
(5, '1148 Budapest, Vezér u. 148 - 150. 1. em', 'Panem Kiadó', 'http://www.panem.hu');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `konyv`
--

CREATE TABLE `konyv` (
  `konyv_id` int(10) UNSIGNED NOT NULL,
  `szerzo` varchar(25) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `konyvcim` varchar(70) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `isbn` varchar(18) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `ar` int(5) DEFAULT NULL,
  `kiado_id` int(10) DEFAULT NULL,
  `kep` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `leiras` text COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=157 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `konyv`
--

INSERT INTO `konyv` (`konyv_id`, `szerzo`, `konyvcim`, `isbn`, `ar`, `kiado_id`, `kep`, `leiras`) VALUES
(1, 'Dr. Guta Gábor', 'Szoftverfejlesztés okosan Pythonnal - Agilis csapatok közös nyelve', '9786155186745', 3315, 3, 'Python.jpg', 'A Python nemcsak népszerű és modern programozási nyelv, hanem könnyen tanulható és hatékony eszköz is. Az IT szakmában a fejlesztők és egyéb programozási tudást nem igénylő munkakört végzők között kialakulhat egy szakadék, ami sokszor okoz nehézséget. Ezzel a könyvvel a szerző ezt a szakadékot szeretné áthidalni. A könyv új megközelítésben tárgyalja a programozási nyelvet: hat, mindenki számára ismerős koncepció mentén mutatja be. A könyv szemlélete hasznos azoknak a fejlesztőknek, akik szeretnének gyorsan, professzionális Python-tudásra szert tenni, míg az első saját program megírásán gondolkodó kezdők ismerős koncepció mentén tudják elsajátítani a nyelvet.A könyv gyakorlatias megközelítése, rengeteg példával segíti a hatékony, gyors tanulást. A fejezetek végén a technikai részleteket referencia-szekcióba gyűjtöttük, így sokáig hasznos társunk lehet kézikönyvként is'),
(2, 'Richard Blum', 'PHP, MySQL &amp; JavaScript 7 könyv 1-ben', '9786155186721', 8455, 5, 'Php_mysql.jpg', 'Ezt a könyvet tekintsd egy kézikönyvnek.A könyvben az összes olyan különböző, dinamikus webalkalmazások létrehozásához használt technológiával foglalkozunk, amely képes adatokat nyomon követni, és rendezett és kellemes módon megjeleníteni azokat. Számos olyan témakörrel foglalkozunk, amellyel tisztában kell lenned ahhoz, hogy teljes funkcionalitású dinamikus webalkalmazásokat hozz létre: a web alapvető elrendezésének kialakítása; stílusának kezelése; dinamikus funkciók; szerverek kihasználása; adatok tárolása; teljes alkalmazások létrehozása; segítő programok használata.\r\nFőbb témakörök: 1.könyv:Ismerkedjünk meg a webprogramozással 2.könyv: HTML és a CSS3 3.könyv:JavaScript 4.könyv: PHP 5.könyv: MySQL 6. könyv: Készítsünk objektumorientált programokat 7. könyv: Használjunk PHP-keretrendszereket Letölthető kódok'),
(3, 'Stephen R. Davis', 'C ++ - Tantusz könyvek - Mindenről könnyedén!', '9786155186790', 5605, 5, 'c++.jpg', 'Ha kezdő C++ programozóból mesterré akarsz válni akkor ez a könyv, amire szükséged van.\r\nA C++ 2014-es legújabb változásait tükrözi, és bemutatja, hogyan értelmezd az osztályokat, a modulokat az öröklődést és még sok minden mást.\r\nMegtanulhatsz C++-ul beszélni, szemléltető - és a saját gépedre letölthető - kódrészletek segítenek a funkciók megismerésében\r\nA kötet nem egy konkrét operációs rendszerhez íródott, így használhatod, bármilyen rendszeren is dolgozol. Külön rész foglakozik a hibák és a hekkerek kezelésével.\r\nA könyv támogatásával bátran neki lehet kezdeni a C++-ban a programkészítéshez!\r\n1. rész: Ismerkedjünk meg a C++ programozással\r\n2. rész: Váljunk funkcionális C++ programozóvá\r\n3. rész: Ismerkedjünk meg az osztályokkal\r\n4. rész: Öröklődés\r\n5. rész: Biztonság\r\n6. rész: TOP 10'),
(4, 'Barry Burd', 'Java - Tantusz Könyvek', '9786155186523', 4655, 5, 'Java.jpg', 'A szerző így kezdi: &quot;A Java jó cucc. Én már évek óta használom. Szeretem, mert nagyon szabályos. Szinte minden egyszerű szabályokat követ benne. Ezek a szabályok időnként félelmetesnek tűnhetnek, de ez a könyv segít megoldani a nehézségeket. Tehát, ha használni szeretnéd a Javát, és szeretnél a szakembereknek szóló, szokásos könyvektől eltérő olvasmányt, akkor már el is kezdheted olvasni a Tantusz könyvek Java 2.. kiadásának kötetét.&quot;\r\n&quot;Nem kell a Windows, UNIX vagy Macintosh &quot;kiemelt&quot; felhasználójának lenned, de el kell tudnod indítani egy programot, megtalálni vagy berakni egy állományt a megfelelő könyvtárba stb. Az idő legnagyobb részében, amikor a könyvben lévő anyagot gyakorlod, kódokat fogsz gépelni a billentyűzeteden, nem pedig az egeret mozgatni és nyomogatni. Minden könyvben használt kód elérhető a www.panem.hu honlapon a szabad letöltések között.\r\nVégül minden olvasó eljuthat odáig, hogy önállóan tudjon Java programot írni. Sok sikert mindenkinek a JAV 9 használatához.'),
(5, 'Kris Hadlock', 'Webalkalmazások fejlesztése Ajax segítségével', '9789639637238', 1330, 3, 'ajax.jpg', 'Az Ajax egyike a legújabb és legnagyszerűbb módszereknek, amelyek arra irányulnak, hogy élvezetesebbé tegyék a böngészést az Interneten, és új, izgalmas szolgáltatásokat nyújtsanak. Azáltal, hogy lehetővé teszi a weblapok egyes részeinek, hogy a teljes oldal frissítése nélkül jelenjenek meg, az Ajax jelentősen javítja a webalkalmazások nyújtotta élményt, a webfejlesztőknek pedig eszközt ad ahhoz, hogy könnyen és újszerűen használható, interaktív programokat építsenek.\r\nA Webalkalmazások fejlesztése Ajax segítségével olyan mélyreható ismereteket nyújt az Ajaxról, amelyek szükségesek ahhoz, hogy a fejlesztők webalkalmazásaikat magasabb szintre emeljék. A kötet bemutatja, hogyan készíthetünk Ajax-vezérelt webalkalmazásokat objektumközpontú szemlélettel, és ismertet több hasznos tervezési mintát is.\r\nA könyv részletes útmutatójában megtaláljuk, hogyan kapcsolódhatunk egy MySQL adatbázishoz PHP 5 kóddal egy saját Ajax-motoron keresztül, és hogyan formázhatjuk elegánsan a választ CSS-sel, JavaScripttel és XHTML-lel, miközben szigorúan megőrizzük az adatok biztonságát. A kötet ezek mellett négy egyéni Ajax-képes összetevő használatát is bemutatja egy mintaprogramban, és leírja azt is, hogyan lehet ezeket elkészíteni.\r\nA könyv utolsó része a korábbi fejezetekben bemutatott önálló kódpéldákat és eljárásokat egyetlen nagyobb, Ajax-vezérelt alkalmazásban egyesíti egy olyan belső webes levelező programban, amelyet bármilyen felhasználó alapú webhelyen (mondjuk egy webes közösségben is) felhasználhatunk. Az Olvasó nem csak azt tanulja meg, hogyan készíthet és használhat saját, újrahasznosítható Ajax-összetevőket, hanem azt is, hogy miként kapcsolhatja azokat később felépítendő Ajax-alkalmazásokhoz.'),
(6, 'Brenden Johnson', 'XEN a gyakorlatban - Útmutató a virtualizáció művészetéhez', '0669003686644', 5890, 3, 'xen.jpg', 'Az ingyenes, nyílt forrású virtualizációs szoftver, a Xen használatával pénzt takaríthatunk meg, nagyobb rugalmasságot érhetünk el, javíthatunk az erőforrások kihasználásán, és a katasztrófák utáni talpraállástól a szoftvertesztelésig mindent egyszerűsíthetünk. Ebben a könyvben összegyűjtöttük mindazt a tudást, ami a nagy teljesítményű Xen virtuális gépek felállításához és kezeléséhez szükséges a különféle környezetekben. A kötet egy világszínvonalú Xen-csapat páratlan tapasztalataira építve, minden témakörre kiterjedően tárgyalja a Xen használatát, a telepítéstől a felügyeletig. Szerzői olyan, a gyakorlatban már bizonyított módszereket és eljárásokat, valamint esettanulmányokat mutatnak be, amelyeket máshol nem találunk meg. A szerzők először a virtualizáció alapjait - a fogalmakat, alkalmazási területeket és előnyöket - ismertetik, majd bemutatják a Xen képességeit, a Xen LiveCD tartalmát és a Xen-hiperfelügyelőt, valamint végigvezetnek a saját merevlemez alapú Xen-telepítésünk beállításának lépésein. Miután a Xen már fut, megtanuljuk a legjobb módszert a &quot;vendégek&quot; létrehozására és a meglevő rendszerek Xen-vendégként való futtatására. A könyv kimerítően tárgyalja a Xen-vendégek, az eszközök, hálózatok és elosztott erőforrások kezelését és biztosítását. A rendszergazdák, adatközpont-kezelők, fejlesztők, rendszerintegrátorok és internetszolgáltatók egyaránt hasznát vehetik ennek a kötetnek, amely segít, hogy a Xennel elérjék a céljukat: megbízható, hatékony, kiemelkedő teljesítményű rendszerek felállítását - meglepően kis költséggel.'),
(7, 'Bill von Hagen; Brian K. ', 'Linux bevetés közben (Második küldetés)', '0109001705089', 4990, 3, 'linux.jpg', 'A Linux kiszolgálók üzemeltetői akár naponta szembesülhetnek a legkülönbözőbb, esetleg komoly fejtörést okozó problémákkal. Aki megvette ennek a könyvnek az első részét, az valószínűleg már tapasztalhatta, mennyire hasznos, ha van az ember keze ügyében egy olyan információforrás, amiben az alkalmazások leírása helyett konkrét problémák vagy problémakörök egyszerű megoldásait találhatja meg. A hibalehetőségek száma persze jóval nagyobb annál, semhogy az összes tipp és trükk elférjen egyetlen kötetben. Itt van tehát a folytatás, amely ismét száz adminisztratív feladatot tárgyal témakörönként csoportosítva. Íme néhány az érintett területek közül:\r\nHitelesítés\r\nTávoli grafikus kapcsolat\r\nTárhelyek kezelése\r\nFájlok megosztása és erőforrások szinkronizálása\r\nBiztonsággal kapcsolatos kérdések\r\nNaplófájlok és megfigyelés\r\nHibakeresési módszerek\r\nAdatmentés, visszaállítás, katasztrófaelhárítás\r\nEzt a kötetet ugyanúgy elejétől a végéig el lehet olvasni, mint bármely más könyvet, de ha a sors úgy hozza, akár néhány perc alatt itt értékes információkhoz juthatunk belőle, ha felütjük a megfelelő helyen. Nem kell súgóoldalakat vagy weblapokat böngészni, uram bocsá&#039; a forráskódban elhelyezett megjegyzések között keresgélni. Hasznos olvasmány és segédeszköz minden rendszergazdának.'),
(8, 'Pere László', 'GNU/Linux rendszerek üzemeltetése II.', '0669002904725', 1430, 3, 'linux-pere-2.jpg', 'Ez a könyv Pere László GNU/Linux rendszerek üzemeltetéséről szóló sorozatának második kötete, s az előzőhöz hasonlóan azoknak a rendszergazdáknak, illetve a számítástechnikával hobbiból foglalkozó olvasóknak kíván segítséget nyújtani, akik munkahelyükön, vagy otthon kisebb-nagyobb hálózatokat üzemeltetnek. Míg az első kötet egy Linux rendszer általános felépítését és belső működését mutatta be, addig a folytatás a számítógép-hálózatok építését és üzemeltetését, a hálózati alkalmazások és szolgáltatások telepítését és azok beállítását tárgyalja. Sorra kerül gyakorlatilag minden olyan feladat és probléma, amely egy helyi hálózat kialakítása közben felmerülhet, így a könyvben tárgyalt ismeretanyag egy kezdő rendszergazdának igen hasznos és főleg gyors segítséget jelenthet, különösen, ha a megrendelő vagy a főnök már (megint) türelmetlen. Ami a szükséges előismereteket illeti, e két kötetet elsősorban azoknak ajánljuk, akik már birtokában vannak a megfelelő linuxos alapismereteknek, és szeretnék megismerni a rendszergazdai feladatkör eszköztárát is. Lényeges hangsúlyozni, hogy a szerző kizárólag a sorozat első két tagjában (Pere László: Linux felhasználói ismeretek I. és II., Kiskapu Kiadó, 2002) tárgyalt témakörök és eszközök ismeretét tételezi fel az olvasóról. Minden mást új anyagként, részletesen tárgyal.'),
(9, 'Pere László', 'GNU/Linux rendszerek üzemeltetése I.', '2399964962768', 4180, 3, 'linux-pere-1.jpg', 'Ez a kötet Pere László linuxos sorozatának legújabb tagja. Azoknak a rendszergazdáknak és a számítástechnikával hobbiból foglalkozó olvasóknak kíván segítséget nyújtani, akik munkahelyükön vagy otthon kisebb-nagyobb GNU/Linux rendszereket üzemeltetnek. Tárgyalja a GNU/Linux felépítését, működését, bemutatja az üzemeltetés során felmerülő feladatokat, segít ezek ellátásában. A háttértárak kezelése, lemezrészek kialakítása, az állományrendszerek használata, a felhasználók kezelése, a bejelentkezés, a programcsomagok fordítása és telepítése, a grafikus felhasználói felület üzembe helyezése mind olyan feladatok, amelyek ellátása során a könyvben tárgyalt ismeretanyag igen sokat segíthet. A számítógéphálózatok építése és üzemeltetése, a hálózati alkalmazások telepítése és beállítása szintén komoly hangsúlyt kapnak a könyvben, így az a hálózatkezelés területén is komoly segítséget nyújthat. Különösen ajánljuk ezt a kötetet azoknak a GNU/Linux felhasználóknak, akik immár birtokában vannak a felhasználói alapismereteknek és szeretnének megismerkedni a rendszergazdai feladatkör eszköztárával is, hogy rendszerüket önállóan üzemeltethessék. Lényeges hangsúlyozni, hogy a szerző kizárólag a sorozat első tagjában (Pere László: Linux felhasználói ismeretek I., Kiskapu Kiadó, 2002) tárgyalt témakörök és eszközök ismeretét tételezi fel az olvasóról.'),
(10, 'Bódy Bence', 'Az SQL példákon keresztül - (Második kiadás)', '9786155012327', 2352, 4, 'SQL.jpg', 'Az SQL a relációs adatbázis-kezelők széles körben elterjedt lekérdezési nyelve. Viszonylag kevés utasítást tartalmaz, ám ezek igen bonyolult szerkezetet alkothatnak. Az SQL használatának megismeréséhez, elsajátításához ezért nagy segítséget nyújt egy szisztematikusan felépített példasorozat áttekintése.\r\n\r\nA könyv 33 feladatcsoportba rendezve közel 90 kidolgozott, fokozatosan nehezedő, valósághű feladaton keresztül vezeti be az Olvasót az SQL alkalmazásába. Az SQL megértését segíti, hogy minden feladatra több megoldás is található a példatárban. Az Olvasó tovább bővítheti az ismereteit a fejezetek végén lévő több, mint 100 gyakorló feladat egyéni kidolgozásával.\r\n\r\nA Szerző több évtizedes gyakorlati és oktatói tapasztalatát használta fel a példatár összeállításában és a példák kidolgozásában. A második kiadás a könyv első kiadásának az Olvasók visszajelzései alapján bővített, módosított változata.'),
(11, 'Fehér Krisztián', 'AJAX adatbázis-kezelés Javascript alapon', '9786155477584', 1415, 2, 'AJAX_2.jpg', 'Könyvünk a JavaScript alapokon programozható adatbáziskezelés alapjait mutatja be, az AJAX technológián keresztül, könnyen érthető formában. Nem csupán a szükséges JavaScript nyelven megírható programozási fogásokat tárgyaljuk, hanem rövid gyakorlati betekintést is adunk a PHP nyelvbe és az SQL lekérdezésekbe is. A könyv fejezetei könnyen értelmezhetők és az ismeretanyag gyorsan munkába állítható. Akár egy hétvége alatt is megtanulhatjuk, hogyan készíthetünk a nulláról indulva, saját, működő webes adatbáziskezelő alkalmazást.\r\nMivel az AJAX segítségével adatbázisok tartalmához is hozzáférhetünk JavaScript kódból, könnyen dinamikussá tehetjük weboldalainkat, webes alkalmazásainkat. Segítségével szkripteket futtathatunk szerveroldalon, majd a választ automatikusan visszaolvashatjuk JavaScript alapú weboldalon. Az AJAX igen elterjedt adatkezelési technika, számos nagyvállalat is alkalmazza bonyolult adatszerkezeteket tartalmazó adatbázisok kezelésére.'),
(12, 'Reiter István', 'C# programozás lépésről lépésre', '9786155012174', 2325, 4, 'csharp_jos.jpg', 'A .NET platform ún. felügyelt (vagy managed) kódot használ, vagyis a program teljes mértékben natív módon, közvetlenül a processzoron fut, mellette pedig ott a keretrendszer, amely felelős pl. a memóriafoglalásért vagy a kivételek kezeléséért. Gyakorlatilag bármelyik programozási nyelvnek lehet .NET implementációja, jelenleg kb. 50 nyelvnek létezik hivatalosan .NET megfelelője. A C# (ejtsd: szí-sárp) a .NET egyik fő programozási nyelve, 1999 ben Anders Hejlsberg vezetésével kezdték meg a fejlesztését. A C# tisztán objektumorientált, típusbiztos, általános felhasználású nyelv. A tervezésénél a lehető legnagyobb produktivitás elérését tartották szem előtt. A nyelv elméletileg platform független, így létezik Linux és Mac fordító is. A .NET programozáshoz a legjobb választás a Microsoft saját terméke, a Visual Studio. A nagy fizetős változatok (Professional, Ultimate) mellett létezik az ingyenes Express család is, amelynek tagjai szinte teljes körű szolgáltatást nyújtanak. Ebben a könyvben a C# programozási nyelv használatát tekintjük át lépésről lépére. Bár a mintapéldák elkészítése során a szerző a Visual C# Express 2010-et használta, más verziók megléte esetén is sikeresen forgatható, mivel a Visual Studio kifejezetten konzisztens felépítésű maradt az elmúlt években, aki az egyik változatot tudja használni, az a többivel is elboldogul'),
(13, 'Sikos László', 'Stíluslapok a weben - CSS kézikönyv', '9786156364180', 990, 2, 'css.jpg', 'A könyv, amely mely CSS kézikönyvként is használható, a webes stíluslapok használatának lehetőségeit ismerteti. Jelen könyv elsősorban a legújabb, teljesen kiforrott verziót, a CSS 2.1-et veszi alapul, minden helyen kitérve a régebbi verziókhoz képest jellemző esetleges eltérésekre, sajátságokra. A stíluslapok szövevényes, nyakatekert, megtévesztő megfogalmazásai, az angol rövidítések közötti eligazodást a könyv egyes fejezetei, a függelék és a kisszótár könnyíti meg. Ajánlható amatőröknek, profi weblapfejlesztőknek, akiknek szükségük van a stíluslapok behatóbb megismerésére és szeretnék korunk legkorszerűbb webes stíluslapjait használni.'),
(14, 'Alex Ionescu - Mark Russi', 'Windows Internals 2. rész, hatodik kiadás', '9789639863323', 15204, 1, 'Windows_internals.jpg', 'Teljes iránymutatás kiegészítve a Windows 7 és a Windows Server 2008 R2 minden részletével! A rendszergazdák bibliája!\r\nA könyv feltárja a Windows operációs rendszer kulcsfontosságú összetevőit, architektúráját, megmutatja, hogy mi történik a színfalak mögött. A szerzők nemzetközileg elismert szakértők. A klasszikus kézikönyv kiegészült a Windows 7 és a Windows Server 2008 R2 hozta újdonságokkal. A felgyűlt témakörök részletei immár két kötetet töltenek ki.\r\nAz új kiadás, a korábbiakban megszokott módon, bennfentes rálátást nyújt az operációs rendszer működésének kritikus részleteire. Nincs más szakkönyv, amely hasonló részletességgel ismertetné a Windowst. Gyakorlatai segítségével a szakember első kézből szerezhet tapasztalatokat a tervezés, a hibakeresés, a teljesítmény és a technikai támogatás rejtelmeiről.\r\nFejlesztőknek és üzemeltetőknek egyaránt ajánljuk. A Windows belső működésének megismerése révén az üzemeltetők megérthetik, és könnyedén elháríthatják az operációs rendszer üzemeltetése során felmerülő hibákat, feltárhatják a problémák gyökereit, és orvosolhatják azokat; a fejlesztők pedig hatékonyabb, gyorsabb kódot tudnak írni, egyszerűbben megtalálhatják a programhibákat, és a hibakeresés során jobban megérthetik a működési anomáliák okait.\r\nA könyv segítségével megismerhetők és megérthetők a Windows-architektúra és a belső működés részletei.\r\n\r\nA 2. kötet tartalmazza:\r\n8. fejezet I/O rendszer\r\n9. fejezet Tárolókezelés\r\n10. fejezet Memóriakezelés\r\n11. fejezet Gyorsítótár-kezelő\r\n12. fejezet Fájlrendszerek\r\n13. fejezet Indítás és leállítás\r\n14. fejezet Az összeomlási memóriakép elemzése'),
(15, 'Marziah Karch', 'Az Android munkában - Teljesítmény profiknak', '9789639863187', 10330, 1, 'android.jpg', 'Az Android új, az Android nyílt forráskódú, az Android nagyszerű. Az Android az üzleti élet egyre komolyabb szereplője. A könyv bemutatja, hogy az Android hogyan fogható munkára és hogyan használhatjuk fel hatékonyan az üzletmenetben. A könyv az üzleti felhasználó számára megfelelő Android telefon kiválasztásának feladatát is új megvilágításba helyezi. Ha most szereztük be első androidos okosfeletonunkat, vagy most próbáljuk telefonunkat hatékony eszközként használni, e könyv remek kiindulópont lesz. Megtanulhatjuk az e-mailek és a feladatok kezelését, azt, hogyan szabadulhatunk meg a tengernyi játéktól, és hogyan kereshetünk a különvöző szakterületek számára specializált hatékony eszközöket. Azok számára, akiket jobban érdekel az Android vállalati bevezetése, a könyv függeléke az Android telefonok felügyelezével, az egyedi felületek létrehozásával és a vállalatokra szabott alkalmazások készítésével foglalkozik. A könyv főbb témái: A megfelelő androidos telefon kiválasztása; A levelezőrendszer és a naptár integrálás; Térképes navigáció az üzleti utakon; Szakmai alkalmazások keresése; Együttműködés a munkatársakkal kisebb vagy nagyobb csoportokban; Az Android testre szabása. Ez a könyv mindazok számára hasznos lehet, akik androidos telefon vásárlását tervezik, vagy a közelmúltban beszereztek egyet. A webtervezők, az írók, az egészségügyi dolgozók, az ügyvédek és az oktatók jó hasznát vehetik egy androidos telefonnak, s az végre ürügy lehet mobilinternet-előfizetés vásárlására is.'),
(105, 'Peter Norvig - Stuart J. ', 'Mesterséges intelligencia I. kötet - Modern megközelítésben', '9786155186769', 16140, 5, 'MI_1.jpg', 'A mesterséges intelligencia korunk egyik - ha nem a legnagyobb - technológiai vívmánya. Számtalan aspektusból tárgyalható: a mögötte lévő matematikától és programozástól az üzleti célokon át az etikai és biztonsági kérdésekig.\r\nEz a könyv megkísérli a mesterséges intelligenciát teljes szélességében feltárni: átölelve a logikát, a valószínűségszámítást, a folytonos matematikát, az érzékelést, a következtetést, a tanulást, a cselekvést, a méltányosságot, valamint a bizalom, a társadalmi közjó és a biztonság kapcsolódó kérdéseit, továbbá a mikroelektronikától, a világűrt kutató robotokon keresztül a felhasználók milliárdjait kiszolgáló online szolgáltatásokig terjedő alkalmazásokat. A mára ismert dolgokat egy közös rendszerré szintetizálja, átdolgozva a korai eredményeket a ma elterjedt ötletek és terminológia felhasználásával. Elsődleges célja átadni azokat az ötleteket, amelyek az MI-kutatás elmúlt hetven éve és a kapcsolódó kutatások elmúlt két évezrede során merültek fel.\r\n\r\nA könyv magyar kiadása - terjedelmi okok miatt - két kötetben jelenik meg. Az I. kötet az MI alapjait tárgyaló fejezeteket, a II. kötet pedig a mélyebbre tekintő, gépi tanulást ismertető fejezeteket tartalmazza. Mindkét kötetben megtalálható a teljes tartalomjegyzék, a függelékek, az irodalomjegyzék és a tárgymutató.');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `kiado`
--
ALTER TABLE `kiado`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `konyv`
--
ALTER TABLE `konyv`
  ADD PRIMARY KEY (`konyv_id`),
  ADD KEY `FK_konyv_kiado_id` (`kiado_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `kiado`
--
ALTER TABLE `kiado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `konyv`
--
ALTER TABLE `konyv`
  MODIFY `konyv_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=106;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `konyv`
--
ALTER TABLE `konyv`
  ADD CONSTRAINT `FK_konyv_kiado_id` FOREIGN KEY (`kiado_id`) REFERENCES `kiado` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
