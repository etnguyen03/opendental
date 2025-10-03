CREATE TABLE `grouppermission` (
  `GroupPermNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `NewerDate` date NOT NULL DEFAULT '0001-01-01',
  `NewerDays` int(11) NOT NULL,
  `UserGroupNum` bigint(20) NOT NULL,
  `PermType` smallint(6) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  PRIMARY KEY (`GroupPermNum`),
  KEY `FKey` (`FKey`),
  KEY `UserGroupNum` (`UserGroupNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
