-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Okt 14. 10:39
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
-- Adatbázis: `vedett`
--
CREATE DATABASE IF NOT EXISTS `vedett` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `vedett`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vedett`
--

CREATE TABLE `vedett` (
  `faj` varchar(26) DEFAULT NULL,
  `eszmeiertek` int(7) DEFAULT NULL,
  `kategoria` varchar(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `vedett`
--

INSERT INTO `vedett` (`faj`, `eszmeiertek`, `kategoria`) VALUES
('pannon gyík', 100000, 'hüllők'),
('kis héja', 250000, 'madarak'),
('csíkosfejű nádiposzáta', 500000, 'madarak'),
('barátkeselyű', 250000, 'madarak'),
('kis lilik', 1000000, 'madarak'),
('szirti sas', 500000, 'madarak'),
('fekete sas', 500000, 'madarak'),
('parlagi sas', 1000000, 'madarak'),
('békászó sas', 1000000, 'madarak'),
('vörös gém', 250000, 'madarak'),
('üstökösgém', 250000, 'madarak'),
('keleti lápibagoly', 100000, 'ízeltlábúak'),
('réti fülesbagoly', 250000, 'madarak'),
('magyar őszi-fésűsbagoly', 100000, 'ízeltlábúak'),
('kuvik', 100000, 'madarak'),
('cigányréce', 500000, 'madarak'),
('piszedenevér', 100000, 'emlősök'),
('Petényi-márna', 100000, 'halak'),
('császármadár', 500000, 'madarak'),
('bölömbika', 100000, 'madarak'),
('vörösnyakú lúd', 500000, 'madarak'),
('uhu', 250000, 'madarak'),
('ugartyúk', 250000, 'madarak'),
('pusztai ölyv', 100000, 'madarak'),
('sziki pacsirta', 250000, 'madarak'),
('farkas', 250000, 'emlősök'),
('beregi futrinka', 100000, 'ízeltlábúak'),
('magyar futrinka', 100000, 'ízeltlábúak'),
('zempléni futrinka', 100000, 'ízeltlábúak'),
('sztyeplepke', 100000, 'ízeltlábúak'),
('mecseki őszitegzes', 100000, 'ízeltlábúak'),
('széki lile', 500000, 'madarak'),
('lilebíbic', 250000, 'madarak'),
('fattyúszerkő', 100000, 'madarak'),
('fehérszárnyú szerkő', 250000, 'madarak'),
('kormos szerkő', 250000, 'madarak'),
('magyar ősziaraszoló', 100000, 'ízeltlábúak'),
('fehér gólya', 100000, 'madarak'),
('fekete gólya', 500000, 'madarak'),
('vízirigó', 250000, 'madarak'),
('kígyászölyv', 500000, 'madarak'),
('fakó rétihéja', 100000, 'madarak'),
('hamvas rétihéja', 250000, 'madarak'),
('ezüstsávos szénalepke', 100000, 'ízeltlábúak'),
('haragos sikló', 500000, 'hüllők'),
('szalakóta', 500000, 'madarak'),
('ritka hegyiszitakötő', 100000, 'ízeltlábúak'),
('haris', 500000, 'madarak'),
('díszes csuklyásbagoly', 100000, 'ízeltlábúak'),
('vértesi csuklyásbagoly', 100000, 'ízeltlábúak'),
('fehérhátú fakopáncs', 100000, 'madarak'),
('magyar tavaszi-fésűsbagoly', 100000, 'ízeltlábúak'),
('pusztai gyalogcincér', 100000, 'ízeltlábúak'),
('nagy kócsag', 100000, 'madarak'),
('kis kócsag', 250000, 'madarak'),
('kerti sármány', 250000, 'madarak'),
('bükki hegyiaraszoló', 100000, 'ízeltlábúak'),
('Anker-araszoló', 100000, 'ízeltlábúak'),
('tiszai ingola', 250000, 'körszájúak'),
('dunai ingola', 100000, 'körszájúak'),
('Feldegg-sólyom', 100000, 'madarak'),
('kerecsensólyom', 1000000, 'madarak'),
('Eleonóra-sólyom', 100000, 'madarak'),
('fehérkarmú vércse', 500000, 'madarak'),
('vándorsólyom', 500000, 'madarak'),
('északi sólyom', 100000, 'madarak'),
('kék vércse', 500000, 'madarak'),
('nagy sárszalonka', 250000, 'madarak'),
('feketeszárnyú székicsér', 500000, 'madarak'),
('székicsér', 500000, 'madarak'),
('budai szakállasmoly', 100000, 'ízeltlábúak'),
('nagy szikibagoly', 100000, 'ízeltlábúak'),
('rétisas', 1000000, 'madarak'),
('héjasas', 100000, 'madarak'),
('törpesas', 500000, 'madarak'),
('gólyatöcs', 250000, 'madarak'),
('dunai galóca', 100000, 'halak'),
('dobozi pikkelyescsiga', 100000, 'puhatestűek'),
('magyar tarsza', 100000, 'ízeltlábúak'),
('Stys-tarsza', 100000, 'ízeltlábúak'),
('törpegém', 100000, 'madarak'),
('füstös ősziaraszoló', 100000, 'ízeltlábúak'),
('nagy goda', 100000, 'madarak'),
('nagy fülemüle', 100000, 'madarak'),
('vidra', 250000, 'emlősök'),
('hiúz', 500000, 'emlősök'),
('márványos réce', 250000, 'madarak'),
('gyurgyalag', 100000, 'madarak'),
('északi pocok', 250000, 'emlősök'),
('barna kánya', 250000, 'madarak'),
('vörös kánya', 500000, 'madarak'),
('hosszúszárnyú denevér', 100000, 'emlősök'),
('kövirigó', 500000, 'madarak'),
('nagyfülű denevér', 100000, 'emlősök'),
('tavi denevér', 100000, 'emlősök'),
('csonkafülű denevér', 100000, 'emlősök'),
('dögkeselyű', 100000, 'madarak'),
('nagy póling', 100000, 'madarak'),
('vékonycsőrű póling', 1000000, 'madarak'),
('óriás-koraidenevér', 100000, 'emlősök'),
('hóbagoly', 100000, 'madarak'),
('bakcsó', 100000, 'madarak'),
('remetebogár', 100000, 'ízeltlábúak'),
('túzok', 1000000, 'madarak'),
('nagyfoltú bagoly', 100000, 'ízeltlábúak'),
('kékcsőrű réce', 500000, 'madarak'),
('halászsas', 250000, 'madarak'),
('álolaszsáska', 100000, 'ízeltlábúak'),
('borzas gödény', 250000, 'madarak'),
('rózsás gödény', 250000, 'madarak'),
('darázsölyv', 100000, 'madarak'),
('kis kárókatona', 500000, 'madarak'),
('csüngőaraszoló', 100000, 'ízeltlábúak'),
('atracélcincér', 100000, 'ízeltlábúak'),
('kanalasgém', 500000, 'madarak'),
('drávai tegzes', 100000, 'ízeltlábúak'),
('fóti boglárka', 100000, 'ízeltlábúak'),
('batla', 250000, 'madarak'),
('villányi télibagoly', 100000, 'ízeltlábúak'),
('csíkos boglárka', 100000, 'ízeltlábúak'),
('törpevízicsibe', 250000, 'madarak'),
('gulipán', 250000, 'madarak'),
('kereknyergű patkósdenevér', 100000, 'emlősök'),
('nagy patkósdenevér', 100000, 'emlősök'),
('Metelka-medvelepke', 100000, 'ízeltlábúak'),
('csíkos szöcskeegér', 250000, 'emlősök'),
('nyugati földikutya', 500000, 'emlősök'),
('kis csér', 250000, 'madarak'),
('urali bagoly', 100000, 'madarak'),
('reznek', 250000, 'madarak'),
('tavi cankó', 250000, 'madarak'),
('piroslábú cankó', 100000, 'madarak'),
('gyöngybagoly', 100000, 'madarak'),
('lápi póc', 100000, 'halak'),
('parlagi vipera', 1000000, 'hüllők'),
('német bucó', 100000, 'halak'),
('magyar bucó', 100000, 'halak');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
