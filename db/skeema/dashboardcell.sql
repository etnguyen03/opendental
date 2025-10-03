CREATE TABLE `dashboardcell` (
  `DashboardCellNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DashboardLayoutNum` bigint(20) NOT NULL,
  `CellRow` int(11) NOT NULL,
  `CellColumn` int(11) NOT NULL,
  `CellType` varchar(255) NOT NULL,
  `CellSettings` text NOT NULL,
  `LastQueryTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `LastQueryData` text NOT NULL,
  `RefreshRateSeconds` int(11) NOT NULL,
  PRIMARY KEY (`DashboardCellNum`),
  KEY `DashboardLayoutNum` (`DashboardLayoutNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
