CREATE TABLE `autonote` (
  `AutoNoteNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AutoNoteName` varchar(50) DEFAULT NULL,
  `MainText` text DEFAULT NULL,
  `Category` bigint(20) NOT NULL,
  PRIMARY KEY (`AutoNoteNum`),
  KEY `Category` (`Category`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
