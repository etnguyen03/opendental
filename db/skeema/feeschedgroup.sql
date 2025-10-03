CREATE TABLE `feeschedgroup` (
  `FeeSchedGroupNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `FeeSchedNum` bigint(20) NOT NULL,
  `ClinicNums` varchar(255) NOT NULL,
  PRIMARY KEY (`FeeSchedGroupNum`),
  KEY `FeeSchedNum` (`FeeSchedNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
