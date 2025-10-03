CREATE TABLE `medlabspecimen` (
  `MedLabSpecimenNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MedLabNum` bigint(20) NOT NULL,
  `SpecimenID` varchar(255) NOT NULL,
  `SpecimenDescript` varchar(255) NOT NULL,
  `DateTimeCollected` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`MedLabSpecimenNum`),
  KEY `MedLabNum` (`MedLabNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
