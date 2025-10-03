CREATE TABLE `autocommexcludedate` (
  `AutoCommExcludeDateNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `DateExclude` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`AutoCommExcludeDateNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
