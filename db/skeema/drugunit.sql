CREATE TABLE `drugunit` (
  `DrugUnitNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `UnitIdentifier` varchar(20) NOT NULL,
  `UnitText` varchar(255) NOT NULL,
  PRIMARY KEY (`DrugUnitNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
