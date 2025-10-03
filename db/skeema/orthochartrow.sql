CREATE TABLE `orthochartrow` (
  `OrthoChartRowNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DateTimeService` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `UserNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `Signature` text NOT NULL,
  PRIMARY KEY (`OrthoChartRowNum`),
  KEY `PatNum` (`PatNum`),
  KEY `UserNum` (`UserNum`),
  KEY `ProvNum` (`ProvNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
