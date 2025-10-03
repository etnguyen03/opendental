CREATE TABLE `automation` (
  `AutomationNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` text NOT NULL,
  `Autotrigger` tinyint(4) NOT NULL,
  `ProcCodes` text NOT NULL,
  `AutoAction` tinyint(4) NOT NULL,
  `SheetDefNum` bigint(20) NOT NULL,
  `CommType` bigint(20) NOT NULL,
  `MessageContent` text NOT NULL,
  `AptStatus` tinyint(4) NOT NULL,
  `AppointmentTypeNum` bigint(20) NOT NULL,
  `PatStatus` tinyint(4) NOT NULL,
  PRIMARY KEY (`AutomationNum`),
  KEY `AppointmentTypeNum` (`AppointmentTypeNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
