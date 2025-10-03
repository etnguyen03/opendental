CREATE TABLE `orthochartlog` (
  `OrthoChartLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ComputerName` varchar(255) NOT NULL,
  `DateTimeLog` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTimeService` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `UserNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `OrthoChartRowNum` bigint(20) NOT NULL,
  `LogData` mediumtext NOT NULL,
  PRIMARY KEY (`OrthoChartLogNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
