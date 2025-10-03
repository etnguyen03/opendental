CREATE TABLE `sigbutdef` (
  `SigButDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ButtonText` varchar(255) DEFAULT '',
  `ButtonIndex` smallint(6) NOT NULL,
  `SynchIcon` tinyint(3) unsigned NOT NULL,
  `ComputerName` varchar(255) DEFAULT '',
  `SigElementDefNumUser` bigint(20) NOT NULL,
  `SigElementDefNumExtra` bigint(20) NOT NULL,
  `SigElementDefNumMsg` bigint(20) NOT NULL,
  PRIMARY KEY (`SigButDefNum`),
  KEY `SigElementDefNumUser` (`SigElementDefNumUser`),
  KEY `SigElementDefNumExtra` (`SigElementDefNumExtra`),
  KEY `SigElementDefNumMsg` (`SigElementDefNumMsg`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
