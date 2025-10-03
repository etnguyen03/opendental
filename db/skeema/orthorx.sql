CREATE TABLE `orthorx` (
  `OrthoRxNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrthoHardwareSpecNum` bigint(20) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `ToothRange` varchar(255) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  PRIMARY KEY (`OrthoRxNum`),
  KEY `OrthoHardwareSpecNum` (`OrthoHardwareSpecNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
