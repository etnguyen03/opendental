CREATE TABLE `letter` (
  `LetterNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `BodyText` text DEFAULT NULL,
  PRIMARY KEY (`LetterNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
