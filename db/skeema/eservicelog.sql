CREATE TABLE `eservicelog` (
  `EServiceLogNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `LogDateTime` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `PatNum` bigint(20) NOT NULL,
  `EServiceType` tinyint(4) DEFAULT NULL,
  `EServiceAction` smallint(6) DEFAULT NULL,
  `KeyType` smallint(6) DEFAULT NULL,
  `LogGuid` varchar(36) NOT NULL,
  `ClinicNum` bigint(20) DEFAULT NULL,
  `FKey` bigint(20) DEFAULT NULL,
  `DateTimeUploaded` datetime NOT NULL DEFAULT '0001-01-01 12:00:00',
  `Note` varchar(255) NOT NULL,
  PRIMARY KEY (`EServiceLogNum`),
  KEY `PatNum` (`PatNum`),
  KEY `DateTimeUploaded` (`DateTimeUploaded`),
  KEY `ClinicDateTime` (`ClinicNum`,`LogDateTime`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
