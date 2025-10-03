CREATE TABLE `diseasedef` (
  `DiseaseDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DiseaseName` varchar(255) DEFAULT '',
  `ItemOrder` smallint(5) unsigned NOT NULL,
  `IsHidden` tinyint(3) unsigned NOT NULL,
  `DateTStamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `ICD9Code` varchar(255) NOT NULL,
  `SnomedCode` varchar(255) NOT NULL,
  `Icd10Code` varchar(255) NOT NULL,
  PRIMARY KEY (`DiseaseDefNum`),
  KEY `ICD9Code` (`ICD9Code`),
  KEY `SnomedCode` (`SnomedCode`),
  KEY `Icd10Code` (`Icd10Code`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
