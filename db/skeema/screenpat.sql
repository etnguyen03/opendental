CREATE TABLE `screenpat` (
  `ScreenPatNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `ScreenGroupNum` bigint(20) NOT NULL,
  `SheetNum` bigint(20) NOT NULL,
  `PatScreenPerm` tinyint(4) NOT NULL,
  PRIMARY KEY (`ScreenPatNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ScreenGroupNum` (`ScreenGroupNum`),
  KEY `SheetNum` (`SheetNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
