CREATE TABLE `certemployee` (
  `CertEmployeeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CertNum` bigint(20) NOT NULL,
  `EmployeeNum` bigint(20) NOT NULL,
  `DateCompleted` date NOT NULL DEFAULT '0001-01-01',
  `Note` varchar(255) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  PRIMARY KEY (`CertEmployeeNum`),
  KEY `UserNum` (`UserNum`),
  KEY `CertNum` (`CertNum`),
  KEY `EmployeeNum` (`EmployeeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
