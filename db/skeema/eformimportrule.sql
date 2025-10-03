CREATE TABLE `eformimportrule` (
  `EFormImportRuleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `FieldName` varchar(255) NOT NULL,
  `Situation` tinyint(4) NOT NULL,
  `Action` tinyint(4) NOT NULL,
  PRIMARY KEY (`EFormImportRuleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
