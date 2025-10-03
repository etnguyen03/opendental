CREATE TABLE `tasklist` (
  `TaskListNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Descript` varchar(255) DEFAULT '',
  `Parent` bigint(20) NOT NULL,
  `DateTL` date NOT NULL DEFAULT '0001-01-01',
  `IsRepeating` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `DateType` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `FromNum` bigint(20) NOT NULL,
  `ObjectType` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `DateTimeEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `GlobalTaskFilterType` tinyint(4) NOT NULL,
  `TaskListStatus` tinyint(4) NOT NULL,
  PRIMARY KEY (`TaskListNum`),
  KEY `indexParent` (`Parent`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
