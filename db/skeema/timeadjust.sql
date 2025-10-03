CREATE TABLE `timeadjust` (
  `TimeAdjustNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `EmployeeNum` bigint(20) NOT NULL,
  `TimeEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `RegHours` time NOT NULL DEFAULT '00:00:00',
  `OTimeHours` time NOT NULL DEFAULT '00:00:00',
  `Note` text DEFAULT NULL,
  `IsAuto` tinyint(4) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `PtoDefNum` bigint(20) NOT NULL DEFAULT 0,
  `PtoHours` time NOT NULL DEFAULT '00:00:00',
  `IsUnpaidProtectedLeave` tinyint(4) NOT NULL DEFAULT 0,
  `SecuUserNumEntry` bigint(20) NOT NULL DEFAULT 0,
  PRIMARY KEY (`TimeAdjustNum`),
  KEY `indexEmployeeNum` (`EmployeeNum`),
  KEY `ClinicNum` (`ClinicNum`),
  KEY `PtoDefNum` (`PtoDefNum`),
  KEY `SecuUserNumEntry` (`SecuUserNumEntry`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
