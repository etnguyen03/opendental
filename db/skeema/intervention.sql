CREATE TABLE `intervention` (
  `InterventionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `CodeValue` varchar(30) NOT NULL,
  `CodeSystem` varchar(30) NOT NULL,
  `Note` text NOT NULL,
  `DateEntry` date NOT NULL DEFAULT '0001-01-01',
  `CodeSet` tinyint(4) NOT NULL,
  `IsPatDeclined` tinyint(4) NOT NULL,
  PRIMARY KEY (`InterventionNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ProvNum` (`ProvNum`),
  KEY `CodeValue` (`CodeValue`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
