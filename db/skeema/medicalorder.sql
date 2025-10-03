CREATE TABLE `medicalorder` (
  `MedicalOrderNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MedOrderType` tinyint(4) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `DateTimeOrder` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Description` varchar(255) NOT NULL,
  `IsDiscontinued` tinyint(4) NOT NULL,
  `ProvNum` bigint(20) NOT NULL,
  PRIMARY KEY (`MedicalOrderNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ProvNum` (`ProvNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
