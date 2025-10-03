CREATE TABLE `sop` (
  `SopNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SopCode` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  PRIMARY KEY (`SopNum`),
  KEY `SopCode` (`SopCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
