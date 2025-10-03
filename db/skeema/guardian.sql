CREATE TABLE `guardian` (
  `GuardianNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNumChild` bigint(20) NOT NULL,
  `PatNumGuardian` bigint(20) NOT NULL,
  `Relationship` tinyint(4) NOT NULL,
  `IsGuardian` tinyint(4) NOT NULL,
  PRIMARY KEY (`GuardianNum`),
  KEY `PatNumChild` (`PatNumChild`),
  KEY `PatNumGuardian` (`PatNumGuardian`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
