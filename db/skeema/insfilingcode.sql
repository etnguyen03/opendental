CREATE TABLE `insfilingcode` (
  `InsFilingCodeNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Descript` varchar(255) DEFAULT NULL,
  `EclaimCode` varchar(100) DEFAULT NULL,
  `ItemOrder` int(11) DEFAULT NULL,
  `GroupType` bigint(20) NOT NULL,
  `ExcludeOtherCoverageOnPriClaims` tinyint(4) NOT NULL,
  PRIMARY KEY (`InsFilingCodeNum`),
  KEY `ItemOrder` (`ItemOrder`),
  KEY `GroupType` (`GroupType`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
