CREATE TABLE `encounter` (
  `EncounterNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `CodeValue` varchar(30) NOT NULL,
  `CodeSystem` varchar(30) NOT NULL,
  `Note` text NOT NULL,
  `DateEncounter` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`EncounterNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ProvNum` (`ProvNum`),
  KEY `CodeValue` (`CodeValue`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
