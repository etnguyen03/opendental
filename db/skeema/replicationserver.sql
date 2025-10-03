CREATE TABLE `replicationserver` (
  `ReplicationServerNum` bigint(20) NOT NULL AUTO_INCREMENT,
  `Descript` text NOT NULL,
  `ServerId` int(10) unsigned NOT NULL,
  `RangeStart` bigint(20) NOT NULL,
  `RangeEnd` bigint(20) NOT NULL,
  `AtoZpath` varchar(255) NOT NULL,
  `UpdateBlocked` tinyint(4) NOT NULL,
  `SlaveMonitor` varchar(255) NOT NULL,
  PRIMARY KEY (`ReplicationServerNum`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
