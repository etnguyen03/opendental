CREATE TABLE `alertsub` (
  `AlertSubNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `Type` tinyint(4) NOT NULL,
  `AlertCategoryNum` bigint(20) NOT NULL,
  PRIMARY KEY (`AlertSubNum`),
  KEY `UserNum` (`UserNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `AlertCategoryNum` (`AlertCategoryNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
