CREATE TABLE `laboratory` (
  `LaboratoryNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT NULL,
  `Phone` varchar(255) DEFAULT NULL,
  `Notes` text DEFAULT NULL,
  `Slip` bigint(20) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `City` varchar(255) NOT NULL,
  `State` varchar(255) NOT NULL,
  `Zip` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `WirelessPhone` varchar(255) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  PRIMARY KEY (`LaboratoryNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
