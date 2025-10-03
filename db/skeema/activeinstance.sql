CREATE TABLE `activeinstance` (
  `ActiveInstanceNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ComputerNum` bigint(20) NOT NULL,
  `UserNum` bigint(20) NOT NULL,
  `ProcessId` bigint(20) NOT NULL,
  `DateTimeLastActive` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `DateTRecorded` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `ConnectionType` tinyint(4) NOT NULL,
  PRIMARY KEY (`ActiveInstanceNum`),
  KEY `ComputerNum` (`ComputerNum`),
  KEY `UserNum` (`UserNum`),
  KEY `ProcessId` (`ProcessId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
