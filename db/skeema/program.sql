CREATE TABLE `program` (
  `ProgramNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ProgName` varchar(100) DEFAULT '',
  `ProgDesc` varchar(100) DEFAULT '',
  `Enabled` tinyint(1) unsigned NOT NULL DEFAULT 0,
  `Path` text NOT NULL DEFAULT '',
  `CommandLine` text NOT NULL DEFAULT '',
  `Note` text DEFAULT NULL,
  `PluginDllName` varchar(255) NOT NULL,
  `ButtonImage` text NOT NULL,
  `FileTemplate` text NOT NULL,
  `FilePath` varchar(255) NOT NULL,
  `IsDisabledByHq` tinyint(4) NOT NULL,
  `CustErr` varchar(255) NOT NULL,
  PRIMARY KEY (`ProgramNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
