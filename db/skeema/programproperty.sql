CREATE TABLE `programproperty` (
  `ProgramPropertyNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProgramNum` bigint(20) NOT NULL,
  `PropertyDesc` varchar(255) DEFAULT '',
  `PropertyValue` text DEFAULT NULL,
  `ComputerName` varchar(255) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `IsMasked` tinyint(4) NOT NULL,
  `IsHighSecurity` tinyint(4) NOT NULL,
  PRIMARY KEY (`ProgramPropertyNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
