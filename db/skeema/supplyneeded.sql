CREATE TABLE `supplyneeded` (
  `SupplyNeededNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` text DEFAULT NULL,
  `DateAdded` date NOT NULL,
  PRIMARY KEY (`SupplyNeededNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
