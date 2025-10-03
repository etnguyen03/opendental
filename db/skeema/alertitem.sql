CREATE TABLE `alertitem` (
  `AlertItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `Description` varchar(2000) NOT NULL,
  `Type` tinyint(4) NOT NULL,
  `Severity` tinyint(4) NOT NULL,
  `Actions` tinyint(4) NOT NULL,
  `FormToOpen` tinyint(4) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `ItemValue` varchar(4000) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`AlertItemNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `FKey` (`FKey`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
