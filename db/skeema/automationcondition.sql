CREATE TABLE `automationcondition` (
  `AutomationConditionNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `AutomationNum` bigint(20) NOT NULL,
  `CompareField` tinyint(4) NOT NULL,
  `Comparison` tinyint(4) NOT NULL,
  `CompareString` varchar(255) NOT NULL,
  PRIMARY KEY (`AutomationConditionNum`),
  KEY `AutomationNum` (`AutomationNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
