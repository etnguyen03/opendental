CREATE TABLE `databasemaintenance` (
  `DatabaseMaintenanceNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `MethodName` varchar(255) NOT NULL,
  `IsHidden` tinyint(4) NOT NULL,
  `IsOld` tinyint(4) NOT NULL,
  `DateLastRun` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`DatabaseMaintenanceNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
