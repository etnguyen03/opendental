CREATE TABLE `dashboardlayout` (
  `DashboardLayoutNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserNum` bigint(20) NOT NULL,
  `UserGroupNum` bigint(20) NOT NULL,
  `DashboardTabName` varchar(255) NOT NULL,
  `DashboardTabOrder` int(11) NOT NULL,
  `DashboardRows` int(11) NOT NULL,
  `DashboardColumns` int(11) NOT NULL,
  `DashboardGroupName` varchar(255) NOT NULL,
  PRIMARY KEY (`DashboardLayoutNum`),
  KEY `UserNum` (`UserNum`),
  KEY `UserGroupNum` (`UserGroupNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
