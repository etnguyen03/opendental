CREATE TABLE `reminderrule` (
  `ReminderRuleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ReminderCriterion` tinyint(4) NOT NULL,
  `CriterionFK` bigint(20) NOT NULL,
  `CriterionValue` varchar(255) NOT NULL,
  `Message` varchar(255) NOT NULL,
  PRIMARY KEY (`ReminderRuleNum`),
  KEY `CriterionFK` (`CriterionFK`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
