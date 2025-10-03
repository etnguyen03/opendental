CREATE TABLE `wikilisthist` (
  `WikiListHistNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `ListName` varchar(255) NOT NULL,
  `ListHeaders` text NOT NULL,
  `ListContent` mediumtext NOT NULL,
  `DateTimeSaved` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`WikiListHistNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
