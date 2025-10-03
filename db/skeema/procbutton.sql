CREATE TABLE `procbutton` (
  `ProcButtonNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `ItemOrder` smallint(5) unsigned NOT NULL DEFAULT 0,
  `Category` bigint(20) NOT NULL,
  `ButtonImage` text DEFAULT NULL,
  `IsMultiVisit` tinyint(4) NOT NULL,
  PRIMARY KEY (`ProcButtonNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
