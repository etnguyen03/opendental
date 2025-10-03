CREATE TABLE `providercliniclink` (
  `ProviderClinicLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProvNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ProviderClinicLinkNum`),
  KEY `ProvNum` (`ProvNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
