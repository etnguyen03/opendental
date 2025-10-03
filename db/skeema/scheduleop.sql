CREATE TABLE `scheduleop` (
  `ScheduleOpNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ScheduleNum` bigint(20) NOT NULL,
  `OperatoryNum` bigint(20) NOT NULL,
  PRIMARY KEY (`ScheduleOpNum`),
  KEY `ScheduleNum` (`ScheduleNum`),
  KEY `OperatoryNum` (`OperatoryNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
