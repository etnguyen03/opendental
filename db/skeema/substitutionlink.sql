CREATE TABLE `substitutionlink` (
  `SubstitutionLinkNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PlanNum` bigint(20) NOT NULL,
  `CodeNum` bigint(20) NOT NULL,
  `SubstitutionCode` varchar(25) NOT NULL,
  `SubstOnlyIf` int(11) NOT NULL,
  PRIMARY KEY (`SubstitutionLinkNum`),
  KEY `PlanNum` (`PlanNum`),
  KEY `CodeNum` (`CodeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
