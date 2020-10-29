-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 29 okt 2020 om 15:57
-- Serverversie: 10.1.35-MariaDB
-- PHP-versie: 7.2.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `geldautomaat`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `transaction`
--

CREATE TABLE `transaction` (
  `transactionID` smallint(11) NOT NULL,
  `userID` smallint(11) NOT NULL,
  `transactionType` int(2) NOT NULL,
  `transactionAmount` int(55) NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `transaction`
--

INSERT INTO `transaction` (`transactionID`, `userID`, `transactionType`, `transactionAmount`, `date`) VALUES
(1, 2, 0, 432, '2020-10-15 10:27:58'),
(2, 2, 0, 5, '2020-10-15 10:28:04'),
(3, 2, 0, 21, '2020-10-15 10:28:08'),
(4, 3, 0, 956, '2020-10-15 10:43:47'),
(5, 3, 0, 424, '2020-10-15 10:43:54'),
(6, 3, 0, 60, '2020-10-15 10:44:08'),
(7, 2, 0, 242, '2020-10-21 14:48:20'),
(8, 2, 0, 241, '2020-10-21 14:48:25'),
(9, 2, 0, 5, '2020-10-21 14:48:29'),
(10, 2, 0, 543, '2020-10-21 14:48:41'),
(11, 6, 0, 1000000, '2020-10-26 13:34:01'),
(12, 6, 0, 50, '2020-10-26 13:34:15'),
(13, 6, 0, 50, '2020-10-26 13:34:19');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `user`
--

CREATE TABLE `user` (
  `userID` int(6) NOT NULL,
  `firstName` varchar(55) NOT NULL,
  `lastName` varchar(55) NOT NULL,
  `bankNumber` varchar(55) NOT NULL,
  `balance` int(255) NOT NULL,
  `role` int(2) NOT NULL,
  `password` varchar(255) NOT NULL,
  `password_salt` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `user`
--

INSERT INTO `user` (`userID`, `firstName`, `lastName`, `bankNumber`, `balance`, `role`, `password`, `password_salt`) VALUES
(3, 'Yoran', 'de Quay', '1234', 1320, 0, '5lF+VKt9781KSWqKySgetqh7+g1DzK02uoQ526/l4IM=', 'ZusCUDlrw3fJA4DOsj9P7k9oiY+1Z5g9yeLoyhCH7Xw='),
(4, 'tetd', 'fsa', '13546', 0, 0, 'ezXd3JGnWqAxuL7Hae49d92okNGe/d2jMW1iJKQtBGE=', '0Me//jMYRiixXiOlVKnYX3KoXyitI9a4bVpZe2zFAjc='),
(5, 'rsa', 'as', '1238', 0, 0, 'cfEWeCaukGNfSFQ9DIZIhG+yfgJoXKUu5qE/MxFPuyE=', 'AbFvb33P7ZfqEDTNNPj2+3DVjPxw2t5X74Htgjzmdes='),
(6, '123', '123', '123', 999900, 0, 'pOg9Cw7l+X4Or9QnfXgihubKGt3Ye4GN3fJNOK0vHG8=', 'QBLi9361ILFKqQHDl8uRD7nkBbWgZSr2auktwqP0bmY=');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`transactionID`);

--
-- Indexen voor tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userID`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `transaction`
--
ALTER TABLE `transaction`
  MODIFY `transactionID` smallint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT voor een tabel `user`
--
ALTER TABLE `user`
  MODIFY `userID` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
