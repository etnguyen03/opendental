CREATE TABLE `dashboardar` (
  `DashboardARNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateCalc` date NOT NULL DEFAULT '0001-01-01',
  `BalTotal` double NOT NULL,
  `InsEst` double NOT NULL,
  PRIMARY KEY (`DashboardARNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
