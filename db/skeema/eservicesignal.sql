CREATE TABLE `eservicesignal` (
  `EServiceSignalNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `ServiceCode` int(11) NOT NULL,
  `ReasonCategory` int(11) NOT NULL,
  `ReasonCode` int(11) NOT NULL,
  `Severity` tinyint(4) NOT NULL,
  `Description` text NOT NULL,
  `SigDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Tag` text NOT NULL,
  `IsProcessed` tinyint(4) NOT NULL,
  PRIMARY KEY (`EServiceSignalNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
