CREATE TABLE `gradingscaleitem` (
  `GradingScaleItemNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `GradingScaleNum` bigint(20) NOT NULL,
  `GradeShowing` varchar(255) NOT NULL,
  `GradeNumber` float NOT NULL,
  `Description` varchar(255) NOT NULL,
  PRIMARY KEY (`GradingScaleItemNum`),
  KEY `GradingScaleNum` (`GradingScaleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
