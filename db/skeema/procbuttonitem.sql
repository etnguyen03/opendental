CREATE TABLE `procbuttonitem` (
  `ProcButtonItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProcButtonNum` bigint(20) NOT NULL,
  `OldCode` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `AutoCodeNum` bigint(20) NOT NULL,
  `CodeNum` bigint(20) NOT NULL,
  `ItemOrder` bigint(20) NOT NULL,
  PRIMARY KEY (`ProcButtonItemNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
