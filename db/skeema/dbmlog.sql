CREATE TABLE `dbmlog` (
  `DbmLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `FKeyType` tinyint(4) NOT NULL,
  `ActionType` tinyint(4) NOT NULL,
  `DateTimeEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `MethodName` varchar(255) NOT NULL,
  `LogText` text NOT NULL,
  PRIMARY KEY (`DbmLogNum`),
  KEY `UserNum` (`UserNum`),
  KEY `FKeyAndType` (`FKey`,`FKeyType`),
  KEY `DateTimeEntry` (`DateTimeEntry`),
  KEY `MethodName` (`MethodName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
