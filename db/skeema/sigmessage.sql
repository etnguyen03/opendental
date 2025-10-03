CREATE TABLE `sigmessage` (
  `SigMessageNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ButtonText` varchar(255) NOT NULL,
  `ButtonIndex` int(11) NOT NULL,
  `SynchIcon` tinyint(3) unsigned NOT NULL,
  `FromUser` varchar(255) NOT NULL,
  `ToUser` varchar(255) NOT NULL,
  `MessageDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `AckDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `SigText` varchar(255) NOT NULL,
  `SigElementDefNumUser` bigint(20) NOT NULL,
  `SigElementDefNumExtra` bigint(20) NOT NULL,
  `SigElementDefNumMsg` bigint(20) NOT NULL,
  PRIMARY KEY (`SigMessageNum`),
  KEY `SigElementDefNumUser` (`SigElementDefNumUser`),
  KEY `SigElementDefNumExtra` (`SigElementDefNumExtra`),
  KEY `SigElementDefNumMsg` (`SigElementDefNumMsg`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
