CREATE TABLE `providerclinic` (
  `ProviderClinicNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProvNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `DEANum` varchar(15) NOT NULL,
  `StateLicense` varchar(50) NOT NULL,
  `StateRxID` varchar(255) NOT NULL,
  `StateWhereLicensed` varchar(15) NOT NULL,
  `CareCreditMerchantId` varchar(20) NOT NULL,
  PRIMARY KEY (`ProviderClinicNum`),
  KEY `ProvNum` (`ProvNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
