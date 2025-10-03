CREATE TABLE `quickpastecat` (
  `QuickPasteCatNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `ItemOrder` smallint(5) unsigned NOT NULL DEFAULT 0,
  `DefaultForTypes` text DEFAULT NULL,
  PRIMARY KEY (`QuickPasteCatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
