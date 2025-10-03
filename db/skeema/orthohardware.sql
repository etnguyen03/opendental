CREATE TABLE `orthohardware` (
  `OrthoHardwareNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DateExam` date NOT NULL DEFAULT '0001-01-01',
  `OrthoHardwareType` tinyint(4) NOT NULL,
  `OrthoHardwareSpecNum` bigint(20) NOT NULL,
  `ToothRange` varchar(255) NOT NULL,
  `Note` varchar(255) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  PRIMARY KEY (`OrthoHardwareNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
