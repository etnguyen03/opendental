CREATE TABLE `scheduledprocess` (
  `ScheduledProcessNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ScheduledAction` varchar(50) NOT NULL,
  `TimeToRun` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `FrequencyToRun` varchar(50) NOT NULL,
  `LastRanDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`ScheduledProcessNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
