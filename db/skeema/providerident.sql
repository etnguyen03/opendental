CREATE TABLE `providerident` (
  `ProviderIdentNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProvNum` bigint(20) NOT NULL,
  `PayorID` varchar(255) DEFAULT '',
  `SuppIDType` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `IDNumber` varchar(255) DEFAULT '',
  PRIMARY KEY (`ProviderIdentNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
