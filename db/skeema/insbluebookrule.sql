CREATE TABLE `insbluebookrule` (
  `InsBlueBookRuleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ItemOrder` smallint(6) NOT NULL,
  `RuleType` tinyint(4) NOT NULL,
  `LimitValue` int(11) NOT NULL,
  `LimitType` tinyint(4) NOT NULL,
  PRIMARY KEY (`InsBlueBookRuleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
