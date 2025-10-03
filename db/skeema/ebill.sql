CREATE TABLE `ebill` (
  `EbillNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ClinicNum` bigint(20) NOT NULL,
  `ClientAcctNumber` varchar(255) NOT NULL,
  `ElectUserName` varchar(255) NOT NULL,
  `ElectPassword` varchar(255) NOT NULL,
  `PracticeAddress` tinyint(4) NOT NULL,
  `RemitAddress` tinyint(4) NOT NULL,
  PRIMARY KEY (`EbillNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
