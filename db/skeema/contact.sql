CREATE TABLE `contact` (
  `ContactNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `LName` varchar(255) DEFAULT '',
  `FName` varchar(255) DEFAULT '',
  `WkPhone` varchar(255) DEFAULT '',
  `Fax` varchar(255) DEFAULT '',
  `Category` bigint(20) NOT NULL,
  `Notes` text DEFAULT NULL,
  PRIMARY KEY (`ContactNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
