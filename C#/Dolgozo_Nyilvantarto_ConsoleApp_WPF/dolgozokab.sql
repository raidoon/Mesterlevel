-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Dec 12. 09:09
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `dolgozokab`
--
CREATE DATABASE IF NOT EXISTS `dolgozokab` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `dolgozokab`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `dolgozo`
--

CREATE TABLE `dolgozo` (
  `dolgozoid` int(11) NOT NULL,
  `nev` varchar(50) DEFAULT NULL,
  `neme` varchar(5) DEFAULT NULL,
  `dolgozoreszlegid` int(1) DEFAULT NULL,
  `belepes` int(4) DEFAULT NULL,
  `ber` int(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `dolgozo`
--

INSERT INTO `dolgozo` (`dolgozoid`, `nev`, `neme`, `dolgozoreszlegid`, `belepes`, `ber`) VALUES
(1, 'Alsófalvi Amália', 'nő', 1, 2017, 130090),
(2, 'Alsófalvi Amália', 'nő', 1, 1998, 343647),
(3, 'Asztal Sándor', 'férfi', 6, 1970, 231754),
(4, 'Átlagos Ákos', 'férfi', 8, 1983, 219531),
(5, 'Azér Lázár', 'férfi', 5, 1995, 290729),
(6, 'Bak Dániel', 'férfi', 6, 1983, 496106),
(7, 'Balogh Éva', 'nő', 3, 1983, 522899),
(8, 'Balogh Gábor', 'férfi', 1, 1988, 193119),
(9, 'Bán Mihály', 'férfi', 1, 1983, 191563),
(10, 'Barna Ágota', 'nő', 3, 1985, 252032),
(11, 'Béna Béla', 'férfi', 8, 1972, 186064),
(12, 'Beri Dániel', 'férfi', 2, 1979, 222943),
(13, 'Bodor Enikő', 'nő', 6, 2012, 274781),
(14, 'Bomberra Krisztina', 'nő', 6, 2018, 232925),
(15, 'Bödön Ödön', 'férfi', 8, 1993, 166483),
(16, 'Brazil Béla', 'férfi', 1, 2001, 299524),
(17, 'Budai Antal', 'férfi', 3, 2017, 144107),
(18, 'Céhes Eszter', 'nő', 6, 2012, 296289),
(19, 'Czeczei András', 'férfi', 6, 2005, 205444),
(20, 'Czeczei Zsolt', 'férfi', 2, 1981, 452042),
(21, 'Czeczei Zsolt', 'férfi', 6, 2005, 386026),
(22, 'Csavar Pista', 'férfi', 6, 1995, 234074),
(23, 'Dávid Ilona', 'nő', 3, 1970, 115651),
(24, 'Dávid Izaura', 'nő', 7, 1989, 300039),
(25, 'Devon Mihály', 'férfi', 1, 2007, 161533),
(26, 'Égerházi Zsanett', 'nő', 1, 1993, 295283),
(27, 'Él Ilona', 'nő', 2, 1982, 299865),
(28, 'Éliás Tóbiás', 'férfi', 6, 1998, 303102),
(29, 'Erdős Árpád', 'férfi', 8, 2009, 220353),
(30, 'Faragó Viktor', 'férfi', 8, 1970, 292099),
(31, 'Farkas Károly', 'férfi', 5, 1995, 209343),
(32, 'Fehér Jakab', 'férfi', 3, 1973, 241893),
(33, 'Fekete Andrea', 'nő', 3, 1989, 124880),
(34, 'Fekete Frigyes', 'férfi', 1, 1997, 130135),
(35, 'Fityeházi Ágoston', 'férfi', 7, 2017, 306860),
(36, 'Fogarasi Árpád', 'férfi', 4, 1996, 307855),
(37, 'Fritz Attila', 'férfi', 6, 1969, 267901),
(38, 'Fritz Géza', 'férfi', 2, 2009, 288983),
(39, 'Fül Elek', 'férfi', 3, 2017, 112590),
(40, 'Gábor Gizella', 'nő', 3, 2003, 181108),
(41, 'Gáspár Olga', 'nő', 4, 2010, 298381),
(42, 'Gaz Julianna', 'nő', 3, 2006, 131620),
(43, 'Gép Béla', 'férfi', 6, 1980, 277660),
(44, 'Gerecsény Eszter', 'nő', 8, 1975, 260777),
(45, 'Gold Mária', 'nő', 1, 1998, 286186),
(46, 'Gomb Sára', 'nő', 6, 1995, 313310),
(47, 'Gulág Tóbiás', 'férfi', 2, 2013, 109873),
(48, 'Győri Tímea', 'nő', 8, 2014, 140646),
(49, 'Habos Helén', 'nő', 8, 2004, 264754),
(50, 'Halász Júlia', 'nő', 8, 2003, 122520),
(51, 'Határ Hugó', 'férfi', 8, 1980, 256155),
(52, 'Hegedűs Ilona', 'nő', 8, 1981, 198774),
(53, 'Higli Jolán', 'nő', 5, 1987, 170292),
(54, 'Horváth Dezső', 'férfi', 6, 1991, 338631),
(55, 'Horváth Kinga', 'nő', 4, 1969, 184889),
(56, 'Hűtő Béla', 'férfi', 6, 1988, 426139),
(57, 'Ináncsi József', 'férfi', 4, 2001, 199721),
(58, 'Inger Rozália', 'nő', 6, 1989, 344391),
(59, 'Izmos Vilmos', 'férfi', 8, 2011, 298796),
(60, 'Kálvin Ödömér', 'férfi', 5, 1976, 321959),
(61, 'Kapros Lajos', 'férfi', 8, 2006, 200943),
(62, 'Kárai Kata', 'nő', 6, 1994, 122245),
(63, 'Karap Béla', 'férfi', 6, 1974, 191443),
(64, 'Károly Zoltán', 'férfi', 3, 1984, 139730),
(65, 'Kecskés Mária', 'nő', 8, 1978, 149959),
(66, 'Kicsi Misi', 'férfi', 8, 1978, 186715),
(67, 'Kiss Ágnes', 'nő', 5, 1969, 125803),
(68, 'Kiss Borbála', 'nő', 5, 1971, 159775),
(69, 'Kiss Csilla', 'nő', 2, 2009, 337231),
(70, 'Kiss Jenő', 'férfi', 4, 1973, 324666),
(71, 'Kiss Rozália', 'nő', 8, 1982, 248843),
(72, 'Kodály Zoltán', 'férfi', 3, 1975, 482961),
(73, 'Kolompár Frigyes', 'férfi', 5, 1978, 343403),
(74, 'Kolompár Gáspár', 'férfi', 1, 2003, 253794),
(75, 'Kondor Katalin', 'nő', 6, 2013, 287247),
(76, 'Kónya Anett', 'nő', 3, 1992, 186852),
(77, 'Kovács Beáta', 'nő', 7, 2013, 386887),
(78, 'Kovács Béla', 'férfi', 8, 2005, 269895),
(79, 'Kovács Helga', 'nő', 6, 1985, 325358),
(80, 'Kovács János', 'férfi', 1, 1986, 212865),
(81, 'Kovács János', 'férfi', 2, 1993, 346023),
(82, 'Kozlovszky Jenő', 'férfi', 1, 2018, 248206),
(83, 'Körte Vilmos', 'férfi', 8, 2016, 256051),
(84, 'Kötö Irma', 'nő', 5, 1990, 284049),
(85, 'Kun Béla', 'férfi', 4, 1969, 265384),
(86, 'Kuti Kamilla', 'nő', 4, 1977, 281336),
(87, 'Lakatos Lujza', 'nő', 1, 2005, 316271),
(88, 'Lakatos Pál', 'férfi', 2, 1986, 159538),
(89, 'Lakodalom Lajos', 'férfi', 8, 1970, 229541),
(90, 'Lapos Elemér', 'férfi', 5, 1972, 306860),
(91, 'Léc Elek', 'férfi', 1, 2001, 220506),
(92, 'Lepési Mária', 'nő', 5, 2006, 227066),
(93, 'Magyar Erzsébet', 'nő', 7, 1973, 287814),
(94, 'Makrai Dezső', 'férfi', 8, 2016, 218725),
(95, 'Mária Terézia', 'nő', 6, 1987, 376465),
(96, 'Mayer Tamás', 'férfi', 6, 1998, 169054),
(97, 'Medgyessi Pál', 'férfi', 1, 1999, 282749),
(98, 'Méh Erika', 'nő', 6, 2011, 246126),
(99, 'Mekk Elek Tihamér', 'férfi', 8, 1988, 268099),
(100, 'Morvay Jenő', 'férfi', 6, 1972, 297254),
(101, 'Morvay Levente', 'férfi', 7, 2011, 476449),
(102, 'Nagy Antal', 'férfi', 4, 1986, 309611),
(103, 'Nagy Gyula', 'férfi', 5, 1981, 211530),
(104, 'Nagy Kálmán', 'férfi', 5, 1979, 279136),
(105, 'Nagy Zoltán', 'nő', 7, 1979, 167928),
(106, 'Nájt Mihály', 'férfi', 1, 2004, 344839),
(107, 'Nehéz Teréz', 'nő', 8, 1973, 228999),
(108, 'Nem János', 'férfi', 6, 1990, 143081),
(109, 'Nem Tamás', 'férfi', 4, 2016, 220554),
(110, 'Németh Noémi', 'nő', 4, 1983, 282454),
(111, 'Németh Sára', 'nő', 4, 1985, 253524),
(112, 'Oláh Gáspár', 'férfi', 4, 1988, 137158),
(113, 'Ormosi Teréz', 'nő', 1, 1971, 104671),
(114, 'Öregh Amália', 'nő', 7, 2016, 315782),
(115, 'Pán Péter', 'férfi', 2, 2017, 189096),
(116, 'Pastinszky Tamás', 'férfi', 7, 2006, 325980),
(117, 'Pataki Aladár', 'férfi', 8, 2003, 241873),
(118, 'Pintér Sándor', 'férfi', 6, 1977, 212158),
(119, 'Pokol Petúnia', 'nő', 2, 1973, 256368),
(120, 'Polgár Jenő', 'férfi', 4, 1987, 264165),
(121, 'Présinger Tamás', 'férfi', 2, 2001, 297147),
(122, 'Presser Gábor', 'férfi', 3, 2016, 173758),
(123, 'Prézli János', 'férfi', 6, 2016, 169183),
(124, 'Prezma Aurora', 'nő', 6, 1991, 137207),
(125, 'Puli Sándor', 'férfi', 5, 1984, 122782),
(126, 'Rizi Gizi', 'nő', 8, 2016, 343616),
(127, 'Sarkadi Csaba', 'férfi', 6, 1976, 230294),
(128, 'Sarkadi Csaba', 'férfi', 7, 1992, 275338),
(129, 'Seres András', 'férfi', 3, 1985, 214497),
(130, 'Sipos Gábor', 'férfi', 4, 1982, 185714),
(131, 'Sipos Károly', 'férfi', 4, 2002, 278778),
(132, 'Somogyi Erika', 'nő', 4, 2016, 193363),
(133, 'Sörös Leopold', 'férfi', 5, 1972, 329999),
(134, 'Sörös Sándor', 'férfi', 5, 2012, 202216),
(135, 'Sunyi Béla', 'férfi', 4, 2010, 294523),
(136, 'Szabó András', 'férfi', 2, 2009, 269287),
(137, 'Szabó Attila', 'férfi', 4, 2006, 211794),
(138, 'Szabó Balázs', 'férfi', 7, 1983, 351304),
(139, 'Szabó Dénes', 'férfi', 3, 2004, 269537),
(140, 'Szabó Éva', 'nő', 4, 2005, 182674),
(141, 'Szabó Péter', 'férfi', 6, 2010, 226231),
(142, 'Szalacsi Sándor', 'férfi', 4, 1977, 184545),
(143, 'Szép Kálmán', 'férfi', 8, 1986, 170663),
(144, 'Szigeti Sándor', 'férfi', 4, 1971, 315764),
(145, 'Szokai Barbara', 'nő', 6, 2013, 184629),
(146, 'Szokai Kinga', 'nő', 2, 1979, 295981),
(147, 'Szokai Kinga', 'nő', 3, 2000, 101498),
(148, 'Szűcs Gábor', 'férfi', 7, 1975, 265928),
(149, 'Takács Lilla', 'nő', 6, 2002, 325866),
(150, 'Takács Nándor', 'férfi', 2, 2007, 343382),
(151, 'Tavi József', 'férfi', 8, 1979, 372182),
(152, 'Tiszai József', 'férfi', 8, 2001, 305412),
(153, 'Torgyán Andrea', 'nő', 6, 2015, 461167),
(154, 'Torgyán Attila', 'férfi', 8, 1987, 342561),
(155, 'Tóth Gyula', 'férfi', 7, 1981, 261433),
(156, 'Tóth Imre', 'férfi', 1, 1988, 285381),
(157, 'Turpis Imre', 'férfi', 8, 1999, 455582),
(158, 'Vaal Máté', 'férfi', 6, 1969, 220726),
(159, 'Vagyok Ibolya', 'nő', 4, 2000, 212096),
(160, 'Varga Dóra', 'nő', 4, 2009, 144949),
(161, 'Varga Tamás', 'férfi', 4, 1988, 213615),
(162, 'Végh József', 'férfi', 4, 1999, 187443),
(163, 'Vígh József', 'férfi', 6, 1986, 202335),
(164, 'Világi Virág', 'nő', 2, 1999, 347147),
(165, 'Víz Gizella', 'nő', 6, 2012, 104223),
(166, 'Volga Olga', 'nő', 8, 2009, 197090),
(167, 'Vonal Deodát', 'férfi', 2, 1997, 187753),
(168, 'Wesselényi Brúnó', 'férfi', 2, 1975, 130108),
(169, 'William Clinton', 'férfi', 4, 2004, 285206),
(170, 'Zsák Judit', 'nő', 6, 2006, 222083);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `reszleg`
--

CREATE TABLE `reszleg` (
  `reszlegid` int(1) NOT NULL,
  `reszleg` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `reszleg`
--

INSERT INTO `reszleg` (`reszlegid`, `reszleg`) VALUES
(1, 'asztalosműhely'),
(2, 'beszerzés'),
(3, 'értékesítés'),
(4, 'karbantartás'),
(5, 'lakatosműhely'),
(6, 'pénzügy'),
(7, 'személyzeti'),
(8, 'szerelőműhely'),
(9, 'kovácsműhely'),
(10, 'barkácsműhely'),
(11, 'villamosságszerelés');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `dolgozo`
--
ALTER TABLE `dolgozo`
  ADD PRIMARY KEY (`dolgozoid`),
  ADD KEY `dolgozoreszlegid` (`dolgozoreszlegid`);

--
-- A tábla indexei `reszleg`
--
ALTER TABLE `reszleg`
  ADD PRIMARY KEY (`reszlegid`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `dolgozo`
--
ALTER TABLE `dolgozo`
  MODIFY `dolgozoid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=177;

--
-- AUTO_INCREMENT a táblához `reszleg`
--
ALTER TABLE `reszleg`
  MODIFY `reszlegid` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `dolgozo`
--
ALTER TABLE `dolgozo`
  ADD CONSTRAINT `dolgozo_ibfk_1` FOREIGN KEY (`dolgozoreszlegid`) REFERENCES `reszleg` (`reszlegid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
