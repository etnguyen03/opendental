CREATE TABLE `vaccinedef` (
  `VaccineDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CVXCode` varchar(255) NOT NULL,
  `VaccineName` varchar(255) NOT NULL,
  `DrugManufacturerNum` bigint(20) NOT NULL,
  PRIMARY KEY (`VaccineDefNum`),
  KEY `DrugManufacturerNum` (`DrugManufacturerNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
