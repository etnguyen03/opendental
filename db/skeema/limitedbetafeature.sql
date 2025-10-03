CREATE TABLE `limitedbetafeature` (
  `LimitedBetaFeatureNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `LimitedBetaFeatureTypeNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `IsSignedUp` tinyint(4) NOT NULL,
  PRIMARY KEY (`LimitedBetaFeatureNum`),
  KEY `LimitedBetaFeatureTypeNum` (`LimitedBetaFeatureTypeNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
