CREATE TABLE `employer` (
  `EmployerNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EmpName` varchar(255) DEFAULT '',
  `Address` varchar(255) DEFAULT '',
  `Address2` varchar(255) DEFAULT '',
  `City` varchar(255) DEFAULT '',
  `State` varchar(255) DEFAULT '',
  `Zip` varchar(255) DEFAULT '',
  `Phone` varchar(255) DEFAULT '',
  PRIMARY KEY (`EmployerNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
