-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Dec 03. 10:18
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
-- Adatbázis: `katicabufeab`
--
CREATE DATABASE IF NOT EXISTS `katicabufeab` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `katicabufeab`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `forgalom`
--

CREATE TABLE `forgalom` (
  `forgalomid` int(11) NOT NULL,
  `termek` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `vevo` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `forgalomkategoriaid` int(11) DEFAULT NULL,
  `egyseg` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `nettoar` int(11) DEFAULT NULL,
  `mennyiseg` int(11) DEFAULT NULL,
  `kiadva` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `forgalom`
--

INSERT INTO `forgalom` (`forgalomid`, `termek`, `vevo`, `forgalomkategoriaid`, `egyseg`, `nettoar`, `mennyiseg`, `kiadva`) VALUES
(246, 'Sajtos hot-dog', 'Lajos', 1, 'db', 450, 2, 1),
(247, 'Limonádé', 'Lajos', 2, 'dl', 100, 5, 1),
(248, 'Gyrostál', 'Kinga', 1, 'db', 1500, 1, 1),
(249, 'Ízes palacsinta', 'Kinga', 1, 'db', 350, 2, 1),
(250, 'Túros palacsinta', 'Kinga', 1, 'db', 270, 1, 1),
(251, 'Narancslé', 'Kinga', 2, 'dl', 150, 3, 1),
(252, 'Főtt virsli', 'Jenő', 1, 'pár', 450, 2, 0),
(253, 'Kenyér', 'Jenő', 1, 'szelet', 60, 2, 1),
(254, 'Gyrostál', 'Ági', 1, 'db', 1500, 3, 0),
(255, 'Málnaszörp', 'Ági', 2, 'dl', 100, 10, 0),
(256, 'Sajtos hot-dog', 'Lajos', 2, 'db', 450, 2, 0),
(257, 'Málnaszörp', 'Lajos', 2, 'dl', 100, 3, 0),
(258, 'Gyrostál', 'Jenő', 1, 'db', 1500, 1, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kategoria`
--

CREATE TABLE `kategoria` (
  `kategoriaid` int(11) NOT NULL,
  `kategorianev` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `kategoria`
--

INSERT INTO `kategoria` (`kategoriaid`, `kategorianev`) VALUES
(1, 'Ételek'),
(2, 'Italok');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `forgalom`
--
ALTER TABLE `forgalom`
  ADD PRIMARY KEY (`forgalomid`),
  ADD KEY `forgalomkategoriaid` (`forgalomkategoriaid`);

--
-- A tábla indexei `kategoria`
--
ALTER TABLE `kategoria`
  ADD PRIMARY KEY (`kategoriaid`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `forgalom`
--
ALTER TABLE `forgalom`
  MODIFY `forgalomid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=261;

--
-- AUTO_INCREMENT a táblához `kategoria`
--
ALTER TABLE `kategoria`
  MODIFY `kategoriaid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `forgalom`
--
ALTER TABLE `forgalom`
  ADD CONSTRAINT `forgalom_ibfk_1` FOREIGN KEY (`forgalomkategoriaid`) REFERENCES `kategoria` (`kategoriaid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
