CREATE TABLE `pharmclinic` (
  `PharmClinicNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PharmacyNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  PRIMARY KEY (`PharmClinicNum`),
  KEY `PharmacyNum` (`PharmacyNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
