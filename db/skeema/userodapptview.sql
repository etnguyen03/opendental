CREATE TABLE `userodapptview` (
  `UserodApptViewNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `ApptViewNum` bigint(20) NOT NULL,
  PRIMARY KEY (`UserodApptViewNum`),
  KEY `UserNum` (`UserNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `ApptViewNum` (`ApptViewNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
