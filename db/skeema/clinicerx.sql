CREATE TABLE `clinicerx` (
  `ClinicErxNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ClinicDesc` varchar(255) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `EnabledStatus` tinyint(4) NOT NULL,
  `ClinicId` varchar(255) NOT NULL,
  `ClinicKey` varchar(255) NOT NULL,
  `AccountId` varchar(25) NOT NULL,
  `RegistrationKeyNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ClinicErxNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `RegistrationKeyNum` (`RegistrationKeyNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
