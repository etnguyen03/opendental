CREATE TABLE `allergydef` (
  `AllergyDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `SnomedType` tinyint(4) DEFAULT NULL,
  `MedicationNum` bigint(20) NOT NULL,
  `UniiCode` varchar(255) NOT NULL,
  PRIMARY KEY (`AllergyDefNum`),
  KEY `MedicationNum` (`MedicationNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
