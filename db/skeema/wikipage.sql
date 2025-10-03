CREATE TABLE `wikipage` (
  `WikiPageNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `PageTitle` varchar(255) NOT NULL,
  `KeyWords` varchar(255) NOT NULL,
  `PageContent` mediumtext NOT NULL,
  `DateTimeSaved` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `IsDraft` tinyint(4) NOT NULL,
  `IsLocked` tinyint(4) NOT NULL,
  `IsDeleted` tinyint(4) NOT NULL DEFAULT 0,
  `PageContentPlainText` mediumtext NOT NULL,
  PRIMARY KEY (`WikiPageNum`),
  KEY `UserNum` (`UserNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
