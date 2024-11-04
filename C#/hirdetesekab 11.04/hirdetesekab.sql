-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Okt 21. 19:50
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `hirdetesekab`
--
CREATE DATABASE IF NOT EXISTS `hirdetesekab` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `hirdetesekab`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hirdetesek`
--

CREATE TABLE `hirdetesek` (
  `hirdetesekid` int(2) NOT NULL,
  `szobaszam` int(1) DEFAULT NULL,
  `szelesseg` double(16,13) DEFAULT NULL,
  `hosszusag` double(16,13) DEFAULT NULL,
  `emelet` int(1) DEFAULT NULL,
  `alapterulet` int(3) DEFAULT NULL,
  `hirdetesszoveg` varchar(27) DEFAULT NULL,
  `tehermentes` varchar(5) DEFAULT 'True',
  `kepnev` varchar(65) DEFAULT NULL,
  `hirdetesdatum` date DEFAULT NULL,
  `hirdetoid` int(3) DEFAULT NULL,
  `kategoriaid` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `hirdetesek`
--

INSERT INTO `hirdetesek` (`hirdetesekid`, `szobaszam`, `szelesseg`, `hosszusag`, `emelet`, `alapterulet`, `hirdetesszoveg`, `tehermentes`, `kepnev`, `hirdetesdatum`, `hirdetoid`, `kategoriaid`) VALUES
(1, 5, 47.5410485803319, 19.1516419487702, 1, 165, 'ház eladó', 'False', 'house10.png', '2021-11-17', 56, 1),
(2, 5, 47.4010485803319, 19.1536419487702, 3, 145, 'ház eladó', 'True', 'house39.png', '2021-10-13', 16, 1),
(3, 5, 47.5760485803319, 19.1616419487702, 4, 150, 'ház eladó', 'True', 'house50.png', '2022-01-19', 61, 1),
(4, 5, 47.5600485803319, 19.0686419487702, 1, 135, 'garázs eladó', 'True', 'house50.png', '2021-10-31', 238, 4),
(5, 5, 47.4350485803319, 19.1076419487702, 1, 135, 'garázs eladó', 'True', 'house02.png', '2021-12-29', 40, 4),
(6, 5, 47.4210485803319, 18.9906419487702, 1, 150, 'ház eladó', 'False', 'house50.png', '2021-10-05', 213, 1),
(7, 5, 47.5390485803319, 19.0136419487702, 0, 230, 'építési telek eladó', 'True', 'house09.png', '2022-02-20', 281, 3),
(8, 5, 47.5340485803319, 19.0216419487702, 0, 185, 'garázs eladó', 'True', 'house50.png', '2021-12-07', 124, 4),
(9, 5, 47.5430485803319, 19.1646419487702, 2, 165, 'lakás eladó', 'True', 'house18.png', '2022-02-09', 168, 2),
(10, 5, 47.4100485803319, 18.9876419487702, 1, 205, 'garázs eladó', 'True', 'house18.png', '2021-10-13', 346, 4),
(11, 2, 47.4200485803319, 19.0646419487702, 2, 65, 'ház eladó', 'True', 'house27.png', '2022-02-01', 123, 1),
(12, 5, 47.5010485803319, 19.0936419487702, 0, 195, 'garázs eladó', 'True', 'house18.png', '2021-10-19', 222, 4),
(13, 5, 47.4770485803319, 18.9996419487702, 2, 180, 'garázs eladó', 'True', 'house12.png', '2021-10-11', 374, 4),
(14, 5, 47.4860485803319, 19.0306419487702, 4, 135, 'mezőgazdasági terület eladó', 'True', 'house392.png', '2022-01-29', 271, 5),
(15, 2, 47.5220485803319, 19.1416419487702, 4, 60, 'építési telek eladó', 'True', 'house18.png', '2021-10-28', 373, 3),
(16, 4, 47.5410485803319, 19.0886419487702, 4, 145, 'ház eladó', 'True', 'house14.png', '2021-10-05', 312, 1),
(17, 5, 47.3950485803319, 19.1196419487702, 3, 180, 'ház eladó', 'True', 'house18.png', '2021-11-19', 10, 1),
(18, 3, 47.3980485803319, 19.0206419487702, 2, 90, 'ház eladó', 'True', 'house01.png', '2022-02-03', 24, 1),
(19, 5, 47.5710485803319, 19.1526419487702, 4, 140, 'ház eladó', 'True', 'house48.png', '2022-02-02', 46, 1),
(20, 1, 47.5360485803319, 19.1466419487702, 2, 40, 'ház eladó', 'True', 'house18.png', '2022-01-25', 85, 1),
(21, 4, 47.5670485803319, 19.1376419487702, 3, 80, 'garázs eladó', 'True', 'house24.png', '2021-12-12', 308, 4),
(22, 5, 47.5050485803319, 19.1416419487702, 1, 150, 'ház eladó', 'True', 'haz.png', '2021-10-18', 48, 1),
(23, 2, 47.4110485803319, 19.0116419487702, 2, 55, 'ház eladó', 'True', 'house25.png', '2021-12-05', 6, 1),
(24, 5, 47.5380485803319, 19.1786419487702, 1, 165, 'ház eladó', 'True', 'house01.png', '2021-12-13', 82, 1),
(25, 5, 47.4720485803319, 19.1716419487702, 1, 240, 'ház eladó', 'True', 'house30.png', '2021-11-17', 157, 1),
(26, 4, 47.4880485803319, 18.9906419487702, 1, 120, 'garázs eladó', 'True', 'house15.png', '2021-12-12', 144, 4),
(27, 2, 47.5200485803319, 19.1616419487702, 3, 45, 'ház eladó', 'True', 'haz.png', '2021-12-06', 275, 1),
(28, 5, 47.5440485803319, 19.0456419487702, 3, 110, 'ház eladó', 'True', 'house20.png', '2021-09-29', 282, 1),
(29, 5, 47.4310485803319, 19.0226419487702, 4, 120, 'ipari ingatlan eladó', 'True', 'house46.png', '2021-11-24', 254, 6),
(30, 3, 47.4340485803319, 19.1796419487702, 0, 100, 'ház eladó', 'True', 'haz.png', '2022-01-10', 321, 1),
(31, 3, 47.4890485803319, 19.0326419487702, 1, 85, 'lakás eladó', 'True', 'haz.png', '2021-11-11', 345, 2),
(32, 3, 47.5170485803319, 19.1596419487702, 3, 85, 'garázs eladó', 'True', 'house08.png', '2021-11-27', 317, 4),
(33, 5, 47.4700485803319, 19.0176419487702, 0, 210, 'ház eladó', 'True', 'house08.png', '2022-01-13', 111, 1),
(34, 4, 47.4410485803319, 19.1626419487702, 1, 90, 'ház eladó', 'True', 'haz.png', '2021-12-23', 266, 1),
(35, 5, 47.5390485803319, 18.9916419487702, 1, 150, 'garázs eladó', 'True', 'house39.png', '2022-02-25', 103, 4),
(36, 5, 47.5810485803319, 19.1796419487702, 4, 175, 'lakás eladó', 'True', 'house15.png', '2021-10-14', 156, 2),
(37, 5, 47.5750485803319, 19.1116419487702, 0, 180, 'garázs eladó', 'True', 'house31.png', '2021-11-01', 178, 4),
(38, 5, 47.5110485803319, 19.1536419487702, 1, 155, 'ház eladó', 'True', 'house28.png', '2022-02-04', 175, 1),
(39, 4, 47.3910485803319, 18.9876419487702, 0, 125, 'ház eladó', 'True', 'house44.png', '2021-10-27', 244, 1),
(40, 3, 47.4660485803319, 19.1336419487702, 0, 80, 'ház eladó', 'True', 'house13.png', '2021-10-13', 22, 1),
(41, 1, 47.4650485803319, 19.0146419487702, 1, 45, 'ház eladó', 'True', 'haz.png', '2022-01-12', 226, 1),
(42, 3, 47.5600485803319, 19.1096419487702, 2, 95, 'ház eladó', 'True', 'haz.png', '2021-11-12', 299, 1),
(43, 5, 47.5330485803319, 19.0036419487702, 0, 225, 'garázs eladó', 'True', 'house09.png', '2021-11-14', 313, 4),
(44, 5, 47.4640485803319, 19.1346419487702, 3, 165, 'garázs eladó', 'True', 'haz.png', '2021-11-16', 320, 4),
(45, 5, 47.5440485803319, 19.0476419487702, 1, 145, 'építési telek eladó', 'True', 'house27.png', '2022-01-17', 9, 3),
(46, 5, 47.5800485803319, 19.1496419487702, 1, 185, 'ház eladó', 'True', 'house25.png', '2022-02-10', 96, 1),
(47, 5, 47.3970485803319, 19.1376419487702, 4, 165, 'ház eladó', 'False', 'haz.png', '2022-01-31', 178, 1),
(48, 3, 47.5240485803319, 19.1266419487702, 1, 75, 'ház eladó', 'True', 'haz.png', '2021-12-24', 43, 1),
(49, 5, 47.5440485803319, 19.1476419487702, 4, 220, 'garázs eladó', 'True', 'house11.png', '2022-01-04', 14, 4),
(50, 5, 47.4740485803319, 19.0256419487702, 2, 140, 'garázs eladó', 'True', 'house21.png', '2022-01-10', 54, 4),
(51, 1, 47.4600485803319, 19.0896419487702, 2, 45, 'ház eladó', 'True', 'haz.png', '2022-02-14', 370, 1),
(52, 5, 47.5540485803319, 19.1146419487702, 1, 225, 'ház eladó', 'True', 'house18.png', '2021-11-26', 373, 1),
(53, 5, 47.4830485803319, 19.1246419487702, 4, 175, 'garázs eladó', 'True', 'haz.png', '2021-10-01', 236, 4),
(54, 2, 47.5020485803319, 19.1836419487702, 1, 65, 'ház eladó', 'True', 'house43.png', '2022-02-17', 250, 1),
(55, 2, 47.4290485803319, 19.1746419487702, 0, 75, 'ház eladó', 'True', 'haz.png', '2021-12-26', 300, 1),
(56, 2, 47.5390485803319, 19.1086419487702, 2, 75, 'ház eladó', 'True', 'house12.png', '2022-01-26', 249, 1),
(57, 3, 47.4570485803319, 19.0696419487702, 1, 65, 'ház eladó', 'False', 'house49.png', '2021-10-14', 372, 1),
(58, 1, 47.4840485803319, 18.9946419487702, 0, 45, 'ház eladó', 'True', 'haz.png', '2021-11-03', 3, 1),
(59, 5, 47.4850485803319, 19.0206419487702, 1, 185, 'ház eladó', 'True', 'haz.png', '2021-10-09', 222, 1),
(60, 5, 47.3930485803319, 19.0836419487702, 3, 140, 'ház eladó', 'True', 'house20.png', '2021-11-12', 60, 1),
(61, 3, 47.4010485803319, 19.0996419487702, 0, 100, 'ház eladó', 'True', 'haz.png', '2021-12-12', 203, 1),
(62, 4, 47.5370485803319, 19.1796419487702, 2, 110, 'lakás eladó', 'True', 'house07.png', '2021-12-16', 221, 2),
(63, 5, 47.5760485803319, 19.0276419487702, 0, 160, 'ház eladó', 'True', 'haz.png', '2021-12-14', 50, 1),
(64, 5, 47.4350485803319, 19.1736419487702, 2, 110, 'garázs eladó', 'True', 'house01.png', '2022-02-11', 231, 4),
(65, 5, 47.4260485803319, 19.0846419487702, 2, 180, 'építési telek eladó', 'True', 'house41.png', '2021-12-23', 183, 3),
(66, 5, 47.5270485803319, 19.1286419487702, 3, 145, 'ház eladó', 'True', 'house31.png', '2021-11-25', 143, 1),
(67, 5, 47.4820485803319, 19.1526419487702, 0, 145, 'ház eladó', 'True', 'house41.png', '2022-02-25', 92, 1),
(68, 5, 47.5430485803319, 19.1536419487702, 2, 190, 'lakás eladó', 'False', 'house29.png', '2021-10-07', 173, 2),
(69, 5, 47.5760485803319, 19.0926419487702, 4, 160, 'ház eladó', 'True', 'haz.png', '2021-11-20', 102, 1),
(70, 4, 47.4860485803319, 19.1556419487702, 3, 105, 'ház eladó', 'True', 'house23.png', '2021-10-30', 204, 1),
(71, 2, 47.4050485803319, 19.0356419487702, 1, 60, 'lakás eladó', 'True', 'house31.png', '2022-01-05', 23, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hirdetok`
--

