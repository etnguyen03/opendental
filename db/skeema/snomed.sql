CREATE TABLE `snomed` (
  `SnomedNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SnomedCode` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  PRIMARY KEY (`SnomedNum`),
  KEY `SnomedCode` (`SnomedCode`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
