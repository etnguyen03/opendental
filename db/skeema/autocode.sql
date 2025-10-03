CREATE TABLE `autocode` (
  `AutoCodeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) DEFAULT '',
  `IsHidden` tinyint(1) unsigned NOT NULL DEFAULT 0,
  `LessIntrusive` tinyint(1) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`AutoCodeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
