CREATE TABLE `equipment` (
  `EquipmentNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` text NOT NULL,
  `SerialNumber` varchar(255) DEFAULT NULL,
  `ModelYear` varchar(2) DEFAULT NULL,
  `DatePurchased` date NOT NULL DEFAULT '0001-01-01',
  `DateSold` date NOT NULL DEFAULT '0001-01-01',
  `PurchaseCost` double NOT NULL,
  `MarketValue` double NOT NULL,
  `Location` text NOT NULL,
  `DateEntry` date NOT NULL DEFAULT '0001-01-01',
  `ProvNumCheckedOut` bigint(20) NOT NULL,
  `DateCheckedOut` date NOT NULL DEFAULT '0001-01-01',
  `DateExpectedBack` date NOT NULL DEFAULT '0001-01-01',
  `DispenseNote` text NOT NULL,
  `Status` text NOT NULL,
  PRIMARY KEY (`EquipmentNum`),
  KEY `ProvNumCheckedOut` (`ProvNumCheckedOut`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