CREATE TABLE `hirdetok` (
  `hirdetokid` int(3) NOT NULL,
  `hirdetonev` varchar(24) DEFAULT NULL,
  `hirdetotelefon` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `hirdetok`
--

INSERT INTO `hirdetok` (`hirdetokid`, `hirdetonev`, `hirdetotelefon`) VALUES
(3, 'Veg Eta', '+36 1 8434-6191'),
(6, 'Szikla Szilárd', '+36 1 8618-6027'),
(9, 'Rontó Pál', '+36 1 5941-3954'),
(10, 'Rekurz Iván', '+36 1 3973-7021'),
(14, 'Nagy Adrienn', '+36 1 9912-8987'),
(16, 'Marok Nyikolaj', '+36 1 8139-4405'),
(22, 'Garabuczi Laura', '+36 1 1672-9525'),
(23, 'Fogd Bea', '+36 1 4725-2442'),
(24, 'Fer Enci', '+36 1 6920-6507'),
(40, 'Róka Gábor', '+36 1 2729-9902'),
(43, 'Radnóthy Péter Attila', '+36 1 3679-6064'),
(46, 'Némethy Zsófia', '+36 1 3494-2935'),
(48, 'Nagy Ádám', '+36 1 4504-5595'),
(50, 'Maár Tamás', '+36 1 7606-9208'),
(54, 'Hegedûs Adrienn', '+36 1 6078-6520'),
(56, 'Fazekas Zoltán', '+36 1 9929-8217'),
(60, 'Dalos Ákos Mihály', '+36 1 9950-1575'),
(61, 'Bur Kolos', '+36 1 3652-1187'),
(82, 'Leskó András', '+36 1 5240-3808'),
(85, 'Kecskés Dániel Tamás', '+36 1 1388-4882'),
(92, 'Gáti Orsolya', '+36 1 3378-6077'),
(96, 'Bekre Pál', '+36 1 5895-6043'),
(102, 'Szûcs Nikolett', '+36 1 5433-2908'),
(103, 'Szolnoki Anna', '+36 1 4163-7869'),
(111, 'Kovács Adrienn', '+36 1 7174-6885'),
(123, 'Ápry Lisa', '+36 1 8413-6094'),
(124, 'Amor Ella', '+36 1 6978-7676'),
(143, 'Lizák Gerhard', '+36 1 3227-3795'),
(144, 'Lev Elek', '+36 1 2451-9808'),
(156, 'Béres Tamás', '+36 1 1818-4840'),
(157, 'Bán Tamás', '+36 1 9446-6211'),
(168, 'Resz Elek', '+36 1 1399-2527'),
(173, 'Pár Zoltán', '+36 1 3798-6794'),
(175, 'Nyomo Réka', '+36 1 7718-7901'),
(178, 'Mursa Krisztián', '+36 1 4450-7684'),
(183, 'Korpusz Ilma', '+36 1 6751-6005'),
(203, 'Papp Beáta', '+36 1 1382-1376'),
(204, 'Ösztön Ödön', '+36 1 3078-1467'),
(213, 'Godz Ila', '+36 1 1976-3679'),
(221, 'Vágó Péter Ákos', '+36 1 4643-1788'),
(222, 'Tóth Zsuzsa', '+36 1 3720-8653'),
(226, 'Szabó Sandra', '+36 1 1698-5971'),
(231, 'Pataki Bálint', '+36 1 9998-4893'),
(236, 'Mod Emma', '+36 1 1239-2839'),
(238, 'Kolle Gina', '+36 1 9907-6155'),
(244, 'Ér Emma', '+36 1 1414-4563'),
(249, 'Bíró Olívia', '+36 1 9189-6594'),
(250, 'Bernát Csilla', '+36 1 8180-8416'),
(254, 'Trab Antal', '+36 1 8970-1364'),
(266, 'Nemoda Tamás', '+36 1 6726-8470'),
(271, 'Huczman Gergely', '+36 1 2819-2249'),
(275, 'Furi Kázmér', '+36 1 9919-6448'),
(281, 'Dancs Dániel', '+36 1 2541-3669'),
(282, 'Bali Alexandra Mercédesz', '+36 1 1575-7660'),
(299, 'Lakatos Emese', '+36 1 7708-3203'),
(300, 'Kana Péter', '+36 1 4350-5709'),
(308, 'Egyenes Ági', '+36 1 1780-7112'),
(312, 'Bacskai Mihály', '+36 1 4996-5351'),
(313, 'Ádám Ákos Lajos', '+36 1 9163-7120'),
(317, 'Török Szilárd', '+36 1 3603-9947'),
(320, 'Potornai Judit Adrienn', '+36 1 2827-9828'),
(321, 'Pataki Vince', '+36 1 7294-6572'),
(345, 'Aloe Vera', '+36 1 5072-4171'),
(346, 'Vagd Alma', '+36 1 7446-5220'),
(370, 'Demeter Anna', '+36 1 2672-9935'),
(372, 'Budipa Piroska', '+36 1 4439-9700'),
(373, 'Bõrönd Ödön', '+36 1 2709-2407'),
(374, 'Bac Ilus', '+36 1 1301-2730');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kategoriak`
--

CREATE TABLE `kategoriak` (
  `kategoriakid` int(1) NOT NULL,
  `kategorianev` varchar(21) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `kategoriak`
--

INSERT INTO `kategoriak` (`kategoriakid`, `kategorianev`) VALUES
(1, 'ház'),
(2, 'lakás'),
(3, 'építési telek'),
(4, 'garázs'),
(5, 'mezőgazdasági terület'),
(6, 'ipari ingatlan');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `hirdetesek`
--
ALTER TABLE `hirdetesek`
  ADD PRIMARY KEY (`hirdetesekid`),
  ADD KEY `hirdetoid` (`hirdetoid`,`kategoriaid`),
  ADD KEY `kategoriaid` (`kategoriaid`);

--
-- A tábla indexei `hirdetok`
--
ALTER TABLE `hirdetok`
  ADD PRIMARY KEY (`hirdetokid`);

--
-- A tábla indexei `kategoriak`
--
ALTER TABLE `kategoriak`
  ADD PRIMARY KEY (`kategoriakid`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `hirdetesek`
--
ALTER TABLE `hirdetesek`
  ADD CONSTRAINT `hirdetesek_ibfk_1` FOREIGN KEY (`hirdetoid`) REFERENCES `hirdetok` (`hirdetokid`),
  ADD CONSTRAINT `hirdetesek_ibfk_2` FOREIGN KEY (`kategoriaid`) REFERENCES `kategoriak` (`kategoriakid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
