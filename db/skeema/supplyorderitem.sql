CREATE TABLE `supplyorderitem` (
  `SupplyOrderItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SupplyOrderNum` bigint(20) NOT NULL,
  `SupplyNum` bigint(20) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Price` double NOT NULL,
  `DateReceived` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`SupplyOrderItemNum`),
  KEY `SupplyOrderNum` (`SupplyOrderNum`),
  KEY `SupplyNum` (`SupplyNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
