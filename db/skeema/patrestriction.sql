CREATE TABLE `patrestriction` (
  `PatRestrictionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `PatNum` bigint(20) NOT NULL,
  `PatRestrictType` tinyint(4) NOT NULL,
  PRIMARY KEY (`PatRestrictionNum`),
  KEY `PatNumRestrictType` (`PatNum`,`PatRestrictType`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
