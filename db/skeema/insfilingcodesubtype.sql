CREATE TABLE `insfilingcodesubtype` (
  `InsFilingCodeSubtypeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `InsFilingCodeNum` bigint(20) NOT NULL,
  `Descript` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`InsFilingCodeSubtypeNum`),
  KEY `InsFilingCodeNum` (`InsFilingCodeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
