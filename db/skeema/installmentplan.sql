CREATE TABLE `installmentplan` (
  `InstallmentPlanNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `DateAgreement` date NOT NULL DEFAULT '0001-01-01',
  `DateFirstPayment` date NOT NULL DEFAULT '0001-01-01',
  `MonthlyPayment` double NOT NULL,
  `APR` float NOT NULL,
  `Note` varchar(255) NOT NULL,
  PRIMARY KEY (`InstallmentPlanNum`),
  KEY `PatNum` (`PatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
