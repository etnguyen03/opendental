CREATE TABLE `clinicpref` (
  `ClinicPrefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `PrefName` varchar(255) NOT NULL,
  `ValueString` text NOT NULL,
  PRIMARY KEY (`ClinicPrefNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
