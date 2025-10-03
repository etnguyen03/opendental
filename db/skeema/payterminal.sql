CREATE TABLE `payterminal` (
  `PayTerminalNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `TerminalID` varchar(255) NOT NULL,
  PRIMARY KEY (`PayTerminalNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
