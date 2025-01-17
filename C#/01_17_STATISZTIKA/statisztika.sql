-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Jan 17. 08:26
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
-- Adatbázis: `statisztika`
--
CREATE DATABASE IF NOT EXISTS `statisztika` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `statisztika`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `statisztika`
--

CREATE TABLE `statisztika` (
  `Azonosito` varchar(5) NOT NULL,
  `Atlag` int(1) DEFAULT NULL,
  `Hianyzas` int(3) DEFAULT NULL,
  `Tavolsag` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `statisztika`
--

INSERT INTO `statisztika` (`Azonosito`, `Atlag`, `Hianyzas`, `Tavolsag`) VALUES
('AA01F', 2, 28, 135),
('ÁT02F', 5, 20, 100),
('BA03N', 3, 75, 80),
('BC04F', 5, 35, 95),
('BF05N', 2, 33, 130),
('BL12F', 5, 0, 40),
('CM06F', 5, 45, 10),
('DS07F', 4, 30, 30),
('EH08N', 3, 20, 10),
('FÁ09F', 5, 40, 10),
('FP10F', 4, 50, 45),
('GG15F', 5, 75, 130),
('KR14N', 4, 15, 150);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `statisztika`
--
ALTER TABLE `statisztika`
  ADD PRIMARY KEY (`Azonosito`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
