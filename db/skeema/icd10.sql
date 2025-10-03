CREATE TABLE `icd10` (
  `Icd10Num` bigint(20) NOT NULL AUTO_INCREMENT,
  `Icd10Code` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `IsCode` varchar(255) NOT NULL,
  PRIMARY KEY (`Icd10Num`),
  KEY `Icd10Code` (`Icd10Code`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
