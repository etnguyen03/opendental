CREATE TABLE `supplier` (
  `SupplierNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `CustomerId` varchar(255) DEFAULT NULL,
  `Website` text DEFAULT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `Note` text DEFAULT NULL,
  PRIMARY KEY (`SupplierNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
