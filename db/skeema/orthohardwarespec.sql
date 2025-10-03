CREATE TABLE `orthohardwarespec` (
  `OrthoHardwareSpecNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrthoHardwareType` tinyint(4) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `ItemColor` int(11) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  PRIMARY KEY (`OrthoHardwareSpecNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
