CREATE TABLE `covspan` (
  `CovSpanNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `CovCatNum` bigint(20) NOT NULL,
  `FromCode` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT '',
  `ToCode` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT '',
  PRIMARY KEY (`CovSpanNum`),
  KEY `CovCatNum` (`CovCatNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
