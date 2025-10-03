CREATE TABLE `autocodeitem` (
  `AutoCodeItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AutoCodeNum` bigint(20) NOT NULL,
  `OldCode` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `CodeNum` bigint(20) NOT NULL,
  PRIMARY KEY (`AutoCodeItemNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
