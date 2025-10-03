CREATE TABLE `timecardrule` (
  `TimeCardRuleNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EmployeeNum` bigint(20) NOT NULL,
  `OverHoursPerDay` time NOT NULL,
  `AfterTimeOfDay` time NOT NULL,
  `BeforeTimeOfDay` time NOT NULL,
  `IsOvertimeExempt` tinyint(4) NOT NULL,
  `MinClockInTime` time NOT NULL,
  `HasWeekendRate3` tinyint(4) NOT NULL,
  PRIMARY KEY (`TimeCardRuleNum`),
  KEY `EmployeeNum` (`EmployeeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
