CREATE TABLE `entrylog` (
  `EntryLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `FKeyType` tinyint(4) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `LogSource` tinyint(4) NOT NULL,
  `EntryDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`EntryLogNum`),
  KEY `UserNum` (`UserNum`),
  KEY `FKey` (`FKey`),
  KEY `EntryDateTime` (`EntryDateTime`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
