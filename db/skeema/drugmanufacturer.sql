CREATE TABLE `drugmanufacturer` (
  `DrugManufacturerNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ManufacturerName` varchar(255) NOT NULL,
  `ManufacturerCode` varchar(20) NOT NULL,
  PRIMARY KEY (`DrugManufacturerNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
