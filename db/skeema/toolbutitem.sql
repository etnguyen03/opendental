CREATE TABLE `toolbutitem` (
  `ToolButItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProgramNum` bigint(20) NOT NULL,
  `ToolBar` smallint(5) unsigned NOT NULL DEFAULT 0,
  `ButtonText` varchar(255) DEFAULT '',
  PRIMARY KEY (`ToolButItemNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
