CREATE TABLE `definition` (
  `DefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Category` tinyint(3) unsigned NOT NULL DEFAULT 0,
  `ItemOrder` smallint(5) unsigned NOT NULL DEFAULT 0,
  `ItemName` varchar(255) DEFAULT '',
  `ItemValue` varchar(255) DEFAULT '',
  `ItemColor` int(11) NOT NULL DEFAULT 0,
  `IsHidden` tinyint(3) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`DefNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
