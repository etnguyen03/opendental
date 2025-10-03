CREATE TABLE `autocodecond` (
  `AutoCodeCondNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AutoCodeItemNum` bigint(20) NOT NULL,
  `Cond` tinyint(3) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`AutoCodeCondNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
