CREATE TABLE `appointmentrule` (
  `AppointmentRuleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `RuleDesc` varchar(255) DEFAULT '',
  `CodeStart` varchar(15) DEFAULT NULL,
  `CodeEnd` varchar(15) DEFAULT NULL,
  `IsEnabled` tinyint(3) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`AppointmentRuleNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
