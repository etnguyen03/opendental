CREATE TABLE `gradingscale` (
  `GradingScaleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `ScaleType` tinyint(4) NOT NULL,
  PRIMARY KEY (`GradingScaleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
