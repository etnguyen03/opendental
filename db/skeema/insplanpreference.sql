CREATE TABLE `insplanpreference` (
  `InsPlanPrefNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PlanNum` bigint(20) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `FKeyType` tinyint(4) NOT NULL,
  `ValueString` text NOT NULL,
  PRIMARY KEY (`InsPlanPrefNum`),
  KEY `PlanNum` (`PlanNum`),
  KEY `FKey` (`FKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
