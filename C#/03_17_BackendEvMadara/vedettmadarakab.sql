-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Már 24. 00:45
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
-- Adatbázis: `vedettmadarakab`
--
CREATE DATABASE IF NOT EXISTS `vedettmadarakab` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `vedettmadarakab`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `csalad`
--

CREATE TABLE `csalad` (
  `csalad_id` int(11) NOT NULL,
  `csalad_nev` varchar(20) NOT NULL,
  `csalad_latin` varchar(17) NOT NULL,
  `csalad_rendid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `csalad`
--

INSERT INTO `csalad` (`csalad_id`, `csalad_nev`, `csalad_latin`, `csalad_rendid`) VALUES
(1, 'Alkafélék', 'Alcidae', 10),
(2, 'Bagolyfélék', 'Strigidae', 1),
(3, 'Bankafélék', 'Upupidae', 14),
(4, 'Billegetőfélék', 'Motacillidae', 17),
(5, 'Búvárfélék', 'Gaviidae', 2),
(6, 'Cinegefélék', 'Paridae', 17),
(7, 'Csérfélék', 'Sternidae', 10),
(8, 'Csigaforgató-félék', 'Haematopodidae', 10),
(9, 'Csonttollúfélék', 'Bombycillidae', 17),
(10, 'Csuszkafélék', 'Sittidae', 17),
(11, 'Darufélék', 'Gruidae', 3),
(12, 'Fácánfélék', 'Phasianidae', 16),
(13, 'Fajdfélék', 'Tetraonidae', 16),
(14, 'Fakúszfélék', 'Certhiidae', 17),
(15, 'Fecskefélék', 'Hirundinidae', 17),
(16, 'Flamingófélék', 'Phoenicopteridae', 5),
(17, 'Függőcinege-félék', 'Remizidae', 17),
(18, 'Galambfélék', 'Columbidae', 4),
(19, 'Gébicsfélék', 'Laniidae', 17),
(20, 'Gémfélék', 'Ardeidae', 5),
(21, 'Gólyafélék', 'Ciconiidae', 5),
(22, 'Gödényfélék', 'Pelecanidae', 6),
(23, 'Gulipánfélék', 'Recurvirostridae', 10),
(24, 'Guvatfélék', 'Rallidae', 3),
(25, 'Gyöngybagolyfélék', 'Tytonidae', 1),
(26, 'Gyurgyalagfélék', 'Meropidae', 14),
(27, 'Hajnalmadárfélék', 'Tichodromadidae', 17),
(28, 'Halászsasfélék', 'Pandionidae', 13),
(29, 'Halfarkasfélék', 'Stercorariidae', 10),
(30, 'Harkályfélék', 'Picidae', 7),
(31, 'Íbiszfélék', 'Threskiornithidae', 5),
(32, 'Jégmadárfélék', 'Alcedinidae', 14),
(33, 'Kakukkfélék', 'Cuculidae', 8),
(34, 'Kárókatonafélék', 'Phalacrocoracidae', 6),
(35, 'Lappantyúfélék', 'Caprimulgidae', 9),
(36, 'Légykapófélék', 'Muscicapidae', 17),
(37, 'Lilefélék', 'Charadriidae', 10),
(38, 'Óvilági poszátafélék', 'Sylviidae', 17),
(39, 'Ökörszemfélék', 'Troglodytidae', 17),
(40, 'Őszapófélék', 'Aegithalidae', 17),
(41, 'Pacsirtafélék', 'Alaudidae', 17),
(42, 'Pintyfélék', 'Fringillidae', 17),
(43, 'Récefélék', 'Anatidae', 11),
(44, 'Rigófélék', 'Turdidae', 17),
(45, 'Sárgarigófélék', 'Oriolidae', 17),
(46, 'Sarlósfecskefélék', 'Apodidae', 12),
(47, 'Sármányfélék', 'Emberizidae', 17),
(48, 'Seregélyfélék', 'Sturnidae', 17),
(49, 'Sirályfélék', 'Laridae', 10),
(50, 'Sólyomfélék', 'Falconidae', 13),
(51, 'Szalakótafélék', 'Coraciidae', 14),
(52, 'Szalonkafélék', 'Scolopacidae', 10),
(53, 'Székicsérfélék', 'Glareolidae', 10),
(54, 'Szürkebegyfélék', 'Prunellidae', 17),
(55, 'Timáliafélék', 'Timaliidae', 17),
(56, 'Túzokfélék', 'Otididae', 15),
(57, 'Ugartyúkfélék', 'Burhinidae', 10),
(58, 'Vágómadárfélék', 'Accipitridae', 13),
(59, 'Varjúfélék', 'Corvidae', 17),
(60, 'Verébfélék', 'Passeridae', 17),
(61, 'Vízirigófélék', 'Cinclidae', 17),
(62, 'Vöcsökfélék', 'Podicipedidae', 18);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `faj`
--

CREATE TABLE `faj` (
  `faj_id` int(11) NOT NULL,
  `faj_nev` varchar(45) NOT NULL,
  `faj_latin` varchar(23) NOT NULL,
  `faj_csaladid` int(11) NOT NULL,
  `faj_ertek` int(11) NOT NULL,
  `faj_evszam` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `faj`
--

INSERT INTO `faj` (`faj_id`, `faj_nev`, `faj_latin`, `faj_csaladid`, `faj_ertek`, `faj_evszam`) VALUES
(1, 'kis héja', 'Accipiter brevipes', 58, 500, 1954),
(2, 'héja', 'Accipiter gentilis', 58, 50, 1971),
(3, 'karvaly', 'Accipiter nisus', 58, 50, 1971),
(4, 'rozsdás nádiposzáta', 'Acrocephalus agricola', 38, 25, 1982),
(5, 'nádirigó', 'Acrocephalus arundinace', 38, 25, 1901),
(6, 'fülemülesitke', 'Acrocephalus melanopogo', 38, 50, 1901),
(7, 'csíkosfejű nádiposzáta', 'Acrocephalus paludicola', 38, 1000, 1901),
(8, 'énekes nádiposzáta', 'Acrocephalus palustris', 38, 25, 1901),
(9, 'foltos nádiposzáta', 'Acrocephalus schoenobae', 38, 25, 1901),
(10, 'cserregő nádiposzáta', 'Acrocephalus scirpaceus', 38, 25, 1901),
(11, 'billegetőcankó', 'Actitis hypoleucos', 52, 50, 1954),
(12, 'őszapó', 'Aegithalos caudatus', 40, 25, 1901),
(13, 'gatyáskuvik', 'Aegolius funereus', 2, 50, 1901),
(14, 'barátkeselyű', 'Aegypius monachus', 58, 250, 1954),
(15, 'mezei pacsirta', 'Alauda arvensis', 41, 25, 1901),
(16, 'alka', 'Alca torda', 1, 25, 1954),
(17, 'jégmadár', 'Alcedo atthis', 32, 50, 1954),
(18, 'nyílfarkú réce', 'Anas acuta', 43, 50, 1971),
(19, 'kanalas réce', 'Anas clypeata', 43, 50, 1971),
(20, 'csörgő réce', 'Anas crecca', 43, 50, 2012),
(21, 'fütyülő réce', 'Anas penelope', 43, 50, 1993),
(22, 'böjti réce', 'Anas querquedula', 43, 100, 2008),
(23, 'kendermagos réce', 'Anas strepera', 43, 50, 1971),
(24, 'rövidcsőrű lúd', 'Anser brachyrhynchus', 43, 25, 1971),
(25, 'kis lilik', 'Anser erythropus', 43, 1000, 1982),
(26, 'pártásdaru', 'Anthropoides virgo (Gru', 11, 50, 1954),
(27, 'parlagi pityer', 'Anthus campestris', 4, 50, 1901),
(28, 'rozsdástorkú pityer', 'Anthus cervinus', 4, 25, 1901),
(29, 'réti pityer', 'Anthus pratensis', 4, 25, 1901),
(30, 'havasi pityer', 'Anthus spinoletta', 4, 25, 1901),
(31, 'erdei pityer', 'Anthus trivialis', 4, 25, 1901),
(32, 'sarlósfecske', 'Apus apus', 46, 25, 1901),
(33, 'havasi sarlósfecske', 'Apus melba', 46, 25, 2001),
(34, 'halvány sarlósfecske', 'Apus pallidus', 46, 25, 2001),
(35, 'szirti sas', 'Aquila chrysaetos', 58, 500, 1954),
(36, 'fekete sas', 'Aquila clanga', 58, 500, 1954),
(37, 'parlagi sas', 'Aquila heliaca', 58, 1000, 1954),
(38, 'pusztai sas', 'Aquila nipalensis', 58, 250, 1954),
(39, 'békászó sas', 'Aquila pomarina', 58, 1000, 1954),
(40, 'szürke gém', 'Ardea cinerea', 20, 50, 1971),
(41, 'vörös gém', 'Ardea purpurea', 20, 250, 1954),
(42, 'üstökösgém', 'Ardeola ralloides', 20, 500, 1912),
(43, 'kőforgató', 'Arenaria interpres', 52, 25, 1954),
(44, 'réti fülesbagoly', 'Asio flammeus', 2, 250, 1901),
(45, 'erdei fülesbagoly', 'Asio otus', 2, 50, 1901),
(46, 'kuvik', 'Athene noctua', 2, 100, 1901),
(47, 'barátréce', 'Aythya ferina', 43, 50, 2008),
(48, 'kontyos réce', 'Aythya fuligula', 43, 50, 1971),
(49, 'hegyi réce', 'Aythya marila', 43, 50, 1971),
(50, 'cigányréce', 'Aythya nyroca', 43, 500, 1971),
(51, 'csonttollú', 'Bombycilla garrulus', 9, 25, 1954),
(52, 'bölömbika', 'Botaurus stellaris', 20, 100, 1954),
(53, 'örvös lúd', 'Branta bernicla', 43, 50, 1971),
(54, 'apácalúd', 'Branta leucopsis', 43, 25, 1971),
(55, 'vörösnyakú lúd', 'Branta ruficollis', 43, 1000, 1971),
(56, 'uhu', 'Bubo bubo', 2, 500, 1954),
(57, 'hóbagoly', 'Bubo scandiacus (Nyctea', 2, 100, 1954),
(58, 'pásztorgém', 'Bubulcus ibis', 20, 25, 1954),
(59, 'kerceréce', 'Bucephala clangula', 43, 50, 1971),
(60, 'ugartyúk', 'Burhinus oedicnemus', 57, 500, 1901),
(61, 'egerészölyv', 'Buteo buteo', 58, 25, 1954),
(62, 'gatyás ölyv', 'Buteo lagopus', 58, 50, 1954),
(63, 'pusztai ölyv', 'Buteo rufinus', 58, 100, 1954),
(64, 'szikipacsirta', 'Calandrella brachydacty', 41, 500, NULL),
(65, 'sarkantyús sármány', 'Calcarius lapponicus', 47, 25, 1901),
(66, 'fenyérfutó', 'Calidris alba', 52, 25, 1954),
(67, 'havasi partfutó', 'Calidris alpina', 52, 25, 1954),
(68, 'sarki partfutó', 'Calidris canutus', 52, 25, 1954),
(69, 'sarlós partfutó', 'Calidris ferruginea', 52, 25, 1954),
(70, 'tengeri partfutó', 'Calidris maritima', 52, 25, 1954),
(71, 'vándor partfutó', 'Calidris melanotos', 52, 25, NULL),
(72, 'apró partfutó', 'Calidris minuta', 52, 25, 1954),
(73, 'Temminck-partfutó', 'Calidris temminckii', 52, 25, 1954),
(74, 'európai lappantyú', 'Caprimulgus europaeus', 35, 50, NULL),
(75, 'kenderike', 'Carduelis cannabina', 42, 25, 1901),
(76, 'tengelic', 'Carduelis carduelis', 42, 25, 1901),
(77, 'zöldike', 'Carduelis chloris', 42, 25, 1901),
(78, 'zsezse', 'Carduelis flammea', 42, 25, 1901),
(79, 'sárgacsőrű kenderike', 'Carduelis flavirostris', 42, 25, 1954),
(80, 'szürke zsezse', 'Carduelis hornemanni', 42, 25, 1954),
(81, 'csíz', 'Carduelis spinus', 42, 25, 1901),
(82, 'karmazsinpirók', 'Carpodacus erythrinus', 42, 25, 1988),
(83, 'rövidkarmú fakúsz', 'Certhia brachydactyla', 14, 25, NULL),
(84, 'hegyi fakúsz', 'Certhia familiaris', 14, 25, NULL),
(85, 'berki poszáta', 'Cettia cetti', 38, 25, 2001),
(86, 'széki lile', 'Charadrius alexandrinus', 37, 1000, 1901),
(87, 'kis lile', 'Charadrius dubius', 37, 50, 1901),
(88, 'parti lile', 'Charadrius hiaticula', 37, 25, 1901),
(89, 'sivatagi lile', 'Charadrius leschenaulti', 37, 25, 1993),
(90, 'havasi lile', 'Charadrius morinellus', 37, 50, 1901),
(91, 'fattyúszerkő', 'Chlidonias hybrida', 7, 100, 1901),
(92, 'fehérszárnyú szerkő', 'Chlidonias leucopterus', 7, 250, 1901),
(93, 'kormos szerkő', 'Chlidonias niger', 7, 250, 1901),
(94, 'fehér gólya', 'Ciconia ciconia', 21, 100, 1906),
(95, 'fekete gólya', 'Ciconia nigra', 21, 500, 1906),
(96, 'vízirigó', 'Cinclus cinclus', 61, 500, 1904),
(97, 'kígyászölyv', 'Circaetus gallicus', 58, 1000, 1954),
(98, 'barna rétihéja', 'Circus aeruginosus', 58, 50, 1971),
(99, 'kékes rétihéja', 'Circus cyaneus', 58, 50, 1971),
(100, 'fakó rétihéja', 'Circus macrourus', 58, 250, 1954),
(101, 'hamvas rétihéja', 'Circus pygargus', 58, 500, 1954),
(102, 'szuharbújó', 'Cisticola juncidis', 38, 25, 2012),
(103, 'pettyes kakukk', 'Clamator glandarius', 33, 25, 2012),
(104, 'jegesréce', 'Clangula hyemalis', 43, 250, 1971),
(105, 'meggyvágó', 'Coccothraustes coccothr', 42, 25, 1954),
(106, 'kék galamb', 'Columba oenas', 18, 50, 1971),
(107, 'szalakóta', 'Coracias garrulus', 51, 500, 1901),
(108, 'holló', 'Corvus corax', 59, 50, 1954),
(109, 'kormos varjú', 'Corvus corone corone', 59, 25, 1954),
(110, 'vetési varjú', 'Corvus frugilegus', 59, 50, 2001),
(111, 'csóka', 'Corvus monedula', 59, 50, 1901),
(112, 'fürj', 'Coturnix coturnix', 12, 50, 1971),
(113, 'haris', 'Crex crex', 24, 500, 1971),
(114, 'kakukk', 'Cuculus canorus', 33, 50, 1901),
(115, 'kis hattyú', 'Cygnus columbianus', 43, 50, 1954),
(116, 'énekes hattyú', 'Cygnus cygnus', 43, 50, 1954),
(117, 'molnárfecske', 'Delichon urbicum', 15, 50, 1901),
(118, 'fehérhátú fakopáncs', 'Dendrocopos leucotos', 30, 250, 1901),
(119, 'nagy fakopáncs', 'Dendrocopos major', 30, 25, 1901),
(120, 'Közép fakopáncs', 'Dendrocopos medius', 30, 50, 1901),
(121, 'kis fakopáncs', 'Dendrocopos minor', 30, 50, 1901),
(122, 'balkáni fakopáncs', 'Dendrocopos syriacus', 30, 25, 1954),
(123, 'fekete harkály', 'Dryocopus martius', 30, 50, 1901),
(124, 'nagy kócsag', 'Egretta alba (Ardea alb', 20, 100, 1912),
(125, 'kis kócsag', 'Egretta garzetta', 20, 250, 1912),
(126, 'kuhi', 'Elanus caeruleus', 58, 50, 2012),
(127, 'sordély', 'Emberiza calandra (Mili', 47, 25, 1901),
(128, 'bajszos sármány', 'Emberiza cia', 47, 100, 1901),
(129, 'sövénysármány', 'Emberiza cirlus', 47, 50, 1954),
(130, 'citromsármány', 'Emberiza citrinella', 47, 25, 1901),
(131, 'kerti sármány', 'Emberiza hortulana', 47, 500, 1901),
(132, 'fenyősármány', 'Emberiza leucocephalos', 47, 25, 1988),
(133, 'kucsmás sármány', 'Emberiza melanocephala', 47, 25, 1996),
(134, 'törpesármány', 'Emberiza pusilla', 47, 25, 2001),
(135, 'erdei sármány', 'Emberiza rustica', 47, 25, 2012),
(136, 'nádi sármány', 'Emberiza schoeniclus', 47, 25, 1901),
(137, 'havasi fülespacsirta', 'Eremophila alpestris', 41, 50, 1901),
(138, 'vörösbegy', 'Erithacus rubecula', 44, 25, 1901),
(139, 'Feldegg-sólyom', 'Falco biarmicus', 50, 100, 1996),
(140, 'kerecsensólyom', 'Falco cherrug', 50, 1000, 1954),
(141, 'kis sólyom', 'Falco columbarius', 50, 50, 1954),
(142, 'Eleonóra-sólyom', 'Falco eleonorae', 50, 250, 1971),
(143, 'fehérkarmú vércse', 'Falco naumanni', 50, 500, 1906),
(144, 'vándorsólyom', 'Falco peregrinus', 50, 500, 1954),
(145, 'északi sólyom', 'Falco rusticolus', 50, 100, 1996),
(146, 'kabasólyom', 'Falco subbuteo', 50, 50, 1954),
(147, 'vörös vércse', 'Falco tinnunculus', 50, 50, 1906),
(148, 'kék vércse', 'Falco vespertinus', 50, 500, 1906),
(149, 'örvös légykapó', 'Ficedula albicollis', 36, 25, 1901),
(150, 'kormos légykapó', 'Ficedula hypoleuca', 36, 25, 1901),
(151, 'kis légykapó', 'Ficedula parva', 36, 100, 1901),
(152, 'lunda', 'Fratercula arctica', 1, 25, 1954),
(153, 'erdei pinty', 'Fringilla coelebs', 42, 25, 1901),
(154, 'fenyőpinty', 'Fringilla montifringill', 42, 25, 1901),
(155, 'búbospacsirta', 'Galerida cristata', 41, 50, NULL),
(156, 'sárszalonka', 'Gallinago gallinago', 52, 100, 1993),
(157, 'nagy sárszalonka', 'Gallinago media', 52, 250, 1971),
(158, 'vízityúk', 'Gallinula chloropus', 24, 25, 1954),
(159, 'sarki búvár', 'Gavia arctica', 5, 25, 1971),
(160, 'jeges búvár', 'Gavia immer', 5, 25, 1954),
(161, 'északi búvár', 'Gavia stellata', 5, 25, 1971),
(162, 'kacagó csér', 'Gelochelidon nilotica', 7, 50, NULL),
(163, 'feketeszárnyú székicsér', 'Glareola nordmanni', 53, 500, 1901),
(164, 'székicsér', 'Glareola pratincola', 53, 500, 1901),
(165, 'európai törpekuvik', 'Glaucidium passerinum', 2, 50, NULL),
(166, 'daru', 'Grus grus', 11, 50, 1954),
(167, 'fakó keselyű', 'Gyps fulvus', 58, 250, 1954),
(168, 'csigaforgató', 'Haematopus ostralegus', 8, 25, 1954),
(169, 'rétisas', 'Haliaeetus albicilla', 58, 1000, 1954),
(170, 'héjasas', 'Hieraaetus fasciatus (A', 58, 250, 1954),
(171, 'törpesas', 'Hieraaetus pennatus (Aq', 58, 500, 1954),
(172, 'gólyatöcs', 'Himantopus himantopus', 23, 250, 1954),
(173, 'kerti geze', 'Hippolais icterina', 38, 25, 1901),
(174, 'halvány geze', 'Hippolais pallida (Idun', 38, 50, 1954),
(175, 'vörhenyes fecske', 'Hirundo daurica (Cecrop', 15, 25, 2001),
(176, 'füsti fecske', 'Hirundo rustica', 15, 50, 1901),
(177, 'törpegém', 'Ixobrychus minutus', 20, 100, 1954),
(178, 'nyaktekercs', 'Jynx torquilla', 30, 50, 1901),
(179, 'tövisszúró gébics', 'Lanius collurio', 19, 25, 1954),
(180, 'nagy őrgébics', 'Lanius excubitor', 19, 50, 1954),
(181, 'kis őrgébics', 'Lanius minor', 19, 50, 1954),
(182, 'vörösfejű gébics', 'Lanius senator', 19, 50, 1954),
(183, 'ezüstsirály', 'Larus argentatus', 49, 25, 1954),
(184, 'korallsirály', 'Larus audouinii', 49, 50, 2012),
(185, 'viharsirály', 'Larus canus', 49, 25, 1954),
(186, 'heringsirály', 'Larus fuscus', 49, 50, 1954),
(187, 'vékonycsőrű sirály', 'Larus genei (Chroicocep', 49, 25, 1993),
(188, 'sarki sirály', 'Larus glaucoides', 49, 25, 1954),
(189, 'jeges sirály', 'Larus hyperboreus', 49, 25, 1954),
(190, 'halászsirály', 'Larus ichthyaetus (Icht', 49, 25, 1993),
(191, 'dolmányos sirály', 'Larus marinus', 49, 25, 1988),
(192, 'szerecsensirály', 'Larus melanocephalus', 49, 100, 1954),
(193, 'kis sirály', 'Larus minutus (Hydrocol', 49, 25, 1954),
(194, 'dankasirály', 'Larus ridibundus (Chroi', 49, 50, 1901),
(195, 'sárjáró', 'Limicola falcinellus', 52, 25, 1954),
(196, 'kis goda', 'Limosa lapponica', 52, 25, 1954),
(197, 'nagy goda', 'Limosa limosa', 52, 500, 1954),
(198, 'berki tücsökmadár', 'Locustella fluviatilis', 38, 50, 1901),
(199, 'nádi tücsökmadár', 'Locustella luscinioides', 38, 50, 1901),
(200, 'réti tücsökmadár', 'Locustella naevia', 38, 50, 1901),
(201, 'keresztcsőrű', 'Loxia curvirostra', 42, 25, 1954),
(202, 'szalagos keresztcsőrű', 'Loxia leucoptera', 42, 25, 1993),
(203, 'erdei pacsirta', 'Lullula arborea', 41, 50, 1901),
(204, 'nagy fülemüle', 'Luscinia luscinia', 44, 100, 1901),
(205, 'fülemüle', 'Luscinia megarhynchos', 44, 25, 1901),
(206, 'kékbegy', 'Luscinia svecica', 44, 50, 1901),
(207, 'kis sárszalonka', 'Lymnocryptes minimus', 52, 25, 1971),
(208, 'márványos réce', 'Marmaronetta angustiros', 43, 250, 1971),
(209, 'füstös réce', 'Melanitta fusca', 43, 250, 1971),
(210, 'fekete réce', 'Melanitta nigra', 43, 50, 1971),
(211, 'kalandrapacsirta', 'Melanocorypha calandra', 41, 25, 1954),
(212, 'kis bukó', 'Mergus albellus', 43, 50, 1971),
(213, 'nagy bukó', 'Mergus merganser', 43, 50, 1971),
(214, 'örvös bukó', 'Mergus serrator', 43, 50, 1971),
(215, 'gyurgyalag', 'Merops apiaster', 26, 100, 1954),
(216, 'barna kánya', 'Milvus migrans', 58, 500, 1971),
(217, 'vörös kánya', 'Milvus milvus', 58, 500, 1954),
(218, 'kövirigó', 'Monticola saxatilis', 44, 500, 1901),
(219, 'kék kövirigó', 'Monticola solitarius', 44, 25, 2012),
(220, 'havasipinty', 'Montifringilla nivalis', 60, 25, 1901),
(221, 'barázdabillegető', 'Motacilla alba', 4, 25, 1901),
(222, 'hegyi billegető', 'Motacilla cinerea', 4, 50, 1901),
(223, 'citrombillegető', 'Motacilla citreola', 4, 25, 1993),
(224, 'sárga billegető', 'Motacilla flava', 4, 25, 1901),
(225, 'szürke légykapó', 'Muscicapa striata', 36, 50, 1901),
(226, 'dögkeselyű', 'Neophron percnopterus', 58, 250, 1954),
(227, 'üstökösréce', 'Netta rufina', 43, 50, 1971),
(228, 'fenyőszajkó', 'Nucifraga caryocatactes', 59, 25, 1954),
(229, 'nagy póling', 'Numenius arquata', 52, 500, 1954),
(230, 'kis póling', 'Numenius phaeopus', 52, 50, 1954),
(231, 'vékonycsőrű póling', 'Numenius tenuirostris', 52, 1000, 1954),
(232, 'bakcsó', 'Nycticorax nycticorax', 20, 100, 1954),
(233, 'déli hantmadár', 'Oenanthe hispanica', 44, 25, 1954),
(234, 'pusztai hantmadár', 'Oenanthe isabellina', 44, 25, 2001),
(235, 'hantmadár', 'Oenanthe oenanthe', 44, 50, 1901),
(236, 'apácahantmadár', 'Oenanthe pleschanka', 44, 25, 1954),
(237, 'sárgarigó', 'Oriolus oriolus', 45, 25, 1901),
(238, 'túzok', 'Otis tarda', 56, 1000, 1971),
(239, 'füleskuvik', 'Otus scops', 2, 100, 1901),
(240, 'kékcsőrű réce', 'Oxyura leucocephala', 43, 500, 1954),
(241, 'halászsas', 'Pandion haliaetus', 28, 500, 1954),
(242, 'barkóscinege', 'Panurus biarmicus', 55, 50, 1901),
(243, 'fenyvescinege', 'Parus ater (Periparus a', 6, 25, 1901),
(244, 'kék cinege', 'Parus caeruleus (Cyanis', 6, 25, 1901),
(245, 'búbos cinege', 'Parus cristatus (Lophop', 6, 25, 1901),
(246, 'széncinege', 'Parus major', 6, 25, 1901),
(247, 'kormosfejű cinege', 'Parus montanus (Poecile', 6, 25, 1901),
(248, 'barátcinege', 'Parus palustris (Poecil', 6, 25, 1901),
(249, 'mezei veréb', 'Passer montanus', 60, 25, 2001),
(250, 'borzas gödény', 'Pelecanus crispus', 22, 500, 1954),
(251, 'rózsás gödény', 'Pelecanus onocrotalus', 22, 250, 1954),
(252, 'darázsölyv', 'Pernis apivorus', 58, 100, 1954),
(253, 'kis kárókatona', 'Phalacrocorax pygmeus', 34, 100, 1954),
(254, 'laposcsőrű víztaposó', 'Phalaropus fulicarius', 52, 25, 1954),
(255, 'vékonycsőrű víztaposó', 'Phalaropus lobatus', 52, 25, 1954),
(256, 'pajzsos cankó', 'Philomachus pugnax', 52, 50, NULL),
(257, 'rózsás flamingó', 'Phoenicopterus ruber', 16, 50, 1954),
(258, 'házi rozsdafarkú', 'Phoenicurus ochruros', 44, 25, 1901),
(259, 'kerti rozsdafarkú', 'Phoenicurus phoenicurus', 44, 50, 1901),
(260, 'Bonelli-füzike', 'Phylloscopus bonelli', 38, 25, 1993),
(261, 'csilpcsalpfüzike', 'Phylloscopus collybita', 38, 25, 1901),
(262, 'vándorfüzike', 'Phylloscopus inornatus', 38, 25, 1993),
(263, 'királyfüzike', 'Phylloscopus proregulus', 38, 25, 2001),
(264, 'sisegő füzike', 'Phylloscopus sibilatrix', 38, 25, 1901),
(265, 'fitiszfüzike', 'Phylloscopus trochilus', 38, 25, 1901),
(266, 'hamvas küllő', 'Picus canus', 30, 50, 1901),
(267, 'zöld küllő', 'Picus viridis', 30, 50, 1901),
(268, 'nagy pirók', 'Pinicola enucleator', 42, 25, 1954),
(269, 'kanalasgém', 'Platalea leucorodia', 31, 500, 1912),
(270, 'hósármány', 'Plectrophenax nivalis', 47, 25, 1901),
(271, 'batla', 'Plegadis falcinellus', 31, 500, 1912),
(272, 'aranylile', 'Pluvialis apricaria', 37, 25, 1901),
(273, 'ezüstlile', 'Pluvialis squatarola', 37, 25, 1901),
(274, 'füles vöcsök', 'Podiceps auritus', 62, 50, 1954),
(275, 'búbos vöcsök', 'Podiceps cristatus', 62, 50, 1954),
(276, 'vörösnyakú vöcsök', 'Podiceps grisegena', 62, 250, 1954),
(277, 'feketenyakú vöcsök', 'Podiceps nigricollis', 62, 100, 1954),
(278, 'Steller-pehelyréce', 'Polysticta stelleri', 43, 250, 2001),
(279, 'kék fú', 'Porphyrio porphyrio', 24, 25, 1971),
(280, 'kis vízicsibe', 'Porzana parva', 24, 50, 1954),
(281, 'pettyes vízicsibe', 'Porzana porzana', 24, 50, 1954),
(282, 'törpe vízicsibe', 'Porzana pusilla', 24, 500, NULL),
(283, 'havasi szürkebegy', 'Prunella coliaris', 54, 25, 1901),
(284, 'erdei szürkebegy', 'Prunella modularis', 54, 25, 1901),
(285, 'havasi csóka', 'Pyrrhocorax graculus', 59, 25, 1954),
(286, 'havasi varjú', 'Pyrrhocorax pyrrhocorax', 59, 25, 1954),
(287, 'süvöltő', 'Pyrrhula pyrrhula', 42, 25, 1901),
(288, 'guvat', 'Rallus aquaticus', 24, 50, 1954),
(289, 'gulipán', 'Recurvirostra avosetta', 23, 250, 1954),
(290, 'tüzesfejű királyka', 'Regulus ignicapilla', 38, 25, 1901),
(291, 'sárgafejű királyka', 'Regulus regulus', 38, 25, 1901),
(292, 'függőcinege', 'Remiz pendulinus', 17, 50, 1901),
(293, 'partifecske', 'Riparia riparia', 15, 50, 1901),
(294, 'háromujjú csüllő', 'Rissa tridactyla', 49, 25, NULL),
(295, 'rozsdás csuk', 'Saxicola rubetra', 44, 25, 1901),
(296, 'cigánycsuk', 'Saxicola torquatus', 44, 25, 1901),
(297, 'csicsörke', 'Serinus serinus', 42, 25, 1901),
(298, 'csuszka', 'Sitta europaea', 10, 25, 1901),
(299, 'pehelyréce', 'Somateria mollissima', 43, 50, 1971),
(300, 'cifra pehelyréce', 'Somateria spectabilis', 43, 25, 1971),
(301, 'nyílfarkú halfarkas', 'Stercorarius longicaudu', 29, 25, 1954),
(302, 'ékfarkú halfarkas', 'Stercorarius parasiticu', 29, 25, 1954),
(303, 'szélesfarkú halfarkas', 'Stercorarius pomarinus', 29, 25, 1954),
(304, 'nagy halfarkas', 'Stercorarius skua', 29, 25, 1954),
(305, 'kis csér', 'Sterna albifrons (Stern', 7, 500, 1954),
(306, 'lócsér', 'Sterna caspia (Hydropro', 7, 50, 1954),
(307, 'küszvágó csér', 'Sterna hirundo', 7, 100, 1954),
(308, 'sarki csér', 'Sterna paradisaea', 7, 25, 1993),
(309, 'kenti csér', 'Sterna sandvicensis', 7, 25, 1954),
(310, 'vadgerle', 'Streptopelia turtur', 18, 50, 1971),
(311, 'macskabagoly', 'Strix aluco', 2, 50, 1954),
(312, 'uráli bagoly', 'Strix uralensis', 2, 100, NULL),
(313, 'pásztormadár', 'Sturnus roseus (Pastor ', 48, 50, 1901),
(314, 'karvalybagoly', 'Surnia ulula', 2, 50, 1954),
(315, 'barátposzáta', 'Sylvia atricapilla', 38, 25, 1901),
(316, 'kerti poszáta', 'Sylvia borin', 38, 50, 1954),
(317, 'bajszos poszáta', 'Sylvia cantillans', 38, 25, 2012),
(318, 'mezei poszáta', 'Sylvia communis', 38, 25, 1901),
(319, 'kis poszáta', 'Sylvia curruca', 38, 25, 1901),
(320, 'kucsmás poszáta', 'Sylvia melanocephala', 38, 25, 1982),
(321, 'karvalyposzáta', 'Sylvia nisoria', 38, 50, 1901),
(322, 'kis vöcsök', 'Tachybaptus ruficollis', 62, 50, 1954),
(323, 'vörös ásólúd', 'Tadorna ferruginea', 43, 25, 1971),
(324, 'bütykös ásólúd', 'Tadorna tadorna', 43, 50, 1971),
(325, 'kékfarkú', 'Tarsiger cyanurus', 44, 25, 2012),
(326, 'nyírfajd', 'Tetrao tetrix (Lyrurus ', 13, 50, 1954),
(327, 'siketfajd', 'Tetrao urogallus', 13, 50, 1954),
(328, 'császármadár', 'Tetrastes bonasia (Bona', 13, 500, 1954),
(329, 'reznek', 'Tetrax tetrax', 56, 500, 1954),
(330, 'hajnalmadár', 'Tichodroma muraria', 27, 50, 1901),
(331, 'füstös cankó', 'Tringa erythropus', 52, 25, 1954),
(332, 'réti cankó', 'Tringa glareola', 52, 25, 1954),
(333, 'szürke cankó', 'Tringa nebularia', 52, 25, 1954),
(334, 'erdei cankó', 'Tringa ochropus', 52, 25, 1954),
(335, 'tavi cankó', 'Tringa stagnatilis', 52, 250, 1954),
(336, 'piroslábú cankó', 'Tringa totanus', 52, 250, 1954),
(337, 'ökörszem', 'Troglodytes troglodytes', 39, 25, 1901),
(338, 'cankópartfutó', 'Tryngites subruficollis', 52, 50, 1996),
(339, 'szőlőrigó', 'Turdus iliacus', 44, 25, 1901),
(340, 'fekete rigó', 'Turdus merula', 44, 25, 1901),
(341, 'énekes rigó', 'Turdus philomelos', 44, 25, 1901),
(342, 'fenyőrigó', 'Turdus pilaris', 44, 25, 1954),
(343, 'örvös rigó', 'Turdus torquatus', 44, 25, 1901),
(344, 'léprigó', 'Turdus viscivorus', 44, 50, 1901),
(345, 'gyöngybagoly', 'Tyto alba', 25, 100, 1901),
(346, 'búbos banka', 'Upupa epops', 3, 50, NULL),
(347, 'lilebíbic', 'Vanellus gregarius (Che', 37, 500, 1954),
(348, 'fehérfarkú lilebíbic', 'Vanellus leucurus (Chet', 37, 25, 1988),
(349, 'tüskés bíbic', 'Vanellus spinosus (Hopl', 37, 25, 1996),
(350, 'bíbic', 'Vanellus vanellus', 37, 50, 1901),
(351, 'fecskesirály', 'Xema sabini', 49, 25, 1954),
(352, 'terekcankó', 'Xenus cinereus', 52, 25, 1954);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rend`
--

CREATE TABLE `rend` (
  `rend_id` int(11) NOT NULL,
  `rend_nev` varchar(20) NOT NULL,
  `rend_latin` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `rend`
--

INSERT INTO `rend` (`rend_id`, `rend_nev`, `rend_latin`) VALUES
(1, 'Bagolyalakúak', 'Strigiformes'),
(2, 'Búváralakúak', 'Gaviiformes'),
(3, 'Darualakúak', 'Gruiformes'),
(4, 'Galambalakúak', 'Columbiformes'),
(5, 'Gólyaalakúak', 'Ciconiiformes'),
(6, 'Gödényalakúak', 'Pelecaniformes'),
(7, 'Harkályalakúak', 'Piciformes'),
(8, 'Kakukkalakúak', 'Cuculiformes'),
(9, 'Lappantyúalakúak', 'Caprimulgiformes'),
(10, 'Lilealakúak', 'Charadriiformes'),
(11, 'Lúdnyakúak', 'Anseriformes'),
(12, 'Sarlósfecske-alakúak', 'Apodiformes'),
(13, 'Sólyomalakúak', 'Falconiformes'),
(14, 'Szalakótaalakúak', 'Coraciiformes'),
(15, 'Túzokalakúak', 'Otidiformes'),
(16, 'Tyúkalakúak', 'Galliformes'),
(17, 'Verébalakúak', 'Passeriformes'),
(18, 'Vöcsökalakúak', 'Podocopediformes');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `csalad`
--
ALTER TABLE `csalad`
  ADD PRIMARY KEY (`csalad_id`),
  ADD UNIQUE KEY `nev` (`csalad_nev`),
  ADD UNIQUE KEY `latin` (`csalad_latin`),
  ADD KEY `csalad_rendid` (`csalad_rendid`);

--
-- A tábla indexei `faj`
--
ALTER TABLE `faj`
  ADD PRIMARY KEY (`faj_id`),
  ADD UNIQUE KEY `nev` (`faj_nev`),
  ADD UNIQUE KEY `latin` (`faj_latin`),
  ADD KEY `fk_fajcsalad` (`faj_csaladid`);

--
-- A tábla indexei `rend`
--
ALTER TABLE `rend`
  ADD PRIMARY KEY (`rend_id`),
  ADD UNIQUE KEY `nev` (`rend_nev`),
  ADD UNIQUE KEY `latin` (`rend_latin`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `faj`
--
ALTER TABLE `faj`
  MODIFY `faj_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=353;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `csalad`
--
ALTER TABLE `csalad`
  ADD CONSTRAINT `fk_csaladrend` FOREIGN KEY (`csalad_rendid`) REFERENCES `rend` (`rend_id`);

--
-- Megkötések a táblához `faj`
--
ALTER TABLE `faj`
  ADD CONSTRAINT `fk_fajcsalad` FOREIGN KEY (`faj_csaladid`) REFERENCES `csalad` (`csalad_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
