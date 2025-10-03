CREATE TABLE `codesystem` (
  `CodeSystemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CodeSystemName` varchar(255) NOT NULL,
  `VersionCur` varchar(255) NOT NULL,
  `VersionAvail` varchar(255) NOT NULL,
  `HL7OID` varchar(255) NOT NULL,
  `Note` varchar(255) NOT NULL,
  PRIMARY KEY (`CodeSystemNum`),
  KEY `CodeSystemName` (`CodeSystemName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
