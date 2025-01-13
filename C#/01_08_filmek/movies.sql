-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Jan 13. 06:42
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
-- Adatbázis: `movies`
--
CREATE DATABASE IF NOT EXISTS `movies` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `movies`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `movies`
--

CREATE TABLE `movies` (
  `id` int(11) NOT NULL,
  `nev` varchar(35) DEFAULT NULL,
  `kiadaseve` int(4) DEFAULT NULL,
  `bevetel` decimal(8,3) DEFAULT NULL,
  `ertekeles` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `movies`
--

INSERT INTO `movies` (`id`, `nev`, `kiadaseve`, `bevetel`, `ertekeles`) VALUES
(1, 'A Serious Man', 2009, 30.680, 64),
(2, 'Across the Universe', 2007, 29.370, 84),
(3, 'Beginners', 2011, 14.310, 80),
(4, 'Dear John', 2010, 114.970, 66),
(5, 'Enchanted', 2007, 340.490, 80),
(6, 'Fireproof', 2008, 33.470, 51),
(7, 'Four Christmases', 2008, 161.830, 52),
(8, 'Ghosts of Girlfriends Past', 2009, 102.220, 47),
(9, 'Gnomeo and Juliet', 2011, 193.970, 52),
(10, 'Going the Distance', 2010, 42.050, 56),
(11, 'Good Luck Chuck', 2007, 59.190, 61),
(12, 'He\'s Just Not That Into You', 2009, 178.840, 60),
(13, 'High School Musical 3: Senior Year', 2008, 252.040, 76),
(14, 'I Love You Phillip Morris', 2010, 20.100, 57),
(15, 'It\'s Complicated', 2009, 224.600, 63),
(16, 'Jane Eyre', 2011, 30.150, 77),
(17, 'Just Wright', 2010, 21.570, 58),
(18, 'Killers', 2010, 93.400, 45),
(19, 'Knocked Up', 2007, 219.000, 83),
(20, 'Leap Year', 2010, 32.590, 49),
(21, 'Letters to Juliet', 2010, 79.180, 62),
(22, 'License to Wed', 2007, 69.310, 55),
(23, 'Life as We Know It', 2010, 96.160, 62),
(24, 'Love & Other Drugs', 2010, 54.530, 55),
(25, 'Love Happens', 2009, 36.080, 40),
(26, 'Made of Honor', 2008, 105.960, 61),
(27, 'Mamma Mia!', 2008, 609.470, 76),
(28, 'Marley and Me', 2008, 206.070, 77),
(29, 'Midnight in Paris', 2011, 148.660, 84),
(30, 'Miss Pettigrew Lives for a Day', 2008, 15.170, 70),
(31, 'Monte Carlo', 2011, 39.660, 50),
(32, 'Music and Lyrics', 2007, 145.900, 70),
(33, 'My Week with Marilyn', 2011, 8.260, 84),
(34, 'New Year\'s Eve', 2011, 142.040, 48),
(35, 'Nick and Norah\'s Infinite Playlist', 2008, 33.530, 67),
(36, 'No Reservations', 2007, 92.600, 64),
(37, 'Not Easily Broken', 2009, 10.700, 66),
(38, 'One Day', 2011, 55.240, 54),
(39, 'Our Family Wedding', 2010, 21.370, 49),
(40, 'Over Her Dead Body', 2008, 20.710, 47),
(41, 'P.S. I Love You', 2007, 153.090, 82),
(42, 'Penelope', 2008, 20.740, 74),
(43, 'Rachel Getting Married', 2008, 16.610, 61),
(44, 'Remember Me', 2010, 55.860, 70),
(45, 'Sex and the City', 2008, 415.250, 81),
(46, 'Sex and the City 2', 2010, 288.350, 49),
(47, 'Sex and the City Two', 2010, 288.350, 49),
(48, 'She\'s Out of My League', 2010, 48.810, 60),
(49, 'Something Borrowed', 2011, 60.180, 48),
(50, 'Tangled', 2010, 355.010, 88),
(51, 'The Back-up Plan', 2010, 77.090, 47),
(52, 'The Curious Case of Benjamin Button', 2008, 285.430, 81),
(53, 'The Duchess', 2008, 43.310, 68),
(54, 'The Heartbreak Kid', 2007, 127.770, 41),
(55, 'The Invention of Lying', 2009, 32.400, 47),
(56, 'The Proposal', 2009, 314.700, 74),
(57, 'The Time Traveler\'s Wife', 2009, 101.330, 65),
(58, 'The Twilight Saga: New Moon', 2009, 709.820, 78),
(59, 'The Ugly Truth', 2009, 205.300, 68),
(60, 'Twilight', 2008, 376.660, 82),
(61, 'Twilight: Breaking Dawn', 2011, 702.170, 68),
(62, 'Tyler Perry\'s Why Did I get Married', 2007, 55.860, 47),
(63, 'Valentine\'s Day', 2010, 217.570, 54),
(64, 'Waiting For Forever', 2011, 0.030, 53),
(65, 'Waitress', 2007, 22.180, 67),
(66, 'WALL-E', 2008, 521.280, 89),
(67, 'Water For Elephants', 2011, 117.090, 72),
(68, 'What Happens in Vegas', 2008, 219.370, 72),
(69, 'When in Rome', 2010, 43.040, 44),
(70, 'You Will Meet a Tall Dark Stranger', 2010, 26.660, 35),
(71, 'Youth in Revolt', 2010, 19.620, 52),
(72, 'Zack and Miri Make a Porno', 2008, 41.940, 70);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `movies`
--
ALTER TABLE `movies`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `movies`
--
ALTER TABLE `movies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=86;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
