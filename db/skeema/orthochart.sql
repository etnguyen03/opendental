CREATE TABLE `orthochart` (
  `OrthoChartNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DateService` date NOT NULL DEFAULT '0001-01-01',
  `FieldName` varchar(255) NOT NULL,
  `FieldValue` text NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `OrthoChartRowNum` bigint(20) NOT NULL,
  PRIMARY KEY (`OrthoChartNum`),
  KEY `PatNum` (`PatNum`),
  KEY `UserNum` (`UserNum`),
  KEY `OrthoChartRowNum` (`OrthoChartRowNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
