CREATE TABLE `erouting` (
  `ERoutingNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Description` varchar(255) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `ClinicNum` bigint(20) NOT NULL,
  `SecDateTEntry` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `IsComplete` tinyint(4) NOT NULL,
  PRIMARY KEY (`ERoutingNum`),
  KEY `PatNum` (`PatNum`),
  KEY `ClinicNum` (`ClinicNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
