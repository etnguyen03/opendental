CREATE TABLE `supply` (
  `SupplyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `SupplierNum` bigint(20) NOT NULL,
  `CatalogNumber` varchar(255) DEFAULT NULL,
  `Descript` varchar(255) DEFAULT NULL,
  `Category` bigint(20) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `LevelDesired` float NOT NULL,
  `IsHidden` tinyint(1) NOT NULL,
  `Price` double NOT NULL,
  `BarCodeOrID` varchar(255) NOT NULL,
  `DispDefaultQuant` float NOT NULL,
  `DispUnitsCount` int(11) NOT NULL,
  `DispUnitDesc` varchar(255) NOT NULL,
  `LevelOnHand` float NOT NULL,
  `OrderQty` int(11) NOT NULL,
  PRIMARY KEY (`SupplyNum`),
  KEY `SupplierNum` (`SupplierNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
