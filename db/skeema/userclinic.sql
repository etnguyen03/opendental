CREATE TABLE `userclinic` (
  `UserClinicNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  PRIMARY KEY (`UserClinicNum`),
  KEY `UserNum` (`UserNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
