CREATE TABLE `ehrmeasureevent` (
  `EhrMeasureEventNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `DateTEvent` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `EventType` tinyint(4) NOT NULL,
  `PatNum` bigint(20) NOT NULL,
  `MoreInfo` varchar(255) NOT NULL,
  `CodeValueEvent` varchar(30) NOT NULL,
  `CodeSystemEvent` varchar(30) NOT NULL,
  `CodeValueResult` varchar(30) NOT NULL,
  `CodeSystemResult` varchar(30) NOT NULL,
  `FKey` bigint(20) NOT NULL,
  `TobaccoCessationDesire` tinyint(3) unsigned NOT NULL,
  `DateStartTobacco` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`EhrMeasureEventNum`),
  KEY `PatNum` (`PatNum`),
  KEY `CodeValueEvent` (`CodeValueEvent`),
  KEY `CodeValueResult` (`CodeValueResult`),
  KEY `FKey` (`FKey`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
