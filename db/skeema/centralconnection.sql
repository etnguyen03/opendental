CREATE TABLE `centralconnection` (
  `CentralConnectionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ServerName` varchar(255) NOT NULL,
  `DatabaseName` varchar(255) NOT NULL,
  `MySqlUser` varchar(255) NOT NULL,
  `MySqlPassword` varchar(255) NOT NULL,
  `ServiceURI` varchar(255) NOT NULL,
  `OdUser` varchar(255) NOT NULL,
  `OdPassword` varchar(255) NOT NULL,
  `Note` text NOT NULL,
  `ItemOrder` int(11) NOT NULL,
  `WebServiceIsEcw` tinyint(4) NOT NULL,
  `ConnectionStatus` varchar(255) NOT NULL,
  `HasClinicBreakdownReports` tinyint(4) NOT NULL,
  PRIMARY KEY (`CentralConnectionNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
