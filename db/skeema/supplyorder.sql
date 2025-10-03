CREATE TABLE `supplyorder` (
  `SupplyOrderNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SupplierNum` bigint(20) NOT NULL,
  `DatePlaced` date NOT NULL,
  `Note` text DEFAULT NULL,
  `AmountTotal` double NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `ShippingCharge` double NOT NULL,
  `DateReceived` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`SupplyOrderNum`),
  KEY `SupplierNum` (`SupplierNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
