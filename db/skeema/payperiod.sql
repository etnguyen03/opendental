CREATE TABLE `payperiod` (
  `PayPeriodNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateStart` date NOT NULL DEFAULT '0001-01-01',
  `DateStop` date NOT NULL DEFAULT '0001-01-01',
  `DatePaycheck` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`PayPeriodNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
