-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Dec 16. 17:22
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
-- Adatbázis: `karacsonyidiszek`
--
CREATE DATABASE IF NOT EXISTS `karacsonyidiszek` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `karacsonyidiszek`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `diszek`
--

CREATE TABLE `diszek` (
  `nap` int(11) NOT NULL,
  `keszharang` int(11) NOT NULL,
  `eladottharang` int(11) NOT NULL,
  `keszangyal` int(11) NOT NULL,
  `eladottangyal` int(11) NOT NULL,
  `keszfenyo` int(11) NOT NULL,
  `eladottfenyo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `diszek`
--

INSERT INTO `diszek` (`nap`, `keszharang`, `eladottharang`, `keszangyal`, `eladottangyal`, `keszfenyo`, `eladottfenyo`) VALUES
(1, 3, 0, 0, 0, 4, 0),
(2, 4, 0, 5, -2, 1, 0),
(3, 1, -2, 4, -3, 0, 0),
(4, 0, 0, 3, -1, 0, 0),
(5, 0, 0, 0, -2, 3, -2),
(6, 0, -5, 6, -5, 0, -1),
(7, 3, 0, 3, 0, 1, -3),
(8, 2, -3, 0, 0, 3, 0),
(9, 5, 0, 6, -4, 2, -3),
(10, 0, -3, 0, 0, 8, -4),
(11, 2, -5, 0, -3, 1, -3),
(12, 0, -1, 0, -2, 0, 0),
(13, 8, -3, 0, -4, 8, 0),
(14, 0, 0, 0, -1, 3, -6),
(15, 0, 0, 3, 0, 5, -4),
(16, 4, -6, 2, -1, 6, -5),
(17, 2, -4, 8, -6, 0, 0),
(18, 0, -1, 4, -5, 3, -6),
(19, 0, 0, 1, -6, 0, 0),
(20, 2, -3, 0, 0, 2, -4),
(21, 7, 0, 5, 0, 3, -3),
(22, 3, 0, 0, 0, 4, -4),
(23, 4, -6, 5, -3, 7, -2),
(24, 0, 0, 0, -5, 8, -7),
(25, 0, 0, 6, -2, 9, -4),
(26, 0, 0, 0, -4, 5, 0),
(27, 4, 0, 3, -2, 0, 0),
(28, 0, -6, 2, -3, 2, -4),
(29, 0, -4, 4, -6, 1, -6),
(30, 0, 0, 7, -2, 0, -12),
(31, 0, -2, 8, -6, 0, -5),
(32, 10, 0, 0, -3, 4, -2),
(33, 0, 0, 0, -4, 3, -4),
(34, 5, -8, 0, 0, 4, 0),
(35, 2, 0, 9, -3, 6, 0),
(36, 0, -3, 0, -2, 8, -4),
(37, 0, 0, 6, -4, 3, -2),
(38, 0, 0, 8, -5, 6, -3),
(39, 3, -2, 0, -5, 5, -4),
(40, 2, -4, 4, -3, 2, 0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `diszek`
--
ALTER TABLE `diszek`
  ADD PRIMARY KEY (`nap`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
