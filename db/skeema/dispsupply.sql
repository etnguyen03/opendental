CREATE TABLE `dispsupply` (
  `DispSupplyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SupplyNum` bigint(20) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  `DateDispensed` date NOT NULL DEFAULT '0001-01-01',
  `DispQuantity` float NOT NULL,
  `Note` text NOT NULL,
  PRIMARY KEY (`DispSupplyNum`),
  KEY `SupplyNum` (`SupplyNum`),
  KEY `ProvNum` (`ProvNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
