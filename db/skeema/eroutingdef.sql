CREATE TABLE `eroutingdef` (
  `ERoutingDefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `UserNumCreated` bigint(20) NOT NULL,
  `UserNumModified` bigint(20) NOT NULL,
  `SecDateTEntered` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateLastModified` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`ERoutingDefNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `UserNumCreated` (`UserNumCreated`),
  KEY `UserNumModified` (`UserNumModified`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
